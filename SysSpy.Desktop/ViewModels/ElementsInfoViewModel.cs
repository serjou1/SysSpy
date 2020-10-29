using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SysSpy.Desktop.ViewModels
{
    public class ElementsInfoViewModel : INotifyPropertyChanged
    {
        public ElementsInfoViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
