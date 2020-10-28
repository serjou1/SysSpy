using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysSpy.Core;
using SysSpy.Core.Interfaces;
using SysSpy.Core.SystemElements;

namespace SysSpy.Snapshots
{
    public class Snapshot
    {
        private static List<Type> registeredTypes = new List<Type>();

        public Snapshot(string name)
        {
            Name = name;

            Collectors = new List<ISystemElementsCollector>();
            InitiateCollection();
        }

        public string Name { get; }

        public List<SystemElementsCollection> Collectors { get; }

        public static void RegisterType<T>() where T : SystemElement => registeredTypes.Add(typeof(T));

        public void Take()
        {
            foreach (var collection in Collectors)
                collection.Get();
        }

        private void InitiateCollection()
        {
            foreach(var type in registeredTypes)
            {
                var collectionType = typeof(SystemElementsCollection<>).MakeGenericType(type);
                var collection =(ISystemElementsCollection)Activator.CreateInstance(collectionType);
                Collectors.Add(collection);
            }
        }
    }
}
