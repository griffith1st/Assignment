using System;
using System.Threading;

namespace SimpleAlarm
{
    public class AlarmClock
    {
        // 定义两个事件
        public event Action Tick;
        public event Action Alarm;

        private DateTime _alarmTime;

        public AlarmClock(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
        }

        public void Start()
        {
            Console.WriteLine($"闹钟已启动，将在 {_alarmTime:T} 响铃");
            
            while (DateTime.Now < _alarmTime)
            {
                Tick?.Invoke();          // 触发嘀嗒事件
                Thread.Sleep(1000);      // 等待1秒
            }
            
            Alarm?.Invoke();            // 触发响铃事件
        }
    }

    class Program
    {
        static void Main()
        {
            // 设置3秒后响铃
            var alarm = new AlarmClock(DateTime.Now.AddSeconds(3));
            
            // 订阅事件
            alarm.Tick += () => Console.WriteLine($"滴答... [{DateTime.Now:T}]");
            alarm.Alarm += () => Console.WriteLine("叮铃铃！！！");
            
            alarm.Start();
            
            Console.ReadKey();
        }
    }
}
