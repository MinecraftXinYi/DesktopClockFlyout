using System;
using System.Runtime.InteropServices;

namespace Win32.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct DWM_BLURBEHIND
{
    public uint dwFlags;
    public bool fEnable;
    public IntPtr hRgnBlur;
    public bool fTransitionOnMaximized;
}
