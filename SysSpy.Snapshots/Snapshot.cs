using System.Collections.Generic;
using SysSpy.Models;

namespace SysSpy.Snapshots
{
    public class Snapshot
    {
        public Snapshot(string name, List<SystemElementsCollection> collections)
        {
            Name = name;

            Collections = collections;
        }

        public string Name { get; }

        public List<SystemElementsCollection> Collections { get; }
    }
}
