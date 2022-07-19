using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using BattlefieldRichPresence.Resources;

namespace BattlefieldRichPresence.GameReader
{
    internal class Memory
    {
        private static IntPtr _processHandle;
        private static long _processBaseAddress;

        public static bool Initialize()
        {
            var pArray = Process.GetProcessesByName(Statics.ShortGameName[Statics.Game.Bf1]);
            if (pArray.Length > 0)
            {
                var process = pArray[0];
                _processHandle = OpenProcess(ProcessAccessFlags.VirtualMemoryRead, false, process.Id);
                if (process.MainModule != null)
                {
                    _processBaseAddress = process.MainModule.BaseAddress.ToInt64();
                    return true;
                }

                return false;
            }

            return false;
        }

        public static void CloseHandle()
        {
            if (_processHandle != IntPtr.Zero)
                CloseHandle(_processHandle);
        }

        public static long GetBaseAddress()
        {
            return _processBaseAddress;
        }

        private static long GetPtrAddress(long pointer, int[] offset)
        {
            if (offset != null)
            {
                byte[] buffer = new byte[8];
                ReadProcessMemory(_processHandle, pointer, buffer, buffer.Length, out _);

                for (int i = 0; i < (offset.Length - 1); i++)
                {
                    pointer = BitConverter.ToInt64(buffer, 0) + offset[i];
                    ReadProcessMemory(_processHandle, pointer, buffer, buffer.Length, out _);
                }

                pointer = BitConverter.ToInt64(buffer, 0) + offset[offset.Length - 1];
            }

            return pointer;
        }

        public static T Read<T>(long basePtr, int[] offsets) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            ReadProcessMemory(_processHandle, GetPtrAddress(basePtr, offsets), buffer, buffer.Length, out _);
            return ByteArrayToStructure<T>(buffer);
        }

        public static T Read<T>(long address) where T : struct
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            ReadProcessMemory(_processHandle, address, buffer, buffer.Length, out _);
            return ByteArrayToStructure<T>(buffer);
        }

        public static string ReadString(long address, int size)
        {
            byte[] processMemoryBuffer = new byte[size];
            ReadProcessMemory(_processHandle, address, processMemoryBuffer, size, out _);

            for (int i = 0; i < processMemoryBuffer.Length; i++)
            {
                if (processMemoryBuffer[i] == 0)
                {
                    byte[] blockBuffer = new byte[i];
                    Buffer.BlockCopy(processMemoryBuffer, 0, blockBuffer, 0, i);
                    return Encoding.ASCII.GetString(blockBuffer);
                }
            }

            return Encoding.ASCII.GetString(processMemoryBuffer);
        }

        public static string ReadString(long basePtr, int[] offsets, int size)
        {
            byte[] processMemoryBuffer = new byte[size];
            ReadProcessMemory(_processHandle, GetPtrAddress(basePtr, offsets), processMemoryBuffer, size, out _);

            for (int i = 0; i < processMemoryBuffer.Length; i++)
            {
                if (processMemoryBuffer[i] == 0)
                {
                    byte[] blockBuffer = new byte[i];
                    Buffer.BlockCopy(processMemoryBuffer, 0, blockBuffer, 0, i);
                    return Encoding.ASCII.GetString(blockBuffer);
                }
            }

            return Encoding.ASCII.GetString(processMemoryBuffer);
        }

        public static bool IsValid(long address)
        {
            return address >= 0x10000 && address < 0x000F000000000000;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                var obj = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                if (obj != null)
                    return (T)obj;
                else
                    return default(T);
            }
            finally
            {
                handle.Free();
            }
        }




        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, [In, Out] byte[] lpBuffer, int nsize, out IntPtr lpNumberOfBytesRead);
    }
}
