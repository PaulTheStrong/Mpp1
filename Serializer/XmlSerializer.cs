using SppTracer;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    public class XmlSerializer : ISerializer
    {
        private static readonly System.Xml.Serialization.XmlSerializer Serializer = new System.Xml.Serialization.XmlSerializer(typeof(TraceResult));

        public string Serialize(TraceResult traceResult)
        {
            var sw = new StringWriter();
            Serializer.Serialize(sw, traceResult);
            return sw.ToString();
        }
    }
}
