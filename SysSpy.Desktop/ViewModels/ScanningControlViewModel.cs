using SysSpy.Scanning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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


        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
