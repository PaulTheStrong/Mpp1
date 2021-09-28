using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SppTracer;
using Serializer;

namespace Writer
{
    class _Main
    {
        public static void Main(String[] args)
        {
            IWriter[] writers = new IWriter[2] { new FileWriter("json.json"), new ConsoleWriter() };
            ITracer tracer = new Tracer();
            Foo foo = new Foo(tracer);
            Bar bar = new Bar(tracer);
            foo.foo();
            bar.bar();
            TraceResult traceResult = tracer.GetTraceResult();
            foreach(IWriter writer in writers)
            {
                writer.Write(traceResult, new JsonSerializer());
            }
            writers[0] = new FileWriter("xml.xml");
            foreach (IWriter writer in writers)
            {
                writer.Write(traceResult, new XmlSerializer());
            }
        }
    }

    class Foo {
        private ITracer tracer;
        public Foo(ITracer tracer)
        {
            this.tracer = tracer;
        } 
        public void foo()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
    
    class Bar
    {
        private ITracer tracer;
        public Bar(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public void bar()
        {
            tracer.StartTrace();
            Thread thread = new Thread(() =>
            {
                tracer.StartTrace();
                Thread thread = new Thread(() =>
                {
                    tracer.StartTrace();
                    Thread.Sleep(400);
                    tracer.StopTrace();
                });
                thread.Start();
                thread.Join();
                tracer.StopTrace();
            });
            thread.Start();
            thread.Join();
            tracer.StopTrace();
        }
    }
}
