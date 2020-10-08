using System;
using System.Runtime.InteropServices;

namespace gwtseAPI
{
    public class TseEntry
    {
        #region NativeImports

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr worm_entry_new(IntPtr worm_context);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void worm_entry_free(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_entry_iterate_first(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_entry_iterate_next(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_entry_iterate_id(IntPtr entry, UInt32 id);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_entry_isValid(IntPtr entry);

        enum WormEntryType
        {
            Transaction = 0,
            SystemLog = 1,
            SeAuditLog = 2
        }
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern WormEntryType worm_entry_type(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt64 worm_entry_processDataLength(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_entry_readProcessData(IntPtr entry, UInt64 offset, byte[] data, UInt64 dataLength);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 worm_entry_id(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt64 worm_entry_logMessageLength(IntPtr entry);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int worm_entry_readLogMessage(IntPtr entry, byte[] data, UInt64 dataLength);

        #endregion

        public byte[] ProcessData
        {
            get
            {
                if (!IsSystemLog && ProcessDataBuffer == null)
                {
                    readProcessData();
                }
                return ProcessDataBuffer;
            }
            private set { ProcessData = value; }
        }

        public byte[] LogMessage
        {
            get
            {
                if (LogMessageBuffer == null)
                {
                    readLogMessage();
                }
                return LogMessageBuffer;
            }
        }

        public bool IsSystemLog { get; }
        
        private UInt32 id;
        public  UInt64 ProcessDataLength { get; }
        public UInt64 SizeInBlocks
        {
            get { return ProcessDataLength / 512 + 1; }
        }

        private byte[] ProcessDataBuffer;
        private byte[] LogMessageBuffer;
        private TseAccess tseAccess;

        private TseEntry(TseEntryContext context, TseAccess tseAccess)
        {
            this.tseAccess = tseAccess;
            id = worm_entry_id(context.ptr);
            IsSystemLog = worm_entry_type(context.ptr) == WormEntryType.SystemLog;
            ProcessDataLength = worm_entry_processDataLength(context.ptr);
            Console.WriteLine("Created WormEntry #" + id);
        }

        private void readProcessData()
        {
            TseEntryContext context = createWormEntryContextForId(id);
            ProcessDataBuffer = new byte[ProcessDataLength];
            int err = worm_entry_readProcessData(context.ptr, 0, ProcessDataBuffer, (UInt64)ProcessDataBuffer.Length);
            if (err != 0)
            {
                throw new Exception("Failed to read process data, error: " + err);
            }
        }

        private void readLogMessage()
        {
            TseEntryContext context = createWormEntryContextForId(id);
            LogMessageBuffer = new byte[worm_entry_logMessageLength(context.ptr)];
            int err = worm_entry_readLogMessage(context.ptr, LogMessageBuffer, (UInt64)LogMessageBuffer.Length);
            if (err != 0)
            {
                throw new Exception("Failed to read log message, error: " + err);
            }
        }

        static internal TseEntry first(TseAccess tseAccess)
        {
            TseEntryContext context = new TseEntryContext(tseAccess.tse_context);
            int err = worm_entry_iterate_first(context.ptr);
            if (err != 0)
            {
                throw new Exception("Failed to read WormEntry, error: " + err);
            }
            return worm_entry_isValid(context.ptr) != 0 ? new TseEntry(context, tseAccess) : null;
        }

        internal TseEntry next()
        {
            TseEntryContext context = createWormEntryContextForId(id);
            int err = worm_entry_iterate_next(context.ptr);
            if (err != 0)
            {
                throw new Exception("Failed to read WormEntry, error: " + err);
            }
            return worm_entry_isValid(context.ptr) != 0 ? new TseEntry(context, tseAccess) : null;
        }

        private TseEntryContext createWormEntryContextForId(UInt32 id)
        {
            TseEntryContext context = new TseEntryContext(tseAccess.tse_context);
            Console.WriteLine("creating context for " + id);
            int err = worm_entry_iterate_id(context.ptr, id);
            if (err != 0)
            {
                throw new Exception("Failed to read WormEntry, error: " + err);
            }
            if (worm_entry_isValid(context.ptr) == 0)
            {
                throw new Exception("WormEntry for id " + id + " is not valid!");
            }
            return context;
        }

        private class TseEntryContext
        {
            internal IntPtr ptr;

            internal TseEntryContext(IntPtr tseContext)
            {
                ptr = worm_entry_new(tseContext);
                if (ptr == IntPtr.Zero)
                {
                    throw new Exception("Failed to allocate WormEntry");
                }
            }

            ~TseEntryContext()
            {
                worm_entry_free(ptr);
            }
        }

    }
}