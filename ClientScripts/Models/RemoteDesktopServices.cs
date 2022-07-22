using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace ClientScripts.Models
{
    public sealed class RemoteDesktopServices
    {

        public static readonly string remoteServices = "remote";

        public string ServiceName { get; set; }
        public string Status { get; set; }

        public RemoteDesktopServices (string servicename,string status)
        {
            ServiceName = servicename;
            Status = status;
        }

        public static List<RemoteDesktopServices> GetRunningRemoteServices()
        {
           var running_services = new List<RemoteDesktopServices>();
            List<ServiceController> services;

            services = ServiceController.GetServices().Where(sc => sc.DisplayName.ToLowerInvariant().Contains(remoteServices)).ToList();
            try
            {
                foreach (ServiceController service in services)
                    if (service.Status.Equals(ServiceControllerStatus.Running))
                        running_services.Add(new RemoteDesktopServices(service.DisplayName.ToString(), service.Status.ToString()));

                return running_services;
            }
            catch
            {
                return null;
            }      
        }

        public override string ToString()
        {
            return Serializer.ToString(this);

        }
    }
}
