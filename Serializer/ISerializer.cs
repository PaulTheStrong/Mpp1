using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer;

namespace Serializer
{
    public interface ISerializer
    {
        public string Marshall(TraceResult traceResult);
    }
}
