using System.Runtime.InteropServices;

namespace Win32.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct MARGINS
{
    public int Left;
    public int Right;
    public int Top;
    public int Bottom;
}
