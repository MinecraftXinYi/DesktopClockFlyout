using WinDeskClockFlyout;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MileXamlBlankAppNetFrameworkModern
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            UWPTextClockFlyout clockFlyout = new UWPTextClockFlyout();
            mainFrame.Content = clockFlyout;
        }
    }
}
