namespace ClientScripts.Models
{
    public sealed class TVInformation
    {
        public string Version { get; set; }
        public long ClientId { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
