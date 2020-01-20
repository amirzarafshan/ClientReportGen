namespace ClientScripts.Models
{
    public sealed class PortInfo
    {
        public int PortNumber {get; set; }
        public string Status{ get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
 
}
