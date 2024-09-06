using Mile.Xaml;
using MileXamlBlankAppNetFrameworkModern;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDeskClockFlyout;

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
            WidgetAppMethod.SetDesktopWidgetFormStyle(Handle);
            WidgetAppMethod.SetDesktopWidgetFormVisibility(Handle);
            Activated += WidgetAppMethod.KeepWidgetFormZPosOnActivated;
            Task.Factory.StartNew(async () => await WidgetAppMethod.KeepWidgetFormVisibilityTask(this), TaskCreationOptions.LongRunning);
        }

    }
}
