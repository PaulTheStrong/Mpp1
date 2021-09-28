using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SppTracer;

namespace Writer
{
    public class ConsoleWriter : IWriter
    {
        public void Write(TraceResult result, ISerializer serializer)
        {
            Console.WriteLine(serializer.Serialize(result));
        }
    }
}
