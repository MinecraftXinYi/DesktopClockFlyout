using Mile.Xaml.Media.Helpers;
using Mile.Xaml.Media.UIBackdrop;
using Windows.UI.Composition.Desktop;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Forms;
using System;

namespace WinDeskClockFlyout
{
    public sealed partial class MainPage : Page
    {
        private Form RootForm;

        public MainPage(Form form)
        {
            this.InitializeComponent();
            UWPTextClockFlyout clockFlyout = new UWPTextClockFlyout();
            mainFrame.Content = clockFlyout;
            RootForm = form;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DesktopWindowTarget desktopWindow = BackdropHelper.InitializeDesktopWindowTarget(RootForm, false);
            SystemBackdrop systemBackdrop = new DesktopAcrylicBackdrop(desktopWindow, this, RootForm)
            {
                Kind = DesktopAcrylicKind.Thin,
                RequestedTheme = ElementTheme.Default,
                IsInputActive = true,
                UseHostBackdropBrush = true
            };
            systemBackdrop.InitializeBackdrop();
        }
    }
}
