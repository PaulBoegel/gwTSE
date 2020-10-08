using System.ComponentModel;

namespace gwtseTEST
{
    partial class Transaction
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtbTransaction = new System.Windows.Forms.RichTextBox();
            this.btnTransact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter transaction data";
            // 
            // rtbTransaction
            // 
            this.rtbTransaction.Location = new System.Drawing.Point(13, 33);
            this.rtbTransaction.Name = "rtbTransaction";
            this.rtbTransaction.Size = new System.Drawing.Size(360, 168);
            this.rtbTransaction.TabIndex = 0;
            this.rtbTransaction.Text = "";
            // 
            // btnTransact
            // 
            this.btnTransact.Location = new System.Drawing.Point(258, 208);
            this.btnTransact.Name = "btnTransact";
            this.btnTransact.Size = new System.Drawing.Size(114, 33);
            this.btnTransact.TabIndex = 1;
            this.btnTransact.Text = "Transact";
            this.btnTransact.UseVisualStyleBackColor = true;
            this.btnTransact.Click += new System.EventHandler(this.btnTransact_Click);
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 258);
            this.Controls.Add(this.btnTransact);
            this.Controls.Add(this.rtbTransaction);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Transaction";
            this.Text = "Transaction";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnTransact;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox rtbTransaction;
    }
}