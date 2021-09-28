using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SppTracer;

namespace Serializer
{
    public interface ISerializer
    {
        public string Serialize(TraceResult traceResult);
        public static void Main(string[] args)
        {

        }
    }
}
