using System;
using System.Windows.Forms;

namespace gwtseTEST
{
    public partial class LanInit : Form
    {
        
        public string serverIp, serverPort, serverToken;
        public LanInit()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            serverIp = tbServerPort.Text;
            serverPort = tbServerPort.Text;
            serverToken = tbServerToken.Text;
            this.Close();
        }
    }
}