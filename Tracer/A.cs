using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
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
            Method2();
            Method2();
            Method2();
            Tracer.StopTrace();
        }
        
        public void Method2()
        {
            Tracer.StartTrace();

            Thread.Sleep(20);
            
            Tracer.StopTrace();
        }
    }
}
