using System.Collections.Generic;
using SysSpy.Models;
using SysSpy.Models.Interfaces;

namespace SysSpy.Snapshots
{
    public class SnapshotsFactory
    {
        private readonly List<ISystemElementsCollector> _collectors;

        public SnapshotsFactory(List<ISystemElementsCollector> collectors)
        {
            _collectors = collectors;
        }

        public Snapshot TakeSnapshot(string name)
        {
            var collections = new List<SystemElementsCollection>();
            foreach (var collector in _collectors)
                collections.Add(collector.Collect());

            return new Snapshot(name, collections);
        }
    }
}
