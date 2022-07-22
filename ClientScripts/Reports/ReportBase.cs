using System;
using ClientScripts.Models;

namespace ClientScripts.Reports
{
    public abstract class ReportBase
    {
        protected ReportBase()
        {
            Name = GetType().Name.ToLowerInvariant();
        }

        public string Name { get; set; }
        public int Version { get; set; } = 2;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Status Status { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
