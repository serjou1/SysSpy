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

        private bool _haveChanged;

        public ElementsInfoViewModel(ElementScaner elementScaner)
        {
            _elementScaner = elementScaner;

            _elementScaner.AddedElementsFound += ElementScaner_AddedElementsFound;
            _elementScaner.RemovedElementsFound += ElementScaner_RemovedElementsFound;
        }

        public string Header => _elementScaner.Name;

        public bool HaveAdded => _elementScaner.AddedElements.Count > 0;
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
        public bool HaveRemoved => _elementScaner.RemovedElements.Count > 0;

        public ReadOnlyCollection<SystemElement> ShownElements => _elementScaner.Elements;

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void ElementScaner_AddedElementsFound(object sender, EventArgs e)
            => OnPropertyChanged("HaveAdded");

        private void ElementScaner_RemovedElementsFound(object sender, EventArgs e)
            => OnPropertyChanged("HaveRemoved");
    }
}
