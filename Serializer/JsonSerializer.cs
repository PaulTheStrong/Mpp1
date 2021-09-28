using SppTracer;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            return System.Text.Json.JsonSerializer.Serialize(traceResult.Threads, options);
        }
    }
}
