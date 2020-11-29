using System;
using System.Collections;
using SysSpy.Models.Enums;
using SysSpy.Models.Interfaces;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models.Collectors
{
    // todo add comments
    public class EnvironmentVariablesCollector : ISystemElementsCollector
    {
        public SystemElementsCollection Collect()
        {
            var collection = new SystemElementsCollection();

            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
                collection.Add(new EnvironmentVariable(de.Key.ToString(), de.Value.ToString()) { Hive = Hive.Users });

            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
                collection.Add(new EnvironmentVariable(de.Key.ToString(), de.Value.ToString()) { Hive = Hive.Machines });

            return collection;
        }
    }
}
