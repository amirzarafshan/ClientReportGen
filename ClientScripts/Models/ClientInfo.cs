
namespace ClientScripts.Models
{
    public sealed class ClientInfo
    {
        public string Name { get; set; }

        public ClientInfo (string sStationName)
        {
            Name = sStationName;
        }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
