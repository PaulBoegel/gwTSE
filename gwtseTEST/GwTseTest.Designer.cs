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
            this.btnLanTse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnSelectTse = new System.Windows.Forms.Button();
            this.btnSetTime = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnDecommission = new System.Windows.Forms.Button();
            this.btnSelfTest = new System.Windows.Forms.Button();
            this.btnFactoryReset = new System.Windows.Forms.Button();
            this.btnTransactionStart = new System.Windows.Forms.Button();
            this.btnTransactionUpdate = new System.Windows.Forms.Button();
            this.btnTransactionFinish = new System.Windows.Forms.Button();
            this.btnReadStore = new System.Windows.Forms.Button();
            this.btnDisplayData = new System.Windows.Forms.Button();
            this.btnExportTar = new System.Windows.Forms.Button();
            this.exportProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnLanTse
            // 
            this.btnLanTse.Location = new System.Drawing.Point(31, 12);
            this.btnLanTse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLanTse.Name = "btnLanTse";
            this.btnLanTse.Size = new System.Drawing.Size(139, 43);
            this.btnLanTse.TabIndex = 0;
            this.btnLanTse.Text = "TSE LAN Connect";
            this.btnLanTse.UseVisualStyleBackColor = true;
            this.btnLanTse.Click += new System.EventHandler(this.btnLanTse_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 662);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Result";
            // 
            // tbResult
            // 
            this.tbResult.Enabled = false;
            this.tbResult.Location = new System.Drawing.Point(119, 658);
            this.tbResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(222, 23);
            this.tbResult.TabIndex = 0;
            // 
            // btnSelectTse
            // 
            this.btnSelectTse.Enabled = false;
            this.btnSelectTse.Location = new System.Drawing.Point(202, 12);
            this.btnSelectTse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectTse.Name = "btnSelectTse";
            this.btnSelectTse.Size = new System.Drawing.Size(139, 43);
            this.btnSelectTse.TabIndex = 2;
            this.btnSelectTse.Text = "TSE Select";
            this.btnSelectTse.UseVisualStyleBackColor = true;
            this.btnSelectTse.Click += new System.EventHandler(this.btnSelectTSE_Click);
            // 
            // btnSetTime
            // 
            this.btnSetTime.Enabled = false;
            this.btnSetTime.Location = new System.Drawing.Point(202, 400);
            this.btnSetTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(139, 43);
            this.btnSetTime.TabIndex = 3;
            this.btnSetTime.Text = "Set Time";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Enabled = false;
            this.btnSetup.Location = new System.Drawing.Point(202, 61);
            this.btnSetup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(139, 43);
            this.btnSetup.TabIndex = 4;
            this.btnSetup.Text = "TSE Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnDecommission
            // 
            this.btnDecommission.Enabled = false;
            this.btnDecommission.Location = new System.Drawing.Point(202, 547);
            this.btnDecommission.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDecommission.Name = "btnDecommission";
            this.btnDecommission.Size = new System.Drawing.Size(139, 43);
            this.btnDecommission.TabIndex = 5;
            this.btnDecommission.Text = "TSE Decommission";
            this.btnDecommission.UseVisualStyleBackColor = true;
            this.btnDecommission.Click += new System.EventHandler(this.btnDecommission_Click);
            // 
            // btnSelfTest
            // 
            this.btnSelfTest.Enabled = false;
            this.btnSelfTest.Location = new System.Drawing.Point(202, 449);
            this.btnSelfTest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelfTest.Name = "btnSelfTest";
            this.btnSelfTest.Size = new System.Drawing.Size(139, 43);
            this.btnSelfTest.TabIndex = 6;
            this.btnSelfTest.Text = "Self Test";
            this.btnSelfTest.UseVisualStyleBackColor = true;
            this.btnSelfTest.Click += new System.EventHandler(this.btnSelfTest_Click);
            // 
            // btnFactoryReset
            // 
            this.btnFactoryReset.Enabled = false;
            this.btnFactoryReset.Location = new System.Drawing.Point(202, 498);
            this.btnFactoryReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFactoryReset.Name = "btnFactoryReset";
            this.btnFactoryReset.Size = new System.Drawing.Size(139, 43);
            this.btnFactoryReset.TabIndex = 7;
            this.btnFactoryReset.Text = "TSE Factory Reset";
            this.btnFactoryReset.UseVisualStyleBackColor = true;
            this.btnFactoryReset.Click += new System.EventHandler(this.btnFactoryReset_Click);
            // 
            // btnTransactionStart
            // 
            this.btnTransactionStart.Enabled = false;
            this.btnTransactionStart.Location = new System.Drawing.Point(202, 147);
            this.btnTransactionStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTransactionStart.Name = "btnTransactionStart";
            this.btnTransactionStart.Size = new System.Drawing.Size(139, 43);
            this.btnTransactionStart.TabIndex = 8;
            this.btnTransactionStart.Text = "Transaction Start";
            this.btnTransactionStart.UseVisualStyleBackColor = true;
            this.btnTransactionStart.Click += new System.EventHandler(this.btnTransactionStart_Click);
            // 
            // btnTransactionUpdate
            // 
            this.btnTransactionUpdate.Enabled = false;
            this.btnTransactionUpdate.Location = new System.Drawing.Point(202, 196);
            this.btnTransactionUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTransactionUpdate.Name = "btnTransactionUpdate";
            this.btnTransactionUpdate.Size = new System.Drawing.Size(139, 43);
            this.btnTransactionUpdate.TabIndex = 9;
            this.btnTransactionUpdate.Text = "Transaction Update";
            this.btnTransactionUpdate.UseVisualStyleBackColor = true;
            this.btnTransactionUpdate.Click += new System.EventHandler(this.btnTransactionUpdate_Click);
            // 
            // btnTransactionFinish
            // 
            this.btnTransactionFinish.Enabled = false;
            this.btnTransactionFinish.Location = new System.Drawing.Point(202, 247);
            this.btnTransactionFinish.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTransactionFinish.Name = "btnTransactionFinish";
            this.btnTransactionFinish.Size = new System.Drawing.Size(139, 43);
            this.btnTransactionFinish.TabIndex = 10;
            this.btnTransactionFinish.Text = "Transaction Finish";
            this.btnTransactionFinish.UseVisualStyleBackColor = true;
            this.btnTransactionFinish.Click += new System.EventHandler(this.btnTransactionFinish_Click);
            // 
            // btnReadStore
            // 
            this.btnReadStore.Enabled = false;
            this.btnReadStore.Location = new System.Drawing.Point(31, 147);
            this.btnReadStore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadStore.Name = "btnReadStore";
            this.btnReadStore.Size = new System.Drawing.Size(139, 43);
            this.btnReadStore.TabIndex = 11;
            this.btnReadStore.Text = "Read Store";
            this.btnReadStore.UseVisualStyleBackColor = true;
            this.btnReadStore.Click += new System.EventHandler(this.btnReadStore_Click);
            // 
            // btnDisplayData
            // 
            this.btnDisplayData.Enabled = false;
            this.btnDisplayData.Location = new System.Drawing.Point(31, 196);
            this.btnDisplayData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisplayData.Name = "btnDisplayData";
            this.btnDisplayData.Size = new System.Drawing.Size(139, 43);
            this.btnDisplayData.TabIndex = 12;
            this.btnDisplayData.Text = "Display Store Data";
            this.btnDisplayData.UseVisualStyleBackColor = true;
            this.btnDisplayData.Click += new System.EventHandler(this.btnDisplayData_Click);
            // 
            // btnExportTar
            // 
            this.btnExportTar.Enabled = false;
            this.btnExportTar.Location = new System.Drawing.Point(202, 321);
            this.btnExportTar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportTar.Name = "btnExportTar";
            this.btnExportTar.Size = new System.Drawing.Size(139, 43);
            this.btnExportTar.TabIndex = 13;
            this.btnExportTar.Text = "Export TAR";
            this.btnExportTar.UseVisualStyleBackColor = true;
            this.btnExportTar.Click += new System.EventHandler(this.btnExportTar_Click);
            // 
            // exportProgress
            // 
            this.exportProgress.Location = new System.Drawing.Point(33, 616);
            this.exportProgress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exportProgress.Name = "exportProgress";
            this.exportProgress.Size = new System.Drawing.Size(308, 24);
            this.exportProgress.TabIndex = 14;
            this.exportProgress.Visible = false;
            // 
            // GwTseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 693);
            this.Controls.Add(this.exportProgress);
            this.Controls.Add(this.btnExportTar);
            this.Controls.Add(this.btnDisplayData);
            this.Controls.Add(this.btnReadStore);
            this.Controls.Add(this.btnTransactionFinish);
            this.Controls.Add(this.btnTransactionUpdate);
            this.Controls.Add(this.btnTransactionStart);
            this.Controls.Add(this.btnFactoryReset);
            this.Controls.Add(this.btnSelfTest);
            this.Controls.Add(this.btnDecommission);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.btnSelectTse);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLanTse);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GwTseTest";
            this.Text = "GW TSE Test";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectTse;
        private System.Windows.Forms.Button btnLanTse;
        private System.Windows.Forms.Button btnSetTime;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnDecommission;
        private System.Windows.Forms.Button btnSelfTest;
        private System.Windows.Forms.Button btnFactoryReset;
        private System.Windows.Forms.Button btnTransactionStart;
        private System.Windows.Forms.Button btnTransactionUpdate;
        private System.Windows.Forms.Button btnTransactionFinish;
        private System.Windows.Forms.Button btnReadStore;
        private System.Windows.Forms.Button btnDisplayData;
        private System.Windows.Forms.Button btnExportTar;
        private System.Windows.Forms.ProgressBar exportProgress;
    }
}