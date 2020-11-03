using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysSpy.Models;
using SysSpy.Models.Interfaces;

namespace SysSpy.Scanning
{
    public class ElementScaner
    {
        private readonly ISystemElementsCollector _collector;

        private readonly SystemElementsCollection _addedElements;
        private readonly SystemElementsCollection _removedElements;

        private SystemElementsCollection _elements;

        public ElementScaner(ISystemElementsCollector collector, string name)
        {
            _collector = collector;

            _addedElements = new SystemElementsCollection(name);
            _removedElements = new SystemElementsCollection(name);

            GetInitialCollection();
        }

        public void Scan()
        {
            var currentElements = _collector.Collect();

            var added = currentElements.Except(_elements);
            _addedElements.AddRange(added);

            var removed = _elements.Except(currentElements);
            _removedElements.AddRange(removed);
        }

        private void GetInitialCollection()
        {
            _elements = _collector.Collect();
        }
    }
}
