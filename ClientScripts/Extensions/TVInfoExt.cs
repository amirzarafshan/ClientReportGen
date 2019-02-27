using ClientScripts.Models;

namespace ClientScripts.Extensions
{
    public static class TVInfoExt
    {
        public static TVInformation ToTeamViewerInfo(this TVInfo tvInformation)
        {
            return new TVInformation
            {
                Version = tvInformation.TV_version.Trim(),
                ClientID = tvInformation.TV_clientID
            };
        }
    }
}
