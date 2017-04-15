using System;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class Timing 
    {
        TimeSpan start;
        TimeSpan duration;
        public TimeSpan Result 
        { 
            get { return duration; }
        }
        public Timing()
        {
            start = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            start = Process.GetCurrentProcess().Threads[0].TotalProcessorTime;
        }
        public void Stop()
        {
            duration = Process.GetCurrentProcess().Threads[0].
                        TotalProcessorTime.Subtract(start);
            Reset();
        }
        public void Reset()
        {
            start = new TimeSpan(0);
        }
    }
}