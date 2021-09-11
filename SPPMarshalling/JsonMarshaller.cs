using Spp1;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPMarshalling
{
    class JsonMarshaller : IMarshaller
    {
        public string Marshall(TraceResult traceResult)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true};
            return JsonSerializer.Serialize(traceResult.Threads, options);
        }

        public static void Main(string [] Args)
        {
            ITracer tracer = new Tracer();

            A a = new Spp1.A(tracer);
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 2; i++)
            {
                threads[i] = new Thread(() => { a.Method1(0); a.Method1(0); a.Method1(1); });
                threads[i].Start();
            }

            for (int i = 0; i < 2; i++)
            {
                threads[i].Join();
            }

            IMarshaller marshaller = new JsonMarshaller();
            Console.WriteLine(marshaller.Marshall(tracer.GetTraceResult()));
        }
    }
}
