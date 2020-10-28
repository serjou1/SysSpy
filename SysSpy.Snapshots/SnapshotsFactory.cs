using SysSpy.Core;
using SysSpy.Core.Collectors;
using SysSpy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSpy.Snapshots
{
    public class SnapshotsFactory
    {
        //private readonly List<ISystemElementsCollector>

        private readonly CertificatesCollector _certificatesCollector;

        public SnapshotsFactory(params ISystemElementsCollector[] systemElementsCollectors)
        {

        }

        public Snapshot TakeSnapshot(string name)
        {

        }
    }

    class Prog
    {
        static void Main()
        {
            var factory = new SnapshotsFactory(
                new CertificatesCollector(),
                new );

            var initial = factory.TakeSnapshot("initial");
        }
    }
}
