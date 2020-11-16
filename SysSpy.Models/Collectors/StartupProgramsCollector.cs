using System.Management;
using Microsoft.Win32;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models.Collectors
{
    // todo add comments
    public class StartupProgramsCollector : ISystemElementsCollector
    {
        public SystemElementsCollection Collect()
        {
            var collection = new SystemElementsCollection();

            ManagementObjectSearcher cls = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_StartupCommand");
            foreach (ManagementObject mc in cls.Get())
                collection.Add(new StartupProgram(mc["Name"].ToString(), mc["Location"].ToString()));

            using (RegistryKey Reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\not active"))
            {
                if (Reg != null)
                    foreach (string Programs in Reg.GetValueNames())
                        collection.Add(new StartupProgram(Programs, Reg.Name));
            }

            using (RegistryKey Reg = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\not active"))
            {
                if (Reg != null)
                    foreach (string Programs in Reg.GetValueNames())
                        collection.Add(new StartupProgram(Programs, Reg.Name));
            }

            using (RegistryKey Reg = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run"))
            {
                foreach (string Programs in Reg.GetValueNames())
                    collection.Add(new StartupProgram(Programs, Reg.Name));
            }

            return collection;
        }
    }
}
