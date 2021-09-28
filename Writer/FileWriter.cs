using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SppTracer;

namespace Writer
{
    class FileWriter : IWriter
    {
        private string Path;

        public FileWriter(string Path)
        {
            this.Path = Path;
        }

        public void Write(TraceResult result, ISerializer serializer)
        {
            String output = serializer.Serialize(result);
            File.WriteAllTextAsync(Path, output);
        }
    }
}
