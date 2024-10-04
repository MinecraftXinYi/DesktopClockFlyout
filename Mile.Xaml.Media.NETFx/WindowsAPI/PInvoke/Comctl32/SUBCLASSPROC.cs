using System;
using Mile.Xaml.Media.WindowsAPI.PInvoke.User32;

namespace Mile.Xaml.Media.WindowsAPI.PInvoke.Comctl32
{
    public delegate IntPtr SUBCLASSPROC(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam, uint uIdSubclass, IntPtr dwRefData);
}
