using Mile.Xaml;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDeskClockFlyout
{
    public partial class MainWidgetForm : Form
    {
        private readonly WindowsXamlHost xamlHost;

        public MainWidgetForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            xamlHost = new WindowsXamlHost();

            this.Controls.Add(xamlHost);
            xamlHost.AutoSize = true;
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.Child = new MainPage(this);

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
