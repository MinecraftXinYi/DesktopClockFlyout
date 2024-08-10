using Mile.Xaml;
using MileXamlBlankAppNetFrameworkModern;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            DeskWidgetFormTweak.RemoveBroder(Handle);
            DeskWidgetFormTweak.RemoveSysMenu(Handle);
            DeskWidgetFormTweak.SetWindowComposition(Handle);
            DeskWidgetFormTweak.SetDesktopWidgetFormZ(Handle);
            Activated += WidgetAppMethod.KeepWidgetFormOnActivated;
            Task.Factory.StartNew(async () => await WidgetAppMethod.KeepWidgetFormBackgroundTask(this), TaskCreationOptions.LongRunning);
        }

    }
}
