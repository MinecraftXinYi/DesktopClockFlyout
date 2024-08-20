using System;
using System.Runtime.InteropServices;

namespace Win32;

using Structs;

public static partial class DwmApi
{
#pragma warning disable CA1401
    [DllImport("dwmapi.dll")]
    public static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);
}
