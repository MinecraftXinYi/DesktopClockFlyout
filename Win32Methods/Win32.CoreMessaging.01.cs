using System;
using System.Runtime.InteropServices;

namespace Win32;

using Structs;

public  static partial class CoreMessaging
{
#pragma warning disable CA1401
    [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
    public static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options, out IntPtr dispatcherQueueController);
}
