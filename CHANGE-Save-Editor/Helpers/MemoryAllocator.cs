using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CHANGE_Save_Editor.Helpers
{
    class MemoryAllocator : IDisposable
    {
        private List<GCHandle> handles = new List<GCHandle>();

        public IntPtr GetInt(int value)
        {
            GCHandle handle = GCHandle.Alloc(value, GCHandleType.Pinned);
            handles.Add(handle);
            return handle.AddrOfPinnedObject();
        }

        public IntPtr GetLong(long value)
        {
            GCHandle handle = GCHandle.Alloc(value, GCHandleType.Pinned);
            handles.Add(handle);
            return handle.AddrOfPinnedObject();
        }

        public IntPtr GetByteArray(byte[] arr)
        {
            GCHandle handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            handles.Add(handle);
            return handle.AddrOfPinnedObject();
        }

        public void Dispose()
        {
            handles.ForEach(handle => handle.Free());
        }
    }
}
