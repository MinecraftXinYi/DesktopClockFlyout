//C# Lite Clock Timer Library
//Version: 1.0.0.0
//A simple C# class library to provide timers for system clock applications.
//Written by Github/MinecraftXinYi.

namespace System;

using ComponentModel;
using Threading.Tasks;

public class LiteClockTimer
{
    private DateTime _dateTime = DateTime.MinValue;
    private bool _stopped = false;
    private bool _disposed = false;

    public LiteClockTimer(int delaySeconds = 100)
    {
        DelaySeconds = delaySeconds;
        Task.Run(PushDateTimeTask);
    }

    public int DelaySeconds { get; set; }

    public DateTime DateTimeNow
    {
        get => _dateTime;
        private set
        {
            if (_dateTime != value)
            {
                _dateTime = value;
                DateTimeChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateTimeNow)));
            }
        }
    }

    public event PropertyChangedEventHandler DateTimeChanged;

    public void Stop() => _stopped = true;

    public void Continue() => _stopped = false;

    public void Dispose() => _disposed = true;

    private async Task PushDateTimeTask()
    {
        while (!_disposed)
        {
            PushDateTime(DateTime.Now);
            await Task.Delay(DelaySeconds);
        }
    }

    private void PushDateTime(DateTime datetime)
    {
        if (!_stopped)
            DateTimeNow = new DateTime(datetime.Year, datetime.Month, datetime.Day,
                datetime.Hour, datetime.Minute, datetime.Second, datetime.Kind);
    }
}
