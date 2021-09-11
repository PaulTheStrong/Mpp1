using System.Collections.Immutable;

namespace Spp1
{
    class TraceResult
    {
        public ImmutableList<ThreadTraceResult> Threads;

        public TraceResult(List<ThreadTraceResult> threadTraceResults)
        {
            Threads = ImmutableList.CreateRange(threadTraceResults);
        }
    }
}