
namespace ClientScripts.Models
{
    public sealed class NetworkInfo
    {
        public string IPAddress { get; set; }
        public string DotNETVersion { get; set; }
        public string IEVersion { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
