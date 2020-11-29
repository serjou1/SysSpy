using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;
using SysSpy.Snapshots.Exceptions;

namespace SysSpy.Snapshots
{
    // todo add comments
    public class CollectorsRegistrar
    {
        public readonly Dictionary<Type, ISystemElementsCollector> _typesAndCollectors;

        public CollectorsRegistrar()
        {
            _typesAndCollectors = new Dictionary<Type, ISystemElementsCollector>();
        }

        public ReadOnlyCollection<Type> RegisteredTypes => _typesAndCollectors.Select(x => x.Key).ToList().AsReadOnly();

        public void RegisterElementAndCollector<T>(ISystemElementsCollector collectorToRegister)
            where T : SystemElement
        {
            //if (!collectorToRegister.GetType().IsSubclassOf(typeof(ISystemElementsCollector<T>)))
            //    throw new CollectorRegistrationException(string.Format("Object of type {0} can not be used for collecting objects of type {1} as it is not deliviered from {2}",
            //        collectorToRegister.GetType(),
            //        typeof(T),
            //        typeof(ISystemElementsCollector<T>)));

            _typesAndCollectors.Add(typeof(T), collectorToRegister);
        }

        public ISystemElementsCollector GetCollector(Type t)
        {
            return _typesAndCollectors[t];
        }
    }
}
