using System;
using System.Windows.Forms;

namespace WinDeskClockFlyout
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            App app = new();

            Application.Run(new MainWidgetForm());

            app.Close();
        }
    }
}
