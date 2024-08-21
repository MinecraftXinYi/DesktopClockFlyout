using Win32;

namespace System.Windows.Forms;

public static class ShellDesktopFormHelper
{
    public static IntPtr GetShellDesktopParentHandle()
    {
        IntPtr hProgman = User32.FindWindow("Progman", "Program Manager");
        IntPtr hShellDefView = User32.FindWindowEx(hProgman, IntPtr.Zero, "SHELLDLL_DefView", null);
        if (hShellDefView == IntPtr.Zero)
        {
            IntPtr hWorkerW = User32.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "WorkerW", null);
            while (hShellDefView == IntPtr.Zero && hWorkerW != IntPtr.Zero)
            {
                hShellDefView = User32.FindWindowEx(hWorkerW, IntPtr.Zero, "SHELLDLL_DefView", null);
                hWorkerW = User32.FindWindowEx(IntPtr.Zero, hWorkerW, "WorkerW", null);
            }
            return hWorkerW;
        }
        else return hProgman;
    }

    public static IntPtr GetShellDesktopIconsLayerHandle()
    {
        IntPtr hProgman = User32.FindWindow("Progman", "Program Manager");
        IntPtr hShellDefView = User32.FindWindowEx(hProgman, IntPtr.Zero, "SHELLDLL_DefView", null);
        IntPtr hDesktopIconsLayer = User32.FindWindowEx(hShellDefView, IntPtr.Zero, "SysListView32", "FolderView");
        if (hDesktopIconsLayer == IntPtr.Zero)
        {
            IntPtr hWorkerW = User32.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "WorkerW", null);
            hShellDefView = IntPtr.Zero;
            while (hShellDefView == IntPtr.Zero && hWorkerW != IntPtr.Zero)
            {
                hShellDefView = User32.FindWindowEx(hWorkerW, IntPtr.Zero, "SHELLDLL_DefView", null);
                hWorkerW = User32.FindWindowEx(IntPtr.Zero, hWorkerW, "WorkerW", null);
            }
            hDesktopIconsLayer = User32.FindWindowEx(hShellDefView, IntPtr.Zero, "SysListView32", "FolderView");
        }
        return hDesktopIconsLayer;
    }
}
