using System;
using System.Runtime.InteropServices;

namespace gwtseAPI
{
    public class TseTransactionResponse
    {
        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr worm_transaction_response_new(IntPtr worm_context);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void worm_transaction_response_free(IntPtr rsp);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt64 worm_transaction_response_logTime(IntPtr rsp);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void worm_transaction_response_serialNumber(IntPtr rsp, out IntPtr serial, out UInt64 serialLength);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt64 worm_transaction_response_signatureCounter(IntPtr rsp);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void worm_transaction_response_signature(IntPtr rsp, out IntPtr signature, out UInt64 signatureLength);

        [DllImport("WormAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt64 worm_transaction_response_transactionNumber(IntPtr rsp);

        public IntPtr ptr;

        public TseTransactionResponse(IntPtr worm_context)
        {
            ptr = worm_transaction_response_new(worm_context);
            if (ptr == null)
            {
                throw new Exception("Failed to allocate WormTransactionResponse");
            }
        }

        ~TseTransactionResponse()
        {
            worm_transaction_response_free(ptr);
        }

        public UInt64 LogTime()
        {
            return worm_transaction_response_logTime(ptr);
        }

        public byte[] SerialNumber()
        {
            UInt64 serialLength;
            IntPtr serial;
            worm_transaction_response_serialNumber(ptr, out serial, out serialLength);
            byte[] s = new byte[serialLength];
            Marshal.Copy(serial, s, 0, (Int32)serialLength);
            return s;
        }

        public UInt64 SignatureCounter()
        {
            return worm_transaction_response_signatureCounter(ptr);
        }

        public byte[] Signature()
        {
            UInt64 signatureLength;
            IntPtr signature;
            worm_transaction_response_signature(ptr, out signature, out signatureLength);
            byte[] s = new byte[signatureLength];
            Marshal.Copy(signature, s, 0, (Int32)signatureLength);
            return s;
        }

        public UInt64 TransactionNumber()
        {
            return worm_transaction_response_transactionNumber(ptr);
        }
    }
}