using System;
using System.Runtime.InteropServices;

namespace Win32;

//Native Win32 Methods
public static partial class User32
{
#pragma warning disable CA1401
    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    public static extern IntPtr FindWindowW(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
    public static extern IntPtr FindWindowExA(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
    public static extern IntPtr FindWindowExW(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);
}

//Packaged Methods
public static partial class User32Packaged
{
    public static IntPtr FindWindow(string lpClassName, string lpWindowName, CharSet charSet = CharSet.Unicode)
    {
        switch (charSet)
        {
            default:
            case CharSet.Ansi:
                return User32.FindWindowA(lpClassName, lpWindowName);
            case CharSet.Unicode:
                return User32.FindWindowW(lpClassName, lpWindowName);
        }
    }

    public static IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow, CharSet charSet = CharSet.Unicode)
    {
        switch (charSet)
        {
            default:
            case CharSet.Ansi:
                return User32.FindWindowExA(hWndParent, hWndChildAfter, lpszClass, lpszWindow);
            case CharSet.Unicode:
                return User32.FindWindowExW(hWndParent, hWndChildAfter, lpszClass, lpszWindow);
        }
    }
}
