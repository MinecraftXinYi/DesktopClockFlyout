using System;
using System.ComponentModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;

namespace WinDeskClockFlyout
{
    public sealed partial class UWPTextClockFlyout : UserControl
    {
        public LiteClockTimer Timer {  get; set; }

        public string DateDisplayFormat { get; set; } = "D";

        public bool Use12HourClock { get; set; } = false;

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
                        if (!Use12HourClock)
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
                        DateBlock.Text = Timer.DateTimeNow.ToString(DateDisplayFormat);
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

        public async void SetFontSizeClient(int fontSizeClient)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                TimeBlock.FontSize = fontSizeClient * 4;
                DateBlock.FontSize = fontSizeClient * 2;
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
    }
}
