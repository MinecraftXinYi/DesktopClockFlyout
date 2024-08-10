using System;
using System.Runtime.InteropServices;

namespace Win32;

using Structs;

public static partial class User32
{
#pragma warning disable CA1401
    [DllImport("user32.dll")]
    public static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
}
