using System;
using System.Runtime.InteropServices;

namespace Win32.COM;

public static partial class Interfaces
{
    [ComImport]
    [Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInspectable
    {
        public void GetIids();
        public int GetRuntimeClassName([Out, MarshalAs(UnmanagedType.HString)] out string name);
        public void GetTrustLevel();
    }

    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        public void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }
}
