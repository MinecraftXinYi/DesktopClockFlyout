using System.Runtime.InteropServices;

namespace Win32.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct MARGINS
{
    public int cxLeftWidth;
    public int cxRightWidth;
    public int cyTopHeight;
    public int cyBottomHeight;
}
