using System.Collections.Generic;
using System.Collections.Immutable;

namespace Tracer
{
    public class TraceResult
    {
        private readonly ImmutableList<ThreadTraceResult> _threads;

        public ImmutableList<ThreadTraceResult> Threads => _threads;

        public TraceResult() { }

        public TraceResult(List<ThreadTraceResult> threadTraceResults)
        {
            _threads = ImmutableList.CreateRange(threadTraceResults);
        }
    }
}