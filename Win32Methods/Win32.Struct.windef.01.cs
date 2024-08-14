using System.Runtime.InteropServices;

namespace Win32.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct Size
{
    public int X;
    public int Y;
}

[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}
