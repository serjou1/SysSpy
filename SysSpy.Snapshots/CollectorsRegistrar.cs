//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using SysSpy.Core.Interfaces;
//using SysSpy.Core.SystemElements;
//using SysSpy.Snapshots.Exceptions;

//namespace SysSpy.Snapshots
//{
//    public class CollectorsRegistrar
//    {
//        public readonly Dictionary<Type, object> _typesAndCollectors;

//        public CollectorsRegistrar()
//        {
//            _typesAndCollectors = new Dictionary<Type, object>();
//        }

//        public ReadOnlyCollection<Type> RegisteredTypes => _typesAndCollectors.Select(x => x.Key).ToList().AsReadOnly();

//        public void RegisterElementAndCollector<T>(object collectorToRegister)
//            where T : SystemElement
//        {
//            if (!collectorToRegister.GetType().IsSubclassOf(typeof(ISystemElementsCollector<T>)))
//                throw new CollectorRegistrationException(string.Format("Object of type {0} can not be used for collecting objects of type {1} as it is not deliviered from {2}",
//                    collectorToRegister.GetType(),
//                    typeof(T),
//                    typeof(ISystemElementsCollector<T>)));

//            _typesAndCollectors.Add(typeof(T), collectorToRegister);
//        }

//        public ISystemElementsCollector<T> GetCollector<T>() where T : SystemElement
//        {
//            return (ISystemElementsCollector<T>)_typesAndCollectors[typeof(T)];
//        }
//    }
//}
