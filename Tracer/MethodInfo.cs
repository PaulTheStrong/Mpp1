using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Xml.Serialization;

namespace SppTracer
{
    [XmlType("method")]
    public class MethodInfo
    {
        [XmlAttribute]
        public long ElapsedTime { get; set; }
        [XmlAttribute]
        public string MethodName { get; set; }
        [XmlAttribute]
        public string ClassName { get; set; }
        public ImmutableList<MethodInfo> methods { get; internal set;  }

        public MethodInfo() { }

        public MethodInfo(string ClassName, string MethodName, long ElapsedTime)
        {
            this.ElapsedTime = ElapsedTime;
            this.MethodName = MethodName;
            this.ClassName = ClassName;
            this.methods = ImmutableList<MethodInfo>.Empty;
        }
    }
}
