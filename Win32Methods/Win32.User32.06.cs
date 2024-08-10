using System;
using System.Runtime.InteropServices;

namespace Win32;

public static partial class User32
{
#pragma warning disable CA1401
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
}
