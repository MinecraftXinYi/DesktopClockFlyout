using System;
using System.Windows.Forms;
using Win32;
using Win32.Constants;

namespace WinDeskClockFlyout.Core;

public static class DeskWidgetFormTweak
{
    public static void RemoveBroder(IntPtr windowHandle, bool enable = true)
    {
        uint windStyle = (uint)User32Packaged.GetWindowLongPtr(windowHandle, WindowLongFlags.GWL_STYLE);
        if (enable) windStyle &= ~(WindowStyles.WS_CAPTION | WindowStyles.WS_SIZEBOX | WindowStyles.WS_BORDER);
        else windStyle |= WindowStyles.WS_CAPTION | WindowStyles.WS_SIZEBOX | WindowStyles.WS_BORDER;
        User32Packaged.SetWindowLongPtr(windowHandle, WindowLongFlags.GWL_STYLE, new IntPtr(windStyle));
        windStyle = (uint)User32Packaged.GetWindowLongPtr(windowHandle, WindowLongFlags.GWL_EXSTYLE);
        if (enable) windStyle &= ~WindowStylesEx.WS_EX_DLGMODALFRAME;
        else windStyle |= WindowStylesEx.WS_EX_DLGMODALFRAME;
        User32Packaged.SetWindowLongPtr(windowHandle, WindowLongFlags.GWL_EXSTYLE, new IntPtr(windStyle));
    }

    public static void RemoveSysMenu(IntPtr windowHandle, bool enable = true)
    {
        uint windStyle = (uint)User32Packaged.GetWindowLongPtr(windowHandle, WindowLongFlags.GWL_STYLE);
        if (enable) windStyle &= ~WindowStyles.WS_SYSMENU;
        else windStyle |= WindowStyles.WS_SYSMENU;
        User32Packaged.SetWindowLongPtr(windowHandle, WindowLongFlags.GWL_STYLE, new IntPtr(windStyle));
    }

    public static void SetWindowComposition(IntPtr windowHandle, bool enable = true)
    {
        //uint windStyle = (uint)User32Packaged.GetWindowLongPtr(windowHandle, WindowLongFlags.GWL_EXSTYLE);
        //if (enable) windStyle |= WindowStylesEx.WS_EX_TRANSPARENT;
        //else windStyle &= ~WindowStylesEx.WS_EX_TRANSPARENT;
        //User32Packaged.SetWindowLongPtr(windowHandle, WindowLongFlags.GWL_EXSTYLE, new IntPtr(windStyle));
    }

    public static void SetDesktopWidgetFormZ(IntPtr windowHandle)
    {
        IntPtr hShellDesktopParent = User32.GetWindow(WidgetFormHelper.GetShellDesktopParentHandle(), GetWindowCmd.GW_HWNDPREV);
        User32.SetWindowPos(windowHandle, hShellDesktopParent,
            0, 0, 0, 0, WindowPosFlags.SWP_NOSIZE | WindowPosFlags.SWP_NOMOVE | WindowPosFlags.SWP_NOACTIVATE);
    }
}
