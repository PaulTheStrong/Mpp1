using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spp1;

namespace SPPMarshalling
{
    interface IMarshaller
    {
        public string Marshall(TraceResult traceResult);
    }
}
