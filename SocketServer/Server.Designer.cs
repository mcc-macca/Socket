namespace SocketServer {
    partial class Server {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btnControl = new Button();
            label1 = new Label();
            comboIpServer = new ComboBox();
            label2 = new Label();
            numPort = new NumericUpDown();
            textRx = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            SuspendLayout();
            // 
            // btnControl
            // 
            btnControl.Location = new Point(12, 12);
            btnControl.Name = "btnControl";
            btnControl.Size = new Size(94, 29);
            btnControl.TabIndex = 0;
            btnControl.Text = "START";
            btnControl.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 16);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 1;
            label1.Text = "IP Server:";
            // 
            // comboIpServer
            // 
            comboIpServer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIpServer.FormattingEnabled = true;
            comboIpServer.Location = new Point(187, 13);
            comboIpServer.Name = "comboIpServer";
            comboIpServer.Size = new Size(151, 28);
            comboIpServer.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 16);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 3;
            label2.Text = "Porta:";
            // 
            // numPort
            // 
            numPort.Location = new Point(396, 14);
            numPort.Name = "numPort";
            numPort.Size = new Size(150, 27);
            numPort.TabIndex = 4;
            // 
            // textRx
            // 
            textRx.Location = new Point(12, 47);
            textRx.Multiline = true;
            textRx.Name = "textRx";
            textRx.ReadOnly = true;
            textRx.Size = new Size(776, 391);
            textRx.TabIndex = 5;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textRx);
            Controls.Add(numPort);
            Controls.Add(label2);
            Controls.Add(comboIpServer);
            Controls.Add(label1);
            Controls.Add(btnControl);
            Name = "Server";
            Text = "Server";
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnControl;
        private Label label1;
        private ComboBox comboIpServer;
        private Label label2;
        private NumericUpDown numPort;
        private TextBox textRx;
    }
}
