using System;
using System.Windows.Forms;
using Win32;

namespace WinDeskWidgetTweaks;

public static class DeskWidgetFormTweak
{
    public static void RemoveFormBroder(IntPtr windowHandle, bool enabled = true)
    {
        long windStyle = (long)User32Packaged.GetWindowLongPtr(windowHandle, Win32Const.GWL_STYLE);
        if (enabled) windStyle &= ~(Win32Const.WS_CAPTION | Win32Const.WS_SIZEBOX | Win32Const.WS_BORDER);
        else windStyle |= Win32Const.WS_CAPTION | Win32Const.WS_SIZEBOX | Win32Const.WS_BORDER;
        User32Packaged.SetWindowLongPtr(windowHandle, Win32Const.GWL_STYLE, new IntPtr(windStyle));
        long windExStyle = (long)User32Packaged.GetWindowLongPtr(windowHandle, Win32Const.GWL_EXSTYLE);
        if (enabled) windExStyle &= ~Win32Const.WS_EX_DLGMODALFRAME;
        else windExStyle |= Win32Const.WS_EX_DLGMODALFRAME;
        User32Packaged.SetWindowLongPtr(windowHandle, Win32Const.GWL_EXSTYLE, new IntPtr(windExStyle));
    }

    public static void RemoveFormSysMenu(IntPtr windowHandle, bool enabled = true)
    {
        long windStyle = (long)User32Packaged.GetWindowLongPtr(windowHandle, Win32Const.GWL_STYLE);
        if (enabled) windStyle &= ~Win32Const.WS_SYSMENU;
        else windStyle |= Win32Const.WS_SYSMENU;
        User32Packaged.SetWindowLongPtr(windowHandle, Win32Const.GWL_STYLE, new IntPtr(windStyle));
    }

    public static void SetDesktopWidgetFormZPos(IntPtr windowHandle)
    {
        User32.SetWindowPos(windowHandle, ShellDesktopFormHelper.GetShellDesktopParentHandle(),
            0, 0, 0, 0, Win32Const.SWP_NOSIZE | Win32Const.SWP_NOMOVE | Win32Const.SWP_NOACTIVATE);
    }

    public static void HideFormInTaskViewAndShowFormOnAllVirtualDesktops(IntPtr windowHandle, bool enabled = true)
    {
        long windStyle = (long)User32Packaged.GetWindowLongPtr(windowHandle, Win32Const.GWL_STYLE);
        if (enabled) windStyle |= Win32Const.WS_POPUP;
        else windStyle &= ~Win32Const.WS_POPUP;
        User32Packaged.SetWindowLongPtr(windowHandle, Win32Const.GWL_STYLE, new IntPtr(windStyle));
        long windExStyle = (long)User32Packaged.GetWindowLongPtr(windowHandle, Win32Const.GWL_EXSTYLE);
        if (enabled) { windExStyle |= Win32Const.WS_EX_TOOLWINDOW; windExStyle &= ~Win32Const.WS_EX_APPWINDOW; }
        else { windExStyle &= ~Win32Const.WS_EX_TOOLWINDOW; windExStyle |= Win32Const.WS_EX_APPWINDOW; }
        User32Packaged.SetWindowLongPtr(windowHandle, Win32Const.GWL_EXSTYLE, new IntPtr(windExStyle));
    }
}
