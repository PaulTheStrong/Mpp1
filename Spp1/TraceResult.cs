using System.Collections.Generic;
using System.Collections.Immutable;

namespace Spp1
{
    public class TraceResult
    {
        public ImmutableList<ThreadTraceResult> Threads;

        public TraceResult(List<ThreadTraceResult> threadTraceResults)
        {
            Threads = ImmutableList.CreateRange(threadTraceResults);
        }
    }
}