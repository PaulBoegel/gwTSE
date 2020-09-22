using System;
using System.Runtime.InteropServices;

namespace gwtseAPI
{
    public class TseInfo
    {
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr worm_info_new(IntPtr worm_context);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void worm_info_free(IntPtr info);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_info_read(IntPtr info);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 worm_info_size(IntPtr info);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt64 worm_info_tarExportSize(IntPtr info);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_info_isStoreOpen(IntPtr info);
        
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
       
        private static extern UInt64 worm_info_certificateExpirationDate(IntPtr info);

        enum WormInitializationState
        {
            Uninitialized = 0,
            Initialized = 1,
            Decommissioned = 2
        }

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern WormInitializationState worm_info_initializationState(IntPtr info);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_info_hasPassedSelfTest(IntPtr info);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_info_isErsInterfaceActive(IntPtr info);

        private IntPtr info;

        public TseInfo(IntPtr worm_context)
        {
            info = worm_info_new(worm_context);
            if (info == null)
            {
                throw new Exception("Failed to allocate WormInfo");
            }
            Refresh();
        }

        ~TseInfo()
        {
            worm_info_free(info);
        }

        public void Refresh()
        {
            if (worm_info_read(info) != 0)
            {
                throw new Exception("Failed to read WormInfo");
            }
        }

        public UInt64 getCertificationExpireDate()
        {
            return worm_info_certificateExpirationDate(info);
//            UInt64 seconds = worm_info_certificateExpirationDate(info);
//            DateTime date = new DateTime(1970,1,1,0,0,0,0, DateTimeKind.Utc);
//            date = date.AddSeconds(seconds).ToLocalTime();
//            return date;
        }

        public UInt32 Size()
        {
            return worm_info_size(info);
        }

        public UInt64 tarExportSize()
        {
            return worm_info_tarExportSize(info);
        }

        public bool IsInitialized()
        {
            return worm_info_initializationState(info) == WormInitializationState.Initialized;
        }

        public bool IsDecommisioned()
        {
            return worm_info_initializationState(info) == WormInitializationState.Decommissioned;
        }

        public bool HasValidTime()
        {
            return worm_info_isStoreOpen(info) != 0;
        }

        public bool HasPassedSelftest()
        {
            return worm_info_hasPassedSelfTest(info) != 0;
        }

        public bool IsErsInterfaceActive() {
            return worm_info_isErsInterfaceActive(info) != 0;
        }
    }
}