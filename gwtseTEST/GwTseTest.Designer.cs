using System.ComponentModel;

namespace gwtseTEST
{
    partial class GwTseTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.button1.Location = new System.Drawing.Point(31, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "LAN TSE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLanTse_Click);
            this.label1.Location = new System.Drawing.Point(31, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Result";
            this.tbResult.Enabled = false;
            this.tbResult.Location = new System.Drawing.Point(119, 468);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(789, 23);
            this.tbResult.TabIndex = 0;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 519);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "GwTseTestForm";
            this.Text = "GW TSE Test";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label1;
    }
}