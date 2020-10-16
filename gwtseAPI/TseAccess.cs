using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace gwtseAPI
{
    public class TseAccess
    {
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_init_lan(out IntPtr tse_context, string url, string apiToken);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_init(out IntPtr worm_context, string mountPoint);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_cleanup(IntPtr worm_context);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_lantse_listConnectedTses(IntPtr tse_context, int toSkip, out TseSerialNumberList serialNumbers);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_lantse_select(IntPtr tse_context, byte[] serialNumber, int serialNumberLen);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_tse_updateTime(IntPtr worm_context, UInt64 timestamp);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_user_login(IntPtr worm_context, TseUserId id, byte[] pin, int pinLength, IntPtr remainingRetries);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_tse_decommission(IntPtr context);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_tse_setup(IntPtr context, byte[] credentialSeed, int credentialSeedLength,
            byte[] adminPuk, int adminPukLength, byte[] adminPin, int adminPinLength,
            byte[] timeAdminPin, int timeAdminPinLength, string clientId);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_tse_runSelfTest(IntPtr context, string clientId);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_tse_factoryReset(IntPtr context);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_transaction_start(IntPtr context, string clientId, byte[] processData, UInt64 processDataLength,
            string processType, IntPtr response);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_transaction_update(IntPtr context, string clientId, UInt64 transactionNumber,
            byte[] processData, UInt64 processDataLength, string processType, IntPtr response);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_transaction_finish(IntPtr context, string clientId, UInt64 transactionNumber,
            byte[] processData, UInt64 processDataLength, string processType, IntPtr response);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_export_tar(IntPtr context, WormExportTarCallback callback, IntPtr callbackData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int WormExportTarCallback(IntPtr chunk, uint chunkLength, IntPtr callbackData);
        
        public struct TseSerialNumberList {
            public int amount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
            public byte[] serialNumbers;
        }
        
        public enum TseUserId
        {
            Unauthenticated = 0,
            Admin = 1,
            TimeAdmin = 2
        }
        
        internal IntPtr tse_context;
        private TseInfo info;
        private bool alreadyDisposed = false;

        public TseAccess(char driveletter)
        {
            string mountPoint = driveletter + ":";
            int err = worm_init(out tse_context, mountPoint);
            if (err != 0)
            {
                throw new Exception("Failed to initialize: " + err);
            }
            info = new TseInfo(tse_context);
        }

        public TseAccess(string ip, string port, string apiToken)
        {
            string url = ip + ":" + port;
            int err = worm_init_lan(out tse_context, url, apiToken);
            if (err != 0)
            {
                throw new Exception("Failed to initialize: " + err);
            }
        }

        public void SelectTse()
        {
            TseSerialNumberList serialNumbers;
            
            int err = worm_lantse_listConnectedTses(tse_context, 0, out serialNumbers);
            if (err != 0)
            {
                throw new Exception("Failed to list connected TSEs: " + err);
            }

            if (serialNumbers.amount == 0)
            {
                throw new Exception("No TSE available on LAN TSE.");
            }

            // The serialNumbers.serialNumbers variable is a flattened representation of a
            // two dimensional byte array. Each entry is 32 bytes big and can be parsed by
            // skipping to the correct offset and then taking the next 32 bytes.
            //byte[] serialNumber = serialNumbers.serialNumbers.Skip(0).Take(32).ToArray();
            byte[] serialNumber = serialNumbers.serialNumbers.Skip(0 * 32).Take(32).ToArray();
            worm_lantse_select(tse_context, serialNumber, serialNumber.Length);

            // Update currently in use info object to the now selected TSE.
            info = new TseInfo(tse_context);
        }
        
        public TseInfo Info()
        {
            info.Refresh();
            return info;
        }
        
        #region IDisposable Support

        protected virtual void Dispose(bool disposeManagedObjects)
        {
            if (alreadyDisposed)
            {
                return;
            }

            if (disposeManagedObjects)
            {
                info = null;
            }

            if (tse_context != IntPtr.Zero)
            {
                worm_cleanup(tse_context);
                tse_context = IntPtr.Zero;
            }
            alreadyDisposed = true;
        }

        ~TseAccess() {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public void SetTime(ulong timestamp)
        {
            UInt64 testDate = info.getCertificationExpireDate();
            int result = worm_tse_updateTime(tse_context, testDate - 86400);
            if (result != 0)
            {
                throw new Exception("Failed to set time, error: " + result);
            }
        }

        public void Login(TseUserId id, byte[] PIN)
        {
            int result = worm_user_login(tse_context, id, PIN, PIN.Length, IntPtr.Zero);
            if (result != 0)
            {
                throw new Exception("Failed to log in, error: " + result);
            }
        }

        public void TseRunSelfTest(string clientId)
        {
            int result = worm_tse_runSelfTest(tse_context, clientId);
            if (result != 0)
            {
                throw new Exception("Failed to run self test, error: " + result);
            }
        }

        public void TseSetup(byte[] credentialSeed, byte[] adminPuk, byte[] adminPin, byte[] timeAdminPin, string clientId)
        {
            int result = worm_tse_setup(tse_context, credentialSeed, credentialSeed.Length,
                            adminPuk, adminPuk.Length, adminPin, adminPin.Length, timeAdminPin, timeAdminPin.Length,
                            clientId);
            if (result != 0)
            {
                throw new Exception("Failed to setup, error: " + result);
            }
        }

        public void TseDecommission()
        {
            int result = worm_tse_decommission(tse_context);
            if (result != 0)
            {
                throw new Exception("Failed to decommission, error: " + result);
            }
        }

        public void TseFactoryReset()
        {
            int result = worm_tse_factoryReset(tse_context);
            if (result != 0)
            {
                throw new Exception("Failed to reset, error: " + result);
            }
        }

        public TseTransactionResponse TransactionStart(string clientId, byte[] processData, string processType)
        {
            TseTransactionResponse rsp = new TseTransactionResponse(tse_context);
            int result = worm_transaction_start(tse_context, clientId, processData, (UInt64) processData.Length, processType, rsp.ptr);
            if (result != 0)
            {
                throw new Exception("Failed to start transaction, error: " + result);
            }
            return rsp;
        }

        public TseTransactionResponse TransactionUpdate(string clientId, ulong transactionNumber, byte[] processData, string processType)
        {
            TseTransactionResponse rsp = new TseTransactionResponse(tse_context);
            int result = worm_transaction_update(tse_context, clientId, transactionNumber, processData, (UInt64)processData.Length, processType, rsp.ptr);
            if (result != 0)
            {
                throw new Exception("Failed to update transaction, error: " + result);
            }
            return rsp;
        }

        public TseTransactionResponse TransactionFinish(string clientId, ulong transactionNumber, byte[] processData, string processType)
        {
            TseTransactionResponse rsp = new TseTransactionResponse(tse_context);
            int result = worm_transaction_finish(tse_context, clientId, transactionNumber, processData, (UInt64)processData.Length, processType, rsp.ptr);
            if (result != 0)
            {
                throw new Exception("Failed to finish transaction, error: " + result);
            }
            return rsp;
        }

        public List<TseEntry> ExportTseStore()
        {
            List<TseEntry> list = new List<TseEntry>();
            for (TseEntry entry = TseEntry.first(this); entry != null; entry = entry.next())
            {
                list.Add(entry);
            }
            return list;
        }

        public void ExportTar(WormExportTarCallback callback)
        {
            int result = worm_export_tar(tse_context, callback, IntPtr.Zero);
            if (result != 0)
            {
                throw new Exception("Failed to export, error: " + result);
            }
        }
    }
}