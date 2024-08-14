using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDeskClockFlyout.Core;

namespace WinDeskClockFlyout;

internal static class WidgetAppMethod
{
    public static void KeepWidgetFormOnActivated(object sender, EventArgs e)
    {
        DeskWidgetFormTweak.SetDesktopWidgetFormZ((sender as Form).Handle);
    }

    public static async Task KeepWidgetFormBackgroundTask(Form form)
    {
        while (!form.IsDisposed)
        {
            DeskWidgetFormTweak.SetDesktopWidgetFormZ(form.Handle);
            await Task.Delay(30000);
        }
    }

    public static async Task KeepFormOnCurrentVirtualDesktop(Form form)
    {
        while (!form.IsDisposed)
        {
            DeskWidgetFormTweak.SetFormOnCurrentVirtualDesktop(form.Handle);
            await Task.Delay(500);
        }
    }
}
