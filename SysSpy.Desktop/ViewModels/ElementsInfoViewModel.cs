using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SysSpy.Models.SystemElements;
using SysSpy.Scanning;

namespace SysSpy.Desktop.ViewModels
{
    // todo add comments
    internal class ElementsInfoViewModel : INotifyPropertyChanged
    {
        private readonly ElementScaner _elementScaner;

        private bool _haveAdded;
        private bool _haveChanged;
        private bool _haveRemoved;

        public ElementsInfoViewModel(ElementScaner elementScaner)
        {
            _elementScaner = elementScaner;
        }

        public string Header => _elementScaner.Name;

        public bool HaveAdded
        {
            get => _haveAdded;
            
            private set
            {
                if (value != _haveAdded)
                {
                    _haveAdded = value;
                    OnPropertyChanged("HaveAdded");
                }
            }
        }
        public bool HaveChanged
        {
            get => _haveChanged;

            private set
            {
                if (value != _haveChanged)
                {
                    _haveChanged = value;
                    OnPropertyChanged("HaveChanged");
                }
            }
        }
        public bool HaveRemoved
        {
            get => _haveRemoved;

            private set
            {
                if (value != _haveRemoved)
                {
                    _haveRemoved = value;
                    OnPropertyChanged("HaveRemoved");
                }
            }
        }

        public ReadOnlyCollection<SystemElement> ShownElements => _elementScaner.Elements;

        public string Content { get; set; } = "test content";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
