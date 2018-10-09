// ReSharper disable InconsistentNaming
namespace ClientScripts.Models
{
    public sealed class ClientParams
    {
        public bool bLockAppWindow { get; set; }
        public int iPosX { get; set; }
        public int iPosY { get; set; }

        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
}
