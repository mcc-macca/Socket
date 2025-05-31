using SocketClient;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SocketClient {
    public partial class Client : Form {
        public Client() {
            InitializeComponent();

            #region Inizializzo i componenti

            // Ottengo il nome dell'host locale
            string hostname = Dns.GetHostName();

            // Imposto il range e il valore di default della porta
            numPort.Maximum = 36000;
            numPort.Value = 11000;

            // Recupero tutti gli indirizzi IP dell'host e li inserisco nella combo
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostname);
            comboIpClient.Items.Clear();
            foreach (IPAddress ip in ipAddresses) {
                if (ip.ToString().StartsWith("169.254.")) continue; // Escludo IP automatici
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    comboIpClient.Items.Add(ip.ToString()); // Solo IPv4
                }
            }

            // Seleziono il primo IP disponibile
            if (comboIpClient.Items.Count > 0) {
                comboIpClient.SelectedIndex = 0;
            }

            // Messaggio di avvio client
            textRx.AppendLine("[SOCKET] > CLIENT AVVIATO");

            #endregion
        }

        private void btnInvia_Click(object sender, EventArgs e) {
            #region Verifico i dati ricevuti e li mando o come testo o come JSON
            textInvio.Text = textInvio.Text.Trim();
            if (string.IsNullOrEmpty(textInvio.Text)) {
                MessageBox.Show("Inserire un messaggio da inviare", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ipAddress;
            try {
                textIpServer.Text = textIpServer.Text.Trim();
                ipAddress = IPAddress.Parse(textIpServer.Text);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string messageToSend = $"{Dns.GetHostName()} | {comboIpClient.Text} | {date} | {textInvio.Text}";

            textRx.AppendLine($"[CLIENT] {date} > Inviando messaggio...");
            textRx.AppendLine($"[CLIENT] Messaggio: {messageToSend}");
            #endregion

            #region Invio del messaggio al server
            Socket clientSocket = null;
            try {
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, (int)numPort.Value);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(remoteEP);

                if (!clientSocket.Connected) {
                    MessageBox.Show("Connessione al server non riuscita.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textRx.AppendLine("[CLIENT] " + date + " > CONNESSIONE AL SERVER NON RIUSCITA.");
                    return;
                }

                byte[] msg = Encoding.UTF8.GetBytes(messageToSend + Environment.NewLine);
                clientSocket.Send(msg);

                // Ricevo la risposta dal server
                byte[] buffer = new byte[1024];
                int bytesRec = clientSocket.Receive(buffer);

                if (bytesRec > 0) {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    textRx.AppendLine("[SERVER] " + date + " > " + response.Trim());
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Errore:\n" + ex, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (clientSocket != null) {
                    try {
                        if (clientSocket.Connected)
                            clientSocket.Shutdown(SocketShutdown.Both);
                    }
                    catch { }
                    clientSocket.Close();
                }
                textRx.AppendLine("[CLIENT] " + date + " > CONNESSIONE CHIUSA CON SUCCESSO.");
            }
            #endregion
        }
    }

    public static class WinFormsExtension {
        #region Funzione AppendLine per TextBox
        // Estensione per aggiungere una riga a una TextBox
        public static void AppendLine(this TextBox source, string value) {
            if (source.Text.Length == 0) {
                source.Text = value;
            }
            else {
                source.AppendText("\r\n" + value);
            }
        }
        #endregion
    }
}
