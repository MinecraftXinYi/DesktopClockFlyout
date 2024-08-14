using System;
using System.Windows.Forms;
using Win32;
using Win32.COM;
using Win32.Constants;
using Win32.Structs;
using System.Drawing;
using System.Runtime.InteropServices;
using Win32.Enums;
using System.Threading.Tasks;

namespace WinDeskClockFlyout.Core;

public static class DeskWidgetFormTweak
{
    private static readonly VirtualDesktopManager vdManager = new();

    public static void RemoveFormBroder(IntPtr windowHandle, bool enable = true)
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

    public static void RemoveFormSysMenu(IntPtr windowHandle, bool enable = true)
    {
        uint windStyle = (uint)User32Packaged.GetWindowLongPtr(windowHandle, WindowLongFlags.GWL_STYLE);
        if (enable) windStyle &= ~WindowStyles.WS_SYSMENU;
        else windStyle |= WindowStyles.WS_SYSMENU;
        User32Packaged.SetWindowLongPtr(windowHandle, WindowLongFlags.GWL_STYLE, new IntPtr(windStyle));
    }

    public static void SetDesktopWidgetFormZ(IntPtr windowHandle)
    {
        User32.SetWindowPos(windowHandle, WidgetFormHelper.GetShellDesktopParentHandle(),
            0, 0, 0, 0, WindowPosFlags.SWP_NOSIZE | WindowPosFlags.SWP_NOMOVE | WindowPosFlags.SWP_NOACTIVATE);
    }

    public static async void SetFormOnCurrentVirtualDesktop(IntPtr windowHandle)
    {
        try
        {
            if (!vdManager.IsWindowOnCurrentVirtualDesktop(windowHandle))
            {
                User32.ShowWindow(windowHandle, ShowWindowFlags.SW_HIDE);
                await Task.Delay(250);
                User32.ShowWindow(windowHandle, ShowWindowFlags.SW_SHOWNA);
            }
        }
        catch (Exception) { }
    }

    public static void SetFormCompositionAttribute(IntPtr windowHandle, Color? gradientColor,
        AccentState accentState = AccentState.ACCENT_ENABLE_TRANSPARENTGRADIENT)
    {
        int blurColor;
        if (gradientColor.HasValue)
            blurColor = gradientColor.Value.R << 0 | gradientColor.Value.G << 8 | gradientColor.Value.B << 16 | gradientColor.Value.A << 24;
        else blurColor = 0;
        var accent = new AccentPolicy { AccentState = accentState, GradientColor = blurColor };
        var accentStructSize = Marshal.SizeOf(accent);
        var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        Marshal.StructureToPtr(accent, accentPtr, false);
        var data = new WindowCompositionAttributeData
        {
            Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
            SizeOfData = accentStructSize,
            Data = accentPtr
        };
        User32.SetWindowCompositionAttribute(windowHandle, ref data);
        Marshal.FreeHGlobal(accentPtr);
    }
}
