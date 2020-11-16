using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace SysSpy.Scanning
{
    // todo add comments
    public class ElementsScanningHandler
    {
        private readonly Timer _scanExecutor;

        private readonly List<ElementScaner> _scaners;

        private double _scanInterval = 100;

        public ElementsScanningHandler()
        {
            _scaners = new List<ElementScaner>();

            SetScanExecutor(out _scanExecutor);
        }

        public bool IsScanEnabled => _scanExecutor.Enabled;

        public double ScanInterval
        {
            get => _scanInterval;

            set
            {
                if (_scanInterval == value)
                    return;

                _scanInterval = value;
                _scanExecutor.Interval = value;
            }
        }

        public void AddScaner(ElementScaner scaner) => _scaners.Add(scaner);

        public void StartScan()
        {
            ScanExecutor_Elapsed();
            _scanExecutor.Enabled = true;
        }

        public void StopScan()
        {
            _scanExecutor.Stop();
        }

        private void SetScanExecutor(out Timer scanExecutor)
        {
            scanExecutor = new Timer
            {
                AutoReset = true
            };
            scanExecutor.Elapsed += ScanExecutor_Elapsed;
            scanExecutor.Interval = ScanInterval;
        }

        private void ScanExecutor_Elapsed(object sender = null, ElapsedEventArgs e = null)
        {
            foreach (var scaner in _scaners)
                scaner.Scan();
        }
    }
}
