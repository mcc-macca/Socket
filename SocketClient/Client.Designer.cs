namespace SocketClient {
    partial class Client {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.comboIpClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textIpServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textInvio = new System.Windows.Forms.TextBox();
            this.btnInvia = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textRx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Client:";
            // 
            // comboIpClient
            // 
            this.comboIpClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIpClient.FormattingEnabled = true;
            this.comboIpClient.Location = new System.Drawing.Point(96, 10);
            this.comboIpClient.Name = "comboIpClient";
            this.comboIpClient.Size = new System.Drawing.Size(162, 24);
            this.comboIpClient.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP Server:";
            // 
            // textIpServer
            // 
            this.textIpServer.Location = new System.Drawing.Point(96, 40);
            this.textIpServer.Name = "textIpServer";
            this.textIpServer.Size = new System.Drawing.Size(162, 22);
            this.textIpServer.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Porta:";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(96, 73);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(162, 22);
            this.numPort.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Messaggio:";
            // 
            // textInvio
            // 
            this.textInvio.Location = new System.Drawing.Point(268, 40);
            this.textInvio.Name = "textInvio";
            this.textInvio.Size = new System.Drawing.Size(520, 22);
            this.textInvio.TabIndex = 7;
            // 
            // btnInvia
            // 
            this.btnInvia.Location = new System.Drawing.Point(712, 69);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(75, 23);
            this.btnInvia.TabIndex = 8;
            this.btnInvia.Text = "Invia";
            this.btnInvia.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Risposta del server:";
            // 
            // textRx
            // 
            this.textRx.Location = new System.Drawing.Point(19, 138);
            this.textRx.Multiline = true;
            this.textRx.Name = "textRx";
            this.textRx.ReadOnly = true;
            this.textRx.Size = new System.Drawing.Size(768, 300);
            this.textRx.TabIndex = 10;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textRx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInvia);
            this.Controls.Add(this.textInvio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textIpServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboIpClient);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Socket Client";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboIpClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textIpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textInvio;
        private System.Windows.Forms.Button btnInvia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRx;
    }
}

