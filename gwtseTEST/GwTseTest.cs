using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using gwtseAPI;

namespace gwtseTEST
{
    public partial class GwTseTest : Form
    {
        
        private TseAccess tseAccess;
        private byte[] adminPuk = Encoding.ASCII.GetBytes("123456");
        private byte[] adminPin = Encoding.ASCII.GetBytes("12345");
        private byte[] timeAdminPin = Encoding.ASCII.GetBytes("98765");
        private byte[] credentialSeed = Encoding.ASCII.GetBytes("SwissbitSwissbit");
        string CLIENT_ID = "SwissbitDemo";
        private List<TseEntry> list = null;
        bool isReadOnly = false;
        UInt32 numberofBlocks = 0;
        UInt64 startedTransactionNumber;
        
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

            btnSelectTse.Enabled = true;
        }
        private void doInit()
        {
            //pnAfterInit.Enabled = false;
            //pnManagement.Enabled = false;
            //btnSelectTse.Enabled = false;
            if (tseAccess != null)
            {
                tseAccess.Dispose();
                tseAccess = null;
            }

            list = null;

            try
            {
                tseAccess = new TseAccess(tb_driveletter.Text[0]);
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }
            updateState();
        }


        private void btnSelectTSE_Click(object sender, EventArgs e)
        {
            try
            {
                tseAccess.SelectTse();
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }

            updateState();
        }

        private void updateState()
        {
            isReadOnly = false;
            btnFactoryReset.Enabled = true;
            btnDecommission.Enabled = false;
            btnSetup.Enabled = false;
            btnSetTime.Enabled = true;
            
            bool ersActive = tseAccess.Info().IsErsInterfaceActive();
            if (tseAccess.Info().IsDecommisioned())
            {
                isReadOnly = true;
                btnSetTime.Enabled = false;
            } else if (!tseAccess.Info().IsInitialized())
            {
                btnSetup.Enabled = true;
                return;
            }
            else
            {
                btnDecommission.Enabled = ersActive;
            }
            
            btnSelfTest.Enabled = !ersActive;
            btnReadStore.Enabled = ersActive;
            btnSetTime.Enabled = !isReadOnly && ersActive;
            btnTransactionUpdate.Enabled = false;
            btnTransactionFinish.Enabled = false;
            btnTransactionStart.Enabled = !isReadOnly && ersActive && tseAccess.Info().HasValidTime();
            tbResult.Text = "OK";
            btnExportTar.Enabled = true;
            showUpdateRequired();
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            try
            {
                tseAccess.SetTime(now());
                tseAccess.Login(TseAccess.TseUserId.TimeAdmin, timeAdminPin);
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }

            updateState();
        }
        
        private UInt64 now() {
            return (UInt64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    tseAccess.TseRunSelfTest("unknown");
                }
                catch (Exception ex)
                {
                    // expected, because the client id is not known
                }
                tseAccess.TseSetup(credentialSeed, adminPuk, adminPin, timeAdminPin, CLIENT_ID);
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }

            updateState();
        }

        private void btnDecommission_Click(object sender, EventArgs e)
        {
            try
            {
                tseAccess.Login(TseAccess.TseUserId.Admin, adminPin);
                tseAccess.SetTime(now());
                tseAccess.TseDecommission();
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }
            updateState();
        }

        private void btnSelfTest_Click(object sender, EventArgs e)
        {
            try
            {
                tseAccess.TseRunSelfTest(CLIENT_ID);
            } catch (Exception ex) {
                tbResult.Text = ex.Message;
                return;
            }
            updateState();
        }
        
        private void btnFactoryReset_Click(object sender, EventArgs e)
        {
            try
            {
                tseAccess.TseFactoryReset();
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }
            btnTransactionStart.Enabled = true;
            updateState();
        }

        private void btnTransactionStart_Click(object sender, EventArgs e)
        {
            doTransaction(0);
            btnTransactionStart.Enabled = false;
        }
        
        private void btnTransactionUpdate_Click(object sender, EventArgs e)
        {
            doTransaction(1);
        }

        private void btnTransactionFinish_Click(object sender, EventArgs e)
        {
            doTransaction(2);
            btnTransactionStart.Enabled = true;
        }

        private void doTransaction(int mode)
        {
            Transaction dialog = new Transaction();
            dialog.ShowDialog();
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            TseTransactionResponse response;

            try
            {
                byte[] processData = Encoding.ASCII.GetBytes(dialog.rtbTransaction.Text);
                string processType = "Buchung";

                switch (mode)
                {
                    case 0:
                        response = tseAccess.TransactionStart(CLIENT_ID, processData, processType);
                        startedTransactionNumber = response.TransactionNumber();
                        btnTransactionUpdate.Enabled = true;
                        btnTransactionFinish.Enabled = true;
                        break;
                    case 1:
                        response = tseAccess.TransactionUpdate(CLIENT_ID, startedTransactionNumber, processData, processType);
                        break;
                    case 2:
                        response = tseAccess.TransactionFinish(CLIENT_ID, startedTransactionNumber, processData, processType);
                        btnTransactionUpdate.Enabled = false;
                        btnTransactionFinish.Enabled = false;
                        break;
                    default:
                        throw new ArgumentException("Unknown mode: " + mode);
                }
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }
            finally
            {
                stopwatch.Stop();
            }
            
            tbResult.Text = "OK";
            //showUpdateRequired();
            string s = "Transaction time " + stopwatch.ElapsedMilliseconds + " ms!"
                       + "\nTransaction Number: " + response.TransactionNumber()
                       + "\nLog Time: " + response.LogTime()
                       + "\nSignature Counter: " + response.SignatureCounter()
                       + "\nSignature: " + BitConverter.ToString(response.Signature()).Replace("-", "")
                       + "\nSerial Number: " + BitConverter.ToString(response.SerialNumber()).Replace("-", "");
            MessageBox.Show(s);
        }
        
        private void showUpdateRequired()
        {
            if (!btnReadStore.Text.EndsWith("(*)"))
                btnReadStore.Text += " (*)";
            btnDisplayData.Enabled = false;
        }
        
        private void showUpdateNotRequired()
        {
            string remove = " (*)";
            if (btnReadStore.Text.EndsWith(remove))
                btnReadStore.Text = btnReadStore.Text.Substring(0, btnReadStore.Text.LastIndexOf(remove));

            btnDisplayData.Enabled = true;
        }

        private void btnReadStore_Click(object sender, EventArgs e)
        {
            showUpdateRequired();
            try
            {
                list = tseAccess.ExportTseStore();
            } catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }

            try
            {
                numberofBlocks = tseAccess.Info().Size();
            } catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }

            tbResult.Text = "OK";
            showUpdateNotRequired();  
        }

        private void btnDisplayData_Click(object sender, EventArgs e)
        {
            if (list == null)
            {
                MessageBox.Show("Please Read WORM Store Data first");
                return;
            }
            Navigate myNavigator = new Navigate(ref list);
            
            if (numberofBlocks>0)
            {
                myNavigator.tbNumberOfBlocks.Text = numberofBlocks.ToString();
                myNavigator.tbNumberOfTranscations.Text = list.LongCount().ToString();
            }
            myNavigator.ShowDialog();
        }

        private void btnExportTar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = "tse.tar";
                saveFile.Filter = "TAR archive (*.tar)|*.tar|All files (*.*)|*.*";
                if (saveFile.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                exportProgress.Value = 0;
                exportProgress.Visible = true;
                using (FileStream stream = (System.IO.FileStream)saveFile.OpenFile())
                {
                    UInt64 exportSize = tseAccess.Info().tarExportSize();
                    UInt64 exportedSize = 0;
                    tseAccess.ExportTar((IntPtr chunk, uint chunkLength, IntPtr callbackData) =>
                    {
                        byte[] bytes = new byte[chunkLength];
                        Marshal.Copy(chunk, bytes, 0, (int)chunkLength);
                        stream.Write(bytes, 0, bytes.Length);
                        exportedSize += chunkLength;
                        exportProgress.Value = (int) (100 * exportedSize / exportSize);
                        return 0;
                    });
                }
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
                return;
            }
            finally
            {
                exportProgress.Visible = false;
            }
        }

        private void bt_localInit_Click(object sender, EventArgs e)
        {
            if (tb_driveletter.TextLength != 1)
            {
                tbResult.Text = "Init error: drive letter missing";
                return;
            }
            doInit();
        }


    }
}