using System.ComponentModel;

namespace gwtseTEST
{
    partial class LanInit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPLable = new System.Windows.Forms.Label();
            this.PortLable = new System.Windows.Forms.Label();
            this.TokenLable = new System.Windows.Forms.Label();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tbServerToken = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.IPLable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IPLable.Location = new System.Drawing.Point(12, 9);
            this.IPLable.Name = "IPLable";
            this.IPLable.Size = new System.Drawing.Size(115, 33);
            this.IPLable.TabIndex = 0;
            this.IPLable.Text = "Server IP:";
            this.PortLable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PortLable.Location = new System.Drawing.Point(12, 42);
            this.PortLable.Name = "PortLable";
            this.PortLable.Size = new System.Drawing.Size(115, 33);
            this.PortLable.TabIndex = 1;
            this.PortLable.Text = "Port:";
            this.TokenLable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TokenLable.Location = new System.Drawing.Point(12, 74);
            this.TokenLable.Name = "TokenLable";
            this.TokenLable.Size = new System.Drawing.Size(115, 33);
            this.TokenLable.TabIndex = 2;
            this.TokenLable.Text = "Token:";
            this.tbServerIp.Location = new System.Drawing.Point(118, 12);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(136, 23);
            this.tbServerIp.TabIndex = 3;
            this.tbServerIp.Text = "https://192.168.178.22";
            this.tbServerPort.Location = new System.Drawing.Point(118, 39);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(136, 23);
            this.tbServerPort.TabIndex = 4;
            this.tbServerPort.Text = "4433";
            this.tbServerToken.Location = new System.Drawing.Point(118, 68);
            this.tbServerToken.Name = "tbServerToken";
            this.tbServerToken.Size = new System.Drawing.Size(136, 23);
            this.tbServerToken.TabIndex = 5;
            this.tbServerToken.Text = "127062";
            this.button1.Location = new System.Drawing.Point(72, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 183);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbServerToken);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.tbServerIp);
            this.Controls.Add(this.TokenLable);
            this.Controls.Add(this.PortLable);
            this.Controls.Add(this.IPLable);
            this.Name = "LanInit";
            this.Text = "LanInit";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        private System.Windows.Forms.Label PortLable;
        private System.Windows.Forms.Label IPLable;
        private System.Windows.Forms.Label TokenLable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.TextBox tbServerToken;
        private System.Windows.Forms.TextBox tbServerIp;
    }
}