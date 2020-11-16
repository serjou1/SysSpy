using System;

namespace SysSpy.Models.Attributes
{
    public class CollectionNameAttribute : Attribute
    {
        public CollectionNameAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }
    }
}
