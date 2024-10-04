using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mile.Xaml;

namespace WinDeskClockFlyout
{
    public partial class WidgetForm2 : Form
    {
        private readonly WindowsXamlHost xamlHost;

        public WidgetForm2()
        {
            InitializeComponent();
            xamlHost = new WindowsXamlHost();

            this.Controls.Add(xamlHost);
            xamlHost.AutoSize = true;
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.Child = new MainPage(this);
        }
    }
}
