namespace assignment4_2
{
    public class TickEventArgs: EventArgs
    {
        public DateTime CurrentTime { get;  }
        public TickEventArgs(DateTime currentTime)
        {
            CurrentTime = currentTime;
        }
    }

    public class AlarmEventArgs : EventArgs
    {
        public DateTime AlarmTime { get; }
        public AlarmEventArgs(DateTime alarmTime)
        {
            AlarmTime = alarmTime;
        }
    }

    public class AlarmClock
    {
        public event EventHandler<TickEventArgs> Tick;
        public event EventHandler<AlarmEventArgs> Alarm;
        private void OnTick(TickEventArgs e)
        {
            Tick?.Invoke(this, e);
        }
        private void OnAlarm(AlarmEventArgs e)
        {
            Alarm?.Invoke(this, e);
        }
        public void start(int countTime)
        {
            for (int i = countTime; i >= 0; i--)
            {
                OnTick(new TickEventArgs(DateTime.Now));
                Thread.Sleep(1000);
            }
            OnAlarm(new AlarmEventArgs(DateTime.Now));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var alarm = new AlarmClock();
            alarm.Tick += (sender, e) => Console.WriteLine($"嘀嗒声：{e.CurrentTime}");
            alarm.Alarm += (sender, e) => Console.WriteLine($"响铃:{e.AlarmTime}");

            Console.WriteLine("闹钟将在10秒后响铃");
            alarm.start(10);

        }
    }
}