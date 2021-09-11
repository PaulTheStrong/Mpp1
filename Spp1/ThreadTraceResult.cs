using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Spp1
{
    class ThreadTraceResult
    {
        public int ThreadId { get; private set; }
        public long ElapsedTime { get; private set; }
        public ImmutableList<MethodInfo> Methods { get; private set; }

        public ThreadTraceResult(int ThreadId)
        {
            this.ThreadId = ThreadId;
            ElapsedTime = 0;
            Methods = ImmutableList<MethodInfo>.Empty;
        }
        internal void AddMethod(MethodInfo method)
        {
            Methods = Methods.Add(method);
            ElapsedTime = ElapsedTime + method.ElapsedTime;
        }

        public override string ToString()
        {
            string result = "id = " + ThreadId + "\n elapsedTime : " + ElapsedTime + "ms\n methods: { ";
            for (int i = 0; i < Methods.Count; i++)
            {
                result += Methods[i].ToString() + ", \n";
            }
            return result + " }";
        }
    }
}
