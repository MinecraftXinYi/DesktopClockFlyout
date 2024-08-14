using System;
using System.Runtime.InteropServices;

namespace Win32.COM;

[ComImport]
[Guid("a5cd92ff-29be-454c-8d04-d82879fb3f1b")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[System.Security.SuppressUnmanagedCodeSecurity]
public interface IVirtualDesktopManager
{
    [PreserveSig]
    public int IsWindowOnCurrentVirtualDesktop(
        [In] IntPtr TopLevelWindow,
        [Out] out int OnCurrentDesktop
        );

    [PreserveSig]
    public int GetWindowDesktopId(
        [In] IntPtr TopLevelWindow,
        [Out] out Guid CurrentDesktop
        );

    [PreserveSig]
    public int MoveWindowToDesktop(
        [In] IntPtr TopLevelWindow,
        [MarshalAs(UnmanagedType.LPStruct)]
            [In]Guid CurrentDesktop
        );
}

[ComImport]
[Guid("aa509086-5ca9-4c25-8f95-589d3c07b48a")]
public class CVirtualDesktopManager { };

public class VirtualDesktopManager
{
    private readonly IVirtualDesktopManager ivdManager;

    public VirtualDesktopManager()
    {
        CVirtualDesktopManager cvdManager = new ();
        ivdManager = (IVirtualDesktopManager)cvdManager;
    }

    public bool IsWindowOnCurrentVirtualDesktop(IntPtr hWnd)
    {
        int hr = ivdManager.IsWindowOnCurrentVirtualDesktop(hWnd, out int onCurrentDesktop);
        if (hr != 0) Marshal.ThrowExceptionForHR(hr);
        return onCurrentDesktop != 0;
    }

    public Guid GetWindowDesktopId(IntPtr hWnd)
    {
        int hr = ivdManager.GetWindowDesktopId(hWnd, out Guid vDesktopId);
        if (hr != 0) Marshal.ThrowExceptionForHR(hr);
        return vDesktopId;
    }

    public void MoveWindowToDesktop(IntPtr hWnd, Guid virtualDesktop)
    {
        int hr = ivdManager.MoveWindowToDesktop(hWnd, virtualDesktop);
        if (hr != 0) Marshal.ThrowExceptionForHR(hr);
    }
}
