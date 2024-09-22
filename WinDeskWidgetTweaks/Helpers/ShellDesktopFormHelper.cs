using Win32;

namespace System.Windows.Forms;

public static class ShellDesktopFormHelper
{
    public static IntPtr GetShellDesktopParentHandle()
    {
        IntPtr hProgman = User32Packaged.FindWindow("Progman", "Program Manager");
        IntPtr hShellDefView = User32Packaged.FindWindowEx(hProgman, IntPtr.Zero, "SHELLDLL_DefView", null);
        if (hShellDefView == IntPtr.Zero)
        {
            IntPtr hWorkerW = User32Packaged.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "WorkerW", null);
            while (hShellDefView == IntPtr.Zero && hWorkerW != IntPtr.Zero)
            {
                hShellDefView = User32Packaged.FindWindowEx(hWorkerW, IntPtr.Zero, "SHELLDLL_DefView", null);
                hWorkerW = User32Packaged.FindWindowEx(IntPtr.Zero, hWorkerW, "WorkerW", null);
            }
            return hWorkerW;
        }
        else return hProgman;
    }

    public static IntPtr GetShellDesktopIconsLayerHandle()
    {
        IntPtr hShellDefView = User32Packaged.FindWindowEx(GetShellDesktopParentHandle(), IntPtr.Zero, "SHELLDLL_DefView", null);
        return User32Packaged.FindWindowEx(hShellDefView, IntPtr.Zero, "SysListView32", "FolderView");
    }
}
