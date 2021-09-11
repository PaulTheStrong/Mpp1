using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spp1
{
    public class A
    {
        private ITracer Tracer;
        public A(ITracer Tracer)
        {
            this.Tracer = Tracer;
        }
        public void Method1(int i)
        {
            Tracer.StartTrace();
            if (i <= 2)
            {
                var b = new B(Tracer);
                b.Method2(i + 1);
                Thread.Sleep(100);
            }
            Tracer.StopTrace();
        }
    }
}
