using ClientScripts.Models;

namespace ClientScripts.Extensions
{
    public static class TVInfoExt
    {
        public static TVInformation ToTeamViewerInfo(this TVInfo tvInformation)
        {
            return new TVInformation
            {
                Version = tvInformation.Version.Trim(),
                ClientId = tvInformation.ClientId
            };
        }
    }
}
