using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CHANGE_Save_Editor.Helpers
{
    class RegistryEditor : IDisposable
    {

        public static UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(0x80000002u);
        public static UIntPtr HKEY_CURRENT_USER = new UIntPtr(0x80000001u);

        private UIntPtr hKey;

        public RegistryEditor(string path)
        {
            int errCode = RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, 0x20006, out hKey);
            if (errCode != 0)
            {
                throw new Exception("Failed to open registry key.", new Win32Exception(errCode));
            }
        }

        public void SetValue(string valName, object value)
        {
            using (var allocator = new MemoryAllocator())
            {
                var type = value.GetType();
                int size;
                IntPtr pData;
                RegistryValueKind dwType;
                if (type == typeof(double))
                {
                    size = Marshal.SizeOf(typeof(long));
                    pData = allocator.GetLong(BitConverter.DoubleToInt64Bits((double)value));
                    dwType = RegistryValueKind.DWord;
                }
                else if (type == typeof(int))
                {
                    size = Marshal.SizeOf(typeof(int));
                    pData = allocator.GetInt((int)value);
                    dwType = RegistryValueKind.DWord;
                }
                else if (type == typeof(byte[]))
                {
                    size = ((byte[])value).Length;
                    pData = allocator.GetByteArray((byte[])value);
                    dwType = RegistryValueKind.Binary;
                }
                else if (type == typeof(long))
                {
                    size = Marshal.SizeOf(typeof(long));
                    pData = allocator.GetLong((long)value);
                    dwType = RegistryValueKind.DWord;
                }
                else
                {
                    throw new Exception("Unexpected type " + type);
                }
                int errCode = RegSetValueEx(hKey, valName, 0, dwType, pData, size);
                if (errCode != 0)
                    throw new Exception("Exception encountered setting registry value", new Win32Exception(errCode));
            }
        }

        public void Dispose()
        {
            if (hKey == UIntPtr.Zero)
                return;
            int errCode = RegCloseKey(hKey);
            System.Diagnostics.Debug.WriteLine("CLOSING");
            if (errCode != 0)
                throw new Exception("Failed to close registry key.");
        }

        [DllImport("advapi32.dll")]
        static extern int RegSetValueEx(
            UIntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
            int Reserved,
            RegistryValueKind dwType,
            IntPtr lpData,
            int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(
            UIntPtr hKey,
            string subKey,
            int ulOptions,
            int samDesired,
            out UIntPtr hkResult);

        [DllImport("advapi32.dll")]
        public static extern int RegCloseKey(UIntPtr hKey);

    }
}
