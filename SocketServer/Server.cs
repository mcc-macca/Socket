using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer {
    public partial class Server : Form {
        private TcpListener listener; // Server TCP per ascoltare le connessioni in arrivo  
        private bool isRunning = false; // Stato del server (attivo o inattivo)  
        private CancellationTokenSource cts; // Token per gestire la cancellazione delle operazioni asincrone  

        public Server() {
            InitializeComponent();
            #region Inizializzo i componenti  
            // Configurazione iniziale dei componenti dell'interfaccia utente  
            numPort.Maximum = 36000; // Imposta il valore massimo per il controllo della porta  
            numPort.Value = 11000; // Imposta il valore predefinito della porta  

            // Ottiene gli indirizzi IP del computer e li aggiunge alla lista  
            string hostname = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostname);
            comboIpServer.Items.Clear();
            foreach (IPAddress ip in ipAddresses) {
                if (ip.ToString().StartsWith("169.254.")) continue; // Ignora gli indirizzi di tipo link-local  
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    comboIpServer.Items.Add(ip.ToString()); // Aggiunge solo gli indirizzi IPv4  
                }
            }
            if (comboIpServer.Items.Count > 0) comboIpServer.SelectedIndex = 0; // Seleziona il primo indirizzo disponibile  

            btnControl.Text = "Start"; // Imposta il testo del pulsante di controllo  
            btnControl.Click += BtnControl_Click; // Aggiunge l'evento click al pulsante  
            #endregion
        }

        private async void BtnControl_Click(object sender, EventArgs e) {
            #region Controllo del server  
            // Avvia o ferma il server in base al suo stato attuale  
            if (!isRunning) {
                StartServer(); // Avvia il server  
                btnControl.Text = "Stop"; // Cambia il testo del pulsante  
            }
            else {
                StopServer(); // Ferma il server  
                btnControl.Text = "Start"; // Cambia il testo del pulsante  
            }
            #endregion
        }

        private void StartServer() {
            #region Apro l'ascolto delle connessioni  
            // Avvia il server per ascoltare le connessioni in arrivo  
            if (isRunning) return; // Se il server è già in esecuzione, esce  
            isRunning = true;
            cts = new CancellationTokenSource(); // Crea un nuovo token di cancellazione  
            int port = (int)numPort.Value; // Ottiene il numero di porta selezionato  
            IPAddress ipAddress = IPAddress.Parse(comboIpServer.SelectedItem.ToString()); // Ottiene l'indirizzo IP selezionato  
            listener = new TcpListener(ipAddress, port); // Crea un listener TCP  
            listener.Start(); // Avvia il listener  
            textRx.AppendLine("[SERVER] In ascolto su " + ipAddress + ":" + port); // Mostra un messaggio nella UI  
            Task.Run(() => AcceptClientsAsync(cts.Token)); // Avvia il task per accettare connessioni  
            #endregion
        }

        private async Task AcceptClientsAsync(CancellationToken token) {
            #region Accetto le connessioni asicrone al server  
            // Accetta connessioni dai client in modo asincrono  
            while (!token.IsCancellationRequested) {
                try {
                    TcpClient client = await listener.AcceptTcpClientAsync(); // Accetta una connessione  
                    _ = Task.Run(() => HandleClientAsync(client, token)); // Gestisce il client in un task separato  
                }
                catch (Exception ex) {
                    if (!token.IsCancellationRequested)
                        textRx.AppendLine("[ERROR] " + ex.Message); // Mostra eventuali errori nella UI  
                }
            }
            #endregion
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken token) {
            #region Gestisco le richieste dal client  
            // Gestisce la comunicazione con un client connesso  
            try {
                NetworkStream stream = client.GetStream(); // Ottiene il flusso di rete del client  
                byte[] buffer = new byte[1024]; // Buffer per i dati ricevuti  
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token); // Legge i dati dal client  

                if (bytesRead == 0) {
                    textRx.AppendLine("[SERVER] Connessione chiusa dal client."); // Messaggio di chiusura connessione  
                    return;
                }

                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim(); // Converte i dati ricevuti in stringa  
                textRx.AppendLine("[CLIENT] > " + receivedData); // Mostra i dati ricevuti nella UI  

                // INVIA UNA RISPOSTA AL CLIENT  
                string response = "Ricevuto: " + receivedData; // Prepara la risposta  
                byte[] responseBytes = Encoding.UTF8.GetBytes(response + Environment.NewLine); // Converte la risposta in byte  
                await stream.WriteAsync(responseBytes, 0, responseBytes.Length, token); // Invia la risposta al client  
                await stream.FlushAsync(token); // Assicura che i dati siano inviati  
            }
            catch (Exception ex) {
                textRx.AppendLine("[ERROR] " + ex.Message); // Mostra eventuali errori nella UI  
            }
            finally {
                client.Close(); // Chiude la connessione con il client  
            }
            #endregion
        }

        private void StopServer() {
            #region Fermo il server  
            // Ferma il server e interrompe tutte le connessioni  
            if (!isRunning) return; // Se il server non è in esecuzione, esce  
            isRunning = false;
            cts.Cancel(); // Annulla tutte le operazioni asincrone  
            listener.Stop(); // Ferma il listener  
            textRx.AppendLine("[SERVER] Fermato"); // Mostra un messaggio nella UI  
            #endregion
        }
    }



    public static class WinFormsExtension {
        #region Funzione AppendLine  
        // Estensione per aggiungere una riga di testo a un controllo TextBox  
        public static void AppendLine(this TextBox source, string value) {
            if (source.InvokeRequired) {
                source.Invoke(new Action(() => AppendLine(source, value))); // Esegue l'operazione nel thread UI  
            }
            else {
                if (source.Text.Length == 0) {
                    source.Text = value; // Imposta il testo se è vuoto  
                }
                else {
                    source.AppendText("\r\n" + value); // Aggiunge una nuova riga di testo  
                }
            }
        }
        #endregion
    }
}
