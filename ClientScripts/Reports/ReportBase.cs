using System;
using ClientScripts.Models;

namespace ClientScripts.Reports
{
    public abstract class ReportBase
    {
        protected ReportBase()
        {
            ReportName = GetType().Name.ToLowerInvariant();
        }

        public string ReportName { get; set; }
        public int ReportVersion { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Status Status { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }

    }
}
