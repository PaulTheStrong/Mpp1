using System.Threading;

namespace Spp1
{
    class B
    {
        private ITracer Tracer;

        internal B(ITracer Tracer)
        {
            this.Tracer = Tracer;
        }
               
        public void Method2(int i)
        {
            Tracer.StartTrace();
            var a = new A(Tracer);
            a.Method1(i + 1);
            Thread.Sleep(100);
            Tracer.StopTrace();
        }
    }
}