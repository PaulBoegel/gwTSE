using System;
using System.Windows.Forms;

namespace gwtseTEST
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void btnTransact_Click(object sender, EventArgs e)
        {
            if (rtbTransaction.TextLength != 0)
                this.Close();
        }
    }
}