using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SysSpy.Models.Attributes;
using SysSpy.Models.Collectors;
using SysSpy.Models.SystemElements;
using SysSpy.Scanning;
using SysSpy.Snapshots;

namespace SysSpy.Desktop.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly CollectorsRegistrar _collectorsRegistrar;

        private readonly ElementsScanningHandler _elementsScanningHandler;

        public MainViewModel()
        {
            SystemElementsTabsViewModels = new List<ElementsInfoViewModel>();

            InitializeCollectorsRegistrar(out _collectorsRegistrar);

            InitializeElementsScanningHandlerAndGetTabsViewModels(out _elementsScanningHandler);
        }

        public List<ElementsInfoViewModel> SystemElementsTabsViewModels { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InitializeCollectorsRegistrar(out CollectorsRegistrar collectorsRegistrar)
        {
            collectorsRegistrar = new CollectorsRegistrar();

            collectorsRegistrar.RegisterElementAndCollector<Certificate>(
                new CertificatesCollector());
        }

        private void InitializeElementsScanningHandlerAndGetTabsViewModels(out ElementsScanningHandler elementsScanningHandler)
        {
            elementsScanningHandler = new ElementsScanningHandler();

            foreach (var type in _collectorsRegistrar.RegisteredTypes)
            {
                var attrs = type.GetCustomAttributes(false);
                string collectionName = string.Empty;
                foreach (CollectionNameAttribute attr in attrs)
                    collectionName = attr.CollectionName;

                var collector = _collectorsRegistrar.GetCollector(type);

                var scaner = new ElementScaner(collector, collectionName);
                elementsScanningHandler.AddScaner(scaner);

                var tabViewModel = new ElementsInfoViewModel(scaner);
                SystemElementsTabsViewModels.Add(tabViewModel);
            }
        }
    }
}
