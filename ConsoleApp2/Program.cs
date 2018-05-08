using System;
using System.Threading;

class ThreadingExample
{
    static AutoResetEvent autoEvent;
    static void Main()
    {
        autoEvent = new AutoResetEvent(false);

        Console.WriteLine("main thread starting worker thread...");
        Thread t = new Thread(DoWork);
        t.Start();

        Console.WriteLine("main thread sleeping for 3 second...");
        Thread.Sleep(3000);

        Console.WriteLine("main thread signaling worker thread...");
        autoEvent.Set();
    }
    static void DoWork()
    {
        Console.WriteLine("   worker thread started, now waiting on event...");
        autoEvent.WaitOne();
        Console.WriteLine("   worker thread reactivated, now exiting...");
    }


}