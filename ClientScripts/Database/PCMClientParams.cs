using System.Linq;
using ClientScripts.Models;

namespace ClientScripts.Database
{
    public class PCMClientParams
    {
        public static ClientParams GetPCMClientPosition()
        {
            const string query = "SELECT bLockAppWindow,iPosX,iPosY FROM tblParams";
            var provider = new DBProviderBase();
            return provider.Read<ClientParams>(query, null).FirstOrDefault();
        }
    }
}
