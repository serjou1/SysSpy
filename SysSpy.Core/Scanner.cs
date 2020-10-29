using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace SysSpy.Core
{
    public class Scanner
    {
        private readonly Timer _scanExecutor;

        public Scanner()
        {
            _scanExecutor = new Timer();

            SetScanExecutor();
        }

        public double ScanInterval { get; set; } = 100;

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
            Console.WriteLine($"i'm alive {DateTime.Now}");
        }
    }
}
