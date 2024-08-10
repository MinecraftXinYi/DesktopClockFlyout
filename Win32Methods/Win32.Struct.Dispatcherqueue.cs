using System.Runtime.InteropServices;
using Win32.Enums;

namespace Win32.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct DispatcherQueueOptions
{
    public int dwSize;

    [MarshalAs(UnmanagedType.I4)]
    public DISPATCHERQUEUE_THREAD_TYPE threadType;

    [MarshalAs(UnmanagedType.I4)]
    public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
};
