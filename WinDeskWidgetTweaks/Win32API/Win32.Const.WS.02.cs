namespace Win32;

public static partial class Win32Const
{
    public const uint WS_CAPTION = 0x00C00000;
    public const uint WS_SYSMENU = 0x00080000;
    public const uint WS_BORDER = 0x00800000;
    public const uint WS_THICKFRAME = 0x00040000;
    public const uint WS_SIZEBOX = WS_THICKFRAME;

    public const uint WS_POPUP = 0x80000000;
    public const uint WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU;
    public const uint WS_CHILD = 0x40000000;
    public const uint WS_CHILDWINDOW = WS_CHILD;

    public const uint WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
    public const uint WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;
}
