using System;
using System.Runtime.InteropServices;

namespace Win32;

//Native Win32 Classes
public static partial class User32
{
#pragma warning disable CA1401
    [DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
    public static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", SetLastError = true)]
    public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
    public static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
    public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
}

//Packaged Classes
public static partial class User32Packaged
{
    public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
    {
        if (IntPtr.Size == 8)
            return User32.GetWindowLongPtr64(hWnd, nIndex);
        else
            return User32.GetWindowLongPtr32(hWnd, nIndex);
    }

    public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
    {
        if (IntPtr.Size == 8)
            return User32.SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        else
            return new IntPtr(User32.SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
    }
}
