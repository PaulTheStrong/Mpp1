using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Xml.Serialization;

namespace SppTracer
{
    [XmlType("thread")]
    public class ThreadTraceResult
    {
        [XmlAttribute]
        public int ThreadId { get; set; }
        [XmlAttribute]
        public long ElapsedTime { get; set; }
        public ImmutableList<MethodInfo> Methods { get; set; }

        public ThreadTraceResult() { }

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
    }
}
