using SysSpy.Scanning;
using System.ComponentModel;
using System.Windows.Input;

namespace SysSpy.Desktop.ViewModels
{
    // todo add comments
    internal class ScanningControlViewModel : INotifyPropertyChanged
    {
        private ElementsScanningHandler _elementsScanningHandler;

        public ScanningControlViewModel(ElementsScanningHandler elementsScanningHandler)
        {
            _elementsScanningHandler = elementsScanningHandler;
        }

        public bool IsScanEnabled => _elementsScanningHandler.IsScanEnabled;

        public ICommand SwitchScanningState
        {
            get
            {
                return new RelayCommand(_ =>
                {
                    if (_elementsScanningHandler.IsScanEnabled)
                        _elementsScanningHandler.StopScan();
                    else
                        _elementsScanningHandler.StartScan();

                    OnPropertyChanged("IsScanEnabled");
                });
            }
        }

        public double ScanInterval
        {
            get
            {
                return _elementsScanningHandler.ScanInterval;
            }

            set
            {
                if (value == _elementsScanningHandler.ScanInterval)
                    return;

                _elementsScanningHandler.ScanInterval = value;
                OnPropertyChanged("ScanInterval");
            }
        }

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
