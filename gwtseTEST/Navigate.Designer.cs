using System.ComponentModel;

namespace gwtseTEST
{
    partial class Navigate
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listTransactionNumbers = new System.Windows.Forms.ListBox();
            this.boxProcessData = new System.Windows.Forms.RichTextBox();
            this.boxLogMessage = new System.Windows.Forms.RichTextBox();
            this.radAscii = new System.Windows.Forms.RadioButton();
            this.radHex = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNumberOfTranscations = new System.Windows.Forms.TextBox();
            this.tbNumberOfBlocks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbIncident = new System.Windows.Forms.CheckBox();
            this.tbPayloadLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBlocks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Number";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(189, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Process Data";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(484, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Log Message";
            // 
            // listTransactionNumbers
            // 
            this.listTransactionNumbers.FormattingEnabled = true;
            this.listTransactionNumbers.ItemHeight = 15;
            this.listTransactionNumbers.Location = new System.Drawing.Point(12, 68);
            this.listTransactionNumbers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listTransactionNumbers.Name = "listTransactionNumbers";
            this.listTransactionNumbers.Size = new System.Drawing.Size(163, 349);
            this.listTransactionNumbers.TabIndex = 3;
            this.listTransactionNumbers.SelectedIndexChanged +=
                new System.EventHandler(this.listTransactionNumber_SelectedIndexChanged);
            // 
            // boxProcessData
            // 
            this.boxProcessData.Location = new System.Drawing.Point(189, 68);
            this.boxProcessData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.boxProcessData.Name = "boxProcessData";
            this.boxProcessData.Size = new System.Drawing.Size(282, 348);
            this.boxProcessData.TabIndex = 4;
            this.boxProcessData.Text = "";
            // 
            // boxLogMessage
            // 
            this.boxLogMessage.Location = new System.Drawing.Point(484, 69);
            this.boxLogMessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.boxLogMessage.Name = "boxLogMessage";
            this.boxLogMessage.Size = new System.Drawing.Size(282, 348);
            this.boxLogMessage.TabIndex = 5;
            this.boxLogMessage.Text = "";
            // 
            // radAscii
            // 
            this.radAscii.Checked = true;
            this.radAscii.Location = new System.Drawing.Point(600, 40);
            this.radAscii.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radAscii.Name = "radAscii";
            this.radAscii.Size = new System.Drawing.Size(61, 23);
            this.radAscii.TabIndex = 6;
            this.radAscii.TabStop = true;
            this.radAscii.Text = "ASCII";
            this.radAscii.UseVisualStyleBackColor = true;
            this.radAscii.CheckedChanged += new System.EventHandler(this.radAscii_CheckedChanged);
            // 
            // radHex
            // 
            this.radHex.Location = new System.Drawing.Point(668, 40);
            this.radHex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radHex.Name = "radHex";
            this.radHex.Size = new System.Drawing.Size(83, 23);
            this.radHex.TabIndex = 7;
            this.radHex.Text = "HEX";
            this.radHex.UseVisualStyleBackColor = true;
            this.radHex.CheckedChanged += new System.EventHandler(this.radHex_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 450);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "# transactions";
            // 
            // tbNumberOfTranscations
            // 
            this.tbNumberOfTranscations.Location = new System.Drawing.Point(108, 448);
            this.tbNumberOfTranscations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNumberOfTranscations.Name = "tbNumberOfTranscations";
            this.tbNumberOfTranscations.Size = new System.Drawing.Size(137, 23);
            this.tbNumberOfTranscations.TabIndex = 9;
            // 
            // tbNumberOfBlocks
            // 
            this.tbNumberOfBlocks.Location = new System.Drawing.Point(346, 448);
            this.tbNumberOfBlocks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNumberOfBlocks.Name = "tbNumberOfBlocks";
            this.tbNumberOfBlocks.Size = new System.Drawing.Size(137, 23);
            this.tbNumberOfBlocks.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(278, 450);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "# blocks";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(668, 447);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbIncident
            // 
            this.cbIncident.Location = new System.Drawing.Point(392, 12);
            this.cbIncident.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbIncident.Name = "cbIncident";
            this.cbIncident.Size = new System.Drawing.Size(91, 20);
            this.cbIncident.TabIndex = 13;
            this.cbIncident.Text = "System Log";
            this.cbIncident.UseVisualStyleBackColor = true;
            // 
            // tbPayloadLength
            // 
            this.tbPayloadLength.Location = new System.Drawing.Point(545, 10);
            this.tbPayloadLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbPayloadLength.Name = "tbPayloadLength";
            this.tbPayloadLength.Size = new System.Drawing.Size(76, 23);
            this.tbPayloadLength.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(489, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Length";
            // 
            // tbBlocks
            // 
            this.tbBlocks.Location = new System.Drawing.Point(685, 10);
            this.tbBlocks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBlocks.Name = "tbBlocks";
            this.tbBlocks.Size = new System.Drawing.Size(76, 23);
            this.tbBlocks.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(629, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "# Blocks";
            // 
            // Navigate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 494);
            this.Controls.Add(this.tbBlocks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPayloadLength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbIncident);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbNumberOfBlocks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNumberOfTranscations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radHex);
            this.Controls.Add(this.radAscii);
            this.Controls.Add(this.boxLogMessage);
            this.Controls.Add(this.boxProcessData);
            this.Controls.Add(this.listTransactionNumbers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Navigate";
            this.Text = "TSE Store";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radAscii;
        private System.Windows.Forms.RadioButton radHex;
        private System.Windows.Forms.RichTextBox boxProcessData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox boxLogMessage;
        private System.Windows.Forms.ListBox listTransactionNumbers;
        private System.Windows.Forms.CheckBox cbIncident;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBlocks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPayloadLength;
        public System.Windows.Forms.TextBox tbNumberOfBlocks;
        public System.Windows.Forms.TextBox tbNumberOfTranscations;
    }
}