using System;
using System.Collections.Generic;
using System.Windows.Forms;
using gwtseAPI;

namespace gwtseTEST
{
    public partial class GwTseTest : Form
    {
        
        private TseAccess tseAccess;
        private List<TseEntry> list = null;
        
        public GwTseTest()
        {
            InitializeComponent();
        }
        
        private void btnLanTse_Click(object sender, EventArgs e)
        {
            LanInit LI = new LanInit();
            LI.ShowDialog();
            doLanInit(LI.serverIp, LI.serverPort, LI.serverToken);
        }
        
        private void doLanInit(string serverIp, string serverPort, string serverToken)
        {
            if (tseAccess != null)
            {
                tseAccess.Dispose();
                tseAccess = null;
            }

            list = null;

            try
            {
                tseAccess = new TseAccess(serverIp, serverPort, serverToken);
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }
        }
    }
}