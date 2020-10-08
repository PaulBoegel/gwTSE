using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using gwtseAPI;

namespace gwtseTEST
{
    public partial class Navigate : Form
    {
        private List<TseEntry> tseEntryList;
        public Navigate(ref List<TseEntry> TseEntryList)
        {
            InitializeComponent();
            tseEntryList = TseEntryList;
            ulong i = 0;

            foreach (TseEntry entry in tseEntryList)
            {
                string s = i.ToString() + "\t(" + entry.SizeInBlocks + ")";
                if (entry.IsSystemLog) s += "*";
                listTransactionNumbers.Items.Add(s);
                i++;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private string dataToString(byte[] data)
        {
            return Encoding.ASCII.GetString(data, 0, data.Length).Replace("\0", " ");
        }

        private void listTransactionNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            TseEntry entry = tseEntryList[listTransactionNumbers.SelectedIndex];
            cbIncident.Checked = entry.IsSystemLog;
            if (entry.IsSystemLog)
            {
                boxProcessData.Text = "<System Log>";
            } else
            {
                boxProcessData.Text = dataToString(entry.ProcessData);
            }
            tbPayloadLength.Text = entry.ProcessDataLength.ToString() + " bytes";
            tbBlocks.Text = entry.SizeInBlocks.ToString();
            displayLogMessage();
        }
        
        private void displayLogMessage()
        {
            byte[] logMessage = tseEntryList[listTransactionNumbers.SelectedIndex].LogMessage;
            if (radAscii.Checked)
            {
                boxLogMessage.Text = dataToString(logMessage);
            }
            else
            {
                boxLogMessage.Text = BitConverter.ToString(logMessage).Replace("-", "");
            }
        }
        
        private void radAscii_CheckedChanged(object sender, EventArgs e)
        {
            displayLogMessage();
        }

        private void radHex_CheckedChanged(object sender, EventArgs e)
        {
            displayLogMessage();
        }
    }
}