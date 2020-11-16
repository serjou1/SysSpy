using System.Management;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models.Collectors
{
    public class DriversCollector : ISystemElementsCollector
    {
        public SystemElementsCollection Collect()
        {
            var collection = new SystemElementsCollection();

            var src = new ManagementObjectSearcher("SELECT * FROM Win32_SystemDriver");
            foreach (ManagementObject obj in src.Get())
            {
                collection.Add(new Driver(obj["DisplayName"].ToString(), obj["Name"].ToString(), obj["State"].ToString()));
            }

            return collection;
        }
    }
}
