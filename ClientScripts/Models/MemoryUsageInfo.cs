
namespace ClientScripts.Models
{
     public sealed class MemoryUsageInfo
        {
            public VirtualMemory PagingFile { get; set; }
            public PCMHelperSvc PCMHelper { get; set; }     
            public PCMClient PCMClient { get; set; }

            public override string ToString()
            {
                return Serializer.ToString(this);
            }
        }
}
