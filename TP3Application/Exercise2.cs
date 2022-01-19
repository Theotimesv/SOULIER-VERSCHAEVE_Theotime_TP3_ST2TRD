using System;
using System.Threading;

namespace TP3Application
{
    public class Exercise2
    {
        Mutex mutex = new Mutex();
        public void launch()
        {
            var thread1 = new Thread(() => func(" ", 50, 10));
            var thread2 = new Thread(() => func("*", 40, 11));
            var thread3 = new Thread(() => func("°", 20, 9));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            
            
            thread1.Join();
            thread2.Join();
            thread3.Join();
        }
        
        public void func(string s, int t, int duration)
        {
            DateTime dt = DateTime.Now;
            int ms = dt.Second;
            int endtime = (ms + duration);
            
            while (ms != endtime) {
                mutex.WaitOne();
                Console.Write(s);
                mutex.ReleaseMutex();
                Thread.Sleep(t);
                ms = DateTime.Now.Second;
            }
        }
    }
}