namespace tcp_serwer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rData = new System.Windows.Forms.TextBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bntStart = new System.Windows.Forms.Button();
            this.bntSend = new System.Windows.Forms.Button();
            this.clientIP = new System.Windows.Forms.ListBox();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rData
            // 
            this.rData.Enabled = false;
            this.rData.Location = new System.Drawing.Point(41, 73);
            this.rData.Multiline = true;
            this.rData.Name = "rData";
            this.rData.Size = new System.Drawing.Size(415, 241);
            this.rData.TabIndex = 0;
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(41, 22);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(153, 23);
            this.serverIP.TabIndex = 1;
            this.serverIP.Text = "192.168.2.120:9000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serwer IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recived data";
            // 
            // bntStart
            // 
            this.bntStart.Location = new System.Drawing.Point(381, 374);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(75, 23);
            this.bntStart.TabIndex = 4;
            this.bntStart.Text = "Start";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // bntSend
            // 
            this.bntSend.Enabled = false;
            this.bntSend.Location = new System.Drawing.Point(300, 374);
            this.bntSend.Name = "bntSend";
            this.bntSend.Size = new System.Drawing.Size(75, 23);
            this.bntSend.TabIndex = 5;
            this.bntSend.Text = "Send";
            this.bntSend.UseVisualStyleBackColor = true;
            this.bntSend.Click += new System.EventHandler(this.bntSend_Click);
            // 
            // clientIP
            // 
            this.clientIP.FormattingEnabled = true;
            this.clientIP.ItemHeight = 15;
            this.clientIP.Location = new System.Drawing.Point(487, 73);
            this.clientIP.Name = "clientIP";
            this.clientIP.Size = new System.Drawing.Size(257, 244);
            this.clientIP.TabIndex = 6;
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(41, 334);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(415, 23);
            this.msgBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Message";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(219, 374);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.clientIP);
            this.Controls.Add(this.bntSend);
            this.Controls.Add(this.bntStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.rData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox rData;
        private TextBox serverIP;
        private Label label1;
        private Label label2;
        private Button bntStart;
        private Button bntSend;
        private ListBox clientIP;
        private TextBox msgBox;
        private Label label3;
        private Button btnStop;
    }
}