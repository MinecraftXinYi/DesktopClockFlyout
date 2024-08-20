using System.Runtime.InteropServices;

namespace Win32.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct SIZE
{
    public int x;
    public int y;
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int left;
    public int top;
    public int right;
    public int bottom;
}

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int x;
    public int y;
}
