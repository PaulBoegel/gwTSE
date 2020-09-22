using System;
using System.Runtime.InteropServices;

namespace gwtseAPI
{
    public class TseAccess
    {
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int worm_init_lan(out IntPtr worm_context, string url, string apiToken);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_cleanup(IntPtr worm_context);
        
        internal IntPtr worm_context;
        private TseInfo info;
        private bool alreadyDisposed = false;
        
        public TseAccess(string ip, string port, string apiToken)
        {
            string url = ip + ":" + port;
            int err = worm_init_lan(out worm_context, url, apiToken);
            if (err != 0)
            {
                throw new Exception("Failed to initialize: " + err);
            }
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

            if (worm_context != IntPtr.Zero)
            {
                worm_cleanup(worm_context);
                worm_context = IntPtr.Zero;
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
    }
}