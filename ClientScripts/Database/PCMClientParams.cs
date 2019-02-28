using System.Linq;
using ClientScripts.Models;

namespace ClientScripts.Database
{
    public class PCMClientParams
    {
        public static DBProviderBase provider = new DBProviderBase();

        public static ClientParams GetPCMClientPosition()
        {
            const string query = "SELECT bLockAppWindow,iPosX,iPosY FROM tblParams";  
            return provider.Read<ClientParams>(query, null).FirstOrDefault();
        }

        public static ClientInfo GetStationName()
        {
            const string clientname = "SELECT sStationName FROM tblParams";           
            return provider.Read<ClientInfo>(clientname, null).FirstOrDefault();
        }
    }
}
