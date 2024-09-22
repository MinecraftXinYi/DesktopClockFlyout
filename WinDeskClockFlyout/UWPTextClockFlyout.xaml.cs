using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinDeskClockFlyout
{
    public sealed partial class UWPTextClockFlyout : UserControl
    {
        public bool Use12HourClock { get; set; } = false;
        public async void SetFontSizeX(int fontSizeX)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                TimeBlock.FontSize = fontSizeX * 4;
                DateBlock.FontSize = fontSizeX * 2;
            });
        }
        public async void SetFontFamily(FontFamily fontFamily)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                TimeBlock.FontFamily = fontFamily;
                DateBlock.FontFamily = fontFamily;
            });
        }

        public LiteClockTimer Timer;

        public UWPTextClockFlyout()
        {
            this.InitializeComponent();
            if (Timer == null) Timer = new ();

            this.Loaded += Load;
            this.Unloaded += Unload;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            Timer.DateTimeChanged += TimeDateUpdate;
        }

        //TextBlock时钟显示实现
        private async void TimeDateUpdate(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(LiteClockTimer.DateTimeNow):
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        if (!this.Use12HourClock)
                        {
                            //24小时制时钟
                            TimeBlock.Text = Timer.DateTimeNow.ToString("HH:mm:ss");
                        }
                        else
                        {
                            //12小时制时钟
                            TimeBlock.Text = Timer.DateTimeNow.ToString("hh:mm:ss tt");
                        }
                        //日期
                        DateBlock.Text = Timer.DateTimeNow.ToString("yyyy MMMM dd dddd");
                    });
                    break;
            }
        }

        private void Unload(object sender, RoutedEventArgs e)
        {
            Timer.DateTimeChanged -= TimeDateUpdate;
            this.Loaded -= Load;
            this.Unloaded -= Unload;
        }
    }
}
