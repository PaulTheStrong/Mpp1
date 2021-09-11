using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Spp1
{
    class Tracer : ITracer
    {

        private ConcurrentDictionary<int, SingleThreadTracer> SingleThreadTracers = new ConcurrentDictionary<int, SingleThreadTracer>();

        public void StartTrace()
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            if (!SingleThreadTracers.ContainsKey(id))
            {
                SingleThreadTracers.TryAdd(id, new SingleThreadTracer(id));
            }
            SingleThreadTracers[id].StartTrace();
        }


        public void StopTrace()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            SingleThreadTracers[id].EndTrace();
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(SingleThreadTracers.Values.Select(Tracer => Tracer.ThreadTraceResult).ToList());
        }

        public static void Main(string[] args)
        {
            Tracer tracer = new Tracer();
            A a = new A(tracer);
            a.Method1(0);

            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(() => { a.Method1(0); });
                threads[i].Start();
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }
            foreach (var value in tracer.GetTraceResult().Threads)
            {
                Console.WriteLine(value);
            }
        }
    }
}