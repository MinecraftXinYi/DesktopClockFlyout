namespace Win32.Constants;

public static partial class WindowStyles
{
    public const uint WS_MAXIMIZEBOX = 0x00010000;
    public const uint WS_MINIMIZEBOX = 0x00020000;

    public const uint WS_VISIBLE = 0x10000000;

    public const uint WS_MAXIMIZE = 0x01000000;

    public const uint WS_OVERLAPPED = 0x00000000;
    public const uint WS_TILED = WS_OVERLAPPED;
}

public static partial class WindowLongFlags
{
    public const int GWL_STYLE = -16;
}
