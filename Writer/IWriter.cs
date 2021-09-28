using SppTracer;
using Serializer;


namespace Writer
{
    interface IWriter
    {
        public void Write(TraceResult result, ISerializer serializer);
    }
}
