using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SysSpy.Models;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;

namespace SysSpy.Scanning
{
    // todo add comments
    public class ElementScaner
    {
        private readonly ISystemElementsCollector _collector;

        private readonly SystemElementsCollection _addedElements;
        private readonly SystemElementsCollection _removedElements;

        private SystemElementsCollection _elements;

        public ElementScaner(ISystemElementsCollector collector, string name)
        {
            _collector = collector;

            _addedElements = new SystemElementsCollection();
            _removedElements = new SystemElementsCollection();

            Name = name;

            GetInitialCollection();
        }

        public event EventHandler ElementsUpdated;
        public event EventHandler AddedElementsFound;
        public event EventHandler ChangedElementsFound;
        public event EventHandler RemovedElementsFound;

        public ReadOnlyCollection<SystemElement> Elements => _elements.AsReadOnly();
        public ReadOnlyCollection<SystemElement> AddedElements => _addedElements.AsReadOnly();
        public ReadOnlyCollection<SystemElement> RemovedElements => _removedElements.AsReadOnly();

        public string Name { get; }

        public void Scan()
        {
            var currentElements = _collector.Collect();

            var added = currentElements.Except(_elements).ToList();
            var addedCount = added.Count;
            if (addedCount > 0)
            {
                _addedElements.AddRange(added);
                AddedElementsFound?.Invoke(this, null);
            }

            var removed = _elements.Except(currentElements).ToList();
            var removedCount = removed.Count;
            if (removedCount > 0)
            {
                _removedElements.AddRange(removed);
                RemovedElementsFound?.Invoke(this, null);
            }

            if (addedCount > 0 || removedCount > 0)
            {
                _elements = currentElements;
                ElementsUpdated?.Invoke(this, null);
            }
        }

        private void GetInitialCollection()
        {
            _elements = _collector.Collect();
        }
    }
}
