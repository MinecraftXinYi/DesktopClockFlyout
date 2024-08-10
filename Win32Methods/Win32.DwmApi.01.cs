using System;
using System.Runtime.InteropServices;

namespace Win32;

using Structs;

public static partial class DwmApi
{
#pragma warning disable CA1401
    [DllImport("dwmapi.dll")]
    public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);
}
