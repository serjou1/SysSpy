using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SysSpy.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Test = new ObservableCollection<ElementsInfoViewModel>();
            Test.Add(new ElementsInfoViewModel());
            Test.Add(new ElementsInfoViewModel());
        }

        public ObservableCollection<ElementsInfoViewModel> Test { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
