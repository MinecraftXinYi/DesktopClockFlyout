using System;
using System.Runtime.InteropServices;

namespace Win32;

public static partial class Gdi32
{
    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern UInt32 SetBkColor(IntPtr hdc, UInt32 color);
}
