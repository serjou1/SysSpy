using Microsoft.Win32;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models.Collectors
{
    // todo add comments
    public class ODBCsCollector : ISystemElementsCollector
    {
        public SystemElementsCollection Collect()
        {
            var collection = new SystemElementsCollection();

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ODBC\ODBCINST.INI\ODBC Drivers"))
            {
                foreach (string driver in key.GetValueNames())
                    collection.Add(new ODBC(driver));
            }

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\ODBC\ODBCINST.INI\ODBC Drivers"))
            {
                foreach (string driver in key.GetValueNames())
                    collection.Add(new ODBC(driver + " (x86)"));
            }

            return collection;
        }
    }
}
