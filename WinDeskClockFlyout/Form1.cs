using Mile.Xaml;
using MileXamlBlankAppNetFrameworkModern;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WinDeskClockFlyout;
using WinDeskClockFlyout.Core;

namespace MileXamlBlankAppNetFramework
{
    public partial class Form1 : Form
    {
        private readonly WindowsXamlHost xamlHost;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            xamlHost = new WindowsXamlHost();

            this.Controls.Add(xamlHost);
            xamlHost.AutoSize = true;
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.Child = new MainPage();

            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            DeskWidgetFormTweak.RemoveFormBroder(Handle);
            DeskWidgetFormTweak.RemoveFormSysMenu(Handle);
            DeskWidgetFormTweak.HideFormInTaskViewsAndShowFormOnAllVirtualDesktops(Handle);
            DeskWidgetFormTweak.SetFormCompositionAttribute(Handle, null/*Color.FromArgb(130, 150, 255, 1)*/,
                DeskWidgetFormTweak.FormCompAccentState.Accent_Blur);
            DeskWidgetFormTweak.SetDesktopWidgetFormZPos(Handle);
            Activated += WidgetAppMethod.KeepWidgetFormOnActivated;
            Task.Factory.StartNew(async () => await WidgetAppMethod.KeepWidgetFormBackgroundTask(this), TaskCreationOptions.LongRunning);
            Task.Factory.StartNew(async () => await WidgetAppMethod.KeepFormOnCurrentVirtualDesktop(this), TaskCreationOptions.LongRunning);
        }

    }
}
