﻿namespace Win32.Constants;

public static partial class WindowStylesEx
{
    public const uint WS_EX_ACCEPTFILES = 0x00000010;
    public const uint WS_EX_DLGMODALFRAME = 0x00000001;
    public const uint WS_EX_APPWINDOW = 0x00040000;
    public const uint WS_EX_TOOLWINDOW = 0x00000080;
    public const uint WS_EX_NOACTIVATE = 0x08000000;
}

public static partial class WindowLongFlags
{
    public const int GWL_EXSTYLE = -20;
}
