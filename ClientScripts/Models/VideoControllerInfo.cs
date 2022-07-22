
namespace ClientScripts.Models
{
    public sealed class VideoControllerInfo
    {
        public string Description { get; set; }
        public long AdapterRAM { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }

}
