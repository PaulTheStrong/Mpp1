using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Spp1
{
    class MethodInfo
    {
        public long ElapsedTime { get; internal set; }
        public string MethodName { get; internal set; }
        public string ClassName { get; internal set; }
        public ImmutableList<MethodInfo> methods { get; internal set;  }

        public MethodInfo(string ClassName, string MethodName, long ElapsedTime)
        {
            this.ElapsedTime = ElapsedTime;
            this.MethodName = MethodName;
            this.ClassName = ClassName;
            this.methods = ImmutableList<MethodInfo>.Empty;
        }

        public override string ToString()
        {
            string result = "ElapsedTime: " + ElapsedTime + "ms. MethodName: " + MethodName + " ClassName: " + ClassName;
            if (methods.Count != 0)
            {
                result += "Methods: {\n";
                foreach (var method in methods)
                {
                    result += method.ToString() + "\n";
                }
                result += "}";
            }
            return result;
        }

    }
}
