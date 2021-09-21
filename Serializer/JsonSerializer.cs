using Tracer;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    class JsonSerializer : ISerializer
    {
        public string Marshall(TraceResult traceResult)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            return System.Text.Json.JsonSerializer.Serialize(traceResult.Threads, options);
        }

        public static void Main(string [] Args)
        {
            ITracer tracer = new Tracer.Tracer();

            A a = new Tracer.A(tracer);
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 2; i++)
            {
                threads[i] = new Thread(() => { a.Method1(0); new Thread(() => a.Method1(0)).Start(); a.Method1(1); });
                threads[i].Start();
            }

            for (int i = 0; i < 2; i++)
            {
                threads[i].Join();
            }

            ISerializer marshaller = new XmlSerializer();
            Console.WriteLine(marshaller.Marshall(tracer.GetTraceResult()));
        }
    }
}
