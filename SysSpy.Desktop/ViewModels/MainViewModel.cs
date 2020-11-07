using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SysSpy.Models.Collectors;
using SysSpy.Scanning;

namespace SysSpy.Desktop.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Test = new ObservableCollection<ElementsInfoViewModel>();

            var certificatesCollector = new CertificatesCollector();
            var certificatesScaner = new ElementScaner(certificatesCollector, "Certificates");
            certificatesScaner.Scan();
            var certifVM = new ElementsInfoViewModel(certificatesScaner);

            Test.Add(certifVM);
            //Test.Add(new ElementsInfoViewModel());
            //Test.Add(new ElementsInfoViewModel());
        }

        public ObservableCollection<ElementsInfoViewModel> Test { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
