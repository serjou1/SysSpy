using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;
using SysSpy.Models;
using SysSpy.Snapshots;

namespace SysSpy.Core
{
    public class Scanner
    {
        private readonly Timer _scanExecutor;

        private readonly SnapshotsFactory _snapshotsFactory;

        private readonly SnapshotsComparator _snapshotsComparator;

        private readonly List<SystemElementsCollection> _totalAddedElementsCollections;
        private readonly List<SystemElementsCollection> _totalRemovedElementsCollections;

        private Snapshot _lastSnapshot;

        public Scanner(SnapshotsFactory snapshotsFactory)
        {
            _scanExecutor = new Timer();

            _snapshotsFactory = snapshotsFactory;

            _snapshotsComparator = new SnapshotsComparator();

            _totalAddedElementsCollections = new List<SystemElementsCollection>();
            _totalRemovedElementsCollections = new List<SystemElementsCollection>();

            _lastSnapshot = _snapshotsFactory.TakeSnapshot("Initial");

            SetScanExecutor();
        }

        public double ScanInterval { get; set; } = 100;

        public ReadOnlyCollection<SystemElementsCollection> TotalAddedElementsCollections
            => _totalAddedElementsCollections.AsReadOnly();

        public ReadOnlyCollection<SystemElementsCollection> TotalRemovedElementsCollections
            => _totalRemovedElementsCollections.AsReadOnly();

        public void StartScan()
        {
            _scanExecutor_Elapsed();
            _scanExecutor.Enabled = true;
        }

        public void StopScan()
        {
            _scanExecutor.Stop();
        }

        private void SetScanExecutor()
        {
            _scanExecutor.Elapsed += _scanExecutor_Elapsed;
            _scanExecutor.Interval = ScanInterval;
            _scanExecutor.AutoReset = true;
        }

        private void _scanExecutor_Elapsed(object sender = null, ElapsedEventArgs e = null)
        {
            var name = "test";
            var currentSnapshot = _snapshotsFactory.TakeSnapshot(name);

            _snapshotsComparator.CompareSnapshots(
                _lastSnapshot,
                currentSnapshot,
                out var addedElementsCollections,
                out var removedElementsCollections);

            _totalAddedElementsCollections.AddRange(addedElementsCollections);
            _totalRemovedElementsCollections.AddRange(removedElementsCollections);
        }
    }
}
