using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Throttle
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            int EndPoint = 100;
            int opsPerMinute = 40;

            Queue<Action> acts = new Queue<Action>();

            for (int idx = 0; idx < EndPoint; idx++)
            {
                var it = idx;
                acts.Enqueue(() => { p.Func(it); });
            }

            while (acts.Count > 0)
            {
                var sw = new Stopwatch();
                sw.Start();
                
                for (int i = 0; i < opsPerMinute; i++)
                {
                    var ops = acts.Dequeue();
                    ops();
                    if(acts.Count == 0)
                    {
                        goto OutOfScheduler;
                    }
                }
                
                sw.Stop();
                var elapsedTime = sw.ElapsedMilliseconds;
                Console.WriteLine("Elapsed Time(in ms) " + elapsedTime);
                //long millisInMinute = 60 * 100;
                long millisInMinute = 60 * 1000;
                if (millisInMinute > elapsedTime)
                {
                    int millistoSleep = (int)(millisInMinute - elapsedTime);
                    Console.WriteLine(String.Format("[{0}] Sleeping for {1} milliseconds", DateTime.Now.ToString(), millisInMinute - elapsedTime));
                    Thread.Sleep(millistoSleep);
                }
                else
                {

                    Console.WriteLine(String.Format("[{0}] Not going to Sleep", DateTime.Now.ToString()));
                }

            }
            OutOfScheduler:
            Console.WriteLine("Program finsihed");
        }


        public void Func(int i)
        {
            Console.WriteLine(i);
        }
    }
}
