using System.Collections.Generic;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models
{
    public class SystemElementsCollection : List<SystemElement>
    {
        public SystemElementsCollection(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
