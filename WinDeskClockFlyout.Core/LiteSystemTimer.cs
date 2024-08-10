//C# Lite System Timer Library
//Version: 1.5
//This C# code is copied from https://github.com/IVSoftware/winui-3-system-timer

using System.ComponentModel;
using System.Threading.Tasks;

namespace System;

public class LiteSystemTimer
{
    private DateTime _second = DateTime.MinValue;
    private bool _dispose = false;

    public LiteSystemTimer() => Load();

    private void Load() => Task.Run(PushDateTimeTask);

    private async Task PushDateTimeTask()
    {
        while (!_dispose)
        {
            PushDateTime(DateTime.Now);
            await Task.Delay(100);
        }
    }

    private void PushDateTime(DateTime now)
    {
        // Using a 'now' that doesn't change within this method:
        Second = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Kind);
    }

    public DateTime Second
    {
        get => _second;
        set
        {
            if (_second != value)
            {
                _second = value;
                PropertyChanged?.Invoke(nameof(LiteSystemTimer), new PropertyChangedEventArgs(nameof(Second)));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Dispose() => _dispose = true;

    public void Reload()
    {
        _dispose = false;
        Load();
    }
}
