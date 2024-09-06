using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDeskClockFlyout.Core;

namespace WinDeskClockFlyout;

internal static class WidgetAppMethod
{
    internal static void SetDesktopWidgetFormStyle(IntPtr windhandle)
    {
        DeskWidgetFormTweak.RemoveFormBroder(windhandle);
        DeskWidgetFormTweak.RemoveFormSysMenu(windhandle);
    }

    internal static void SetDesktopWidgetFormVisibility(IntPtr windhandle)
    {
        DeskWidgetFormTweak.HideFormInTaskViewAndShowFormOnAllVirtualDesktops(windhandle);
        DeskWidgetFormTweak.SetDesktopWidgetFormZPos(windhandle);
    }

    internal static void KeepWidgetFormZPosOnActivated(object sender, EventArgs e)
    {
        if (sender is Form)
            if (!(sender as Form).IsDisposed) DeskWidgetFormTweak.SetDesktopWidgetFormZPos((sender as Form).Handle);
        else throw new ArgumentException("The event sender is not a form.");
    }

    internal static async Task KeepWidgetFormVisibilityTask(Form form)
    {
        while (!form.IsDisposed)
        {
            await Task.Delay(20000);
            if (!form.IsDisposed) SetDesktopWidgetFormVisibility(form.Handle);
        }
    }
}
