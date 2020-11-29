using System;

namespace SysSpy.Models.Attributes
{
    /// <summary>
    /// Describes name of elements collection.
    /// </summary>
    public class CollectionNameAttribute : Attribute
    {
        public CollectionNameAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

        /// <summary>
        /// Name of collection.
        /// </summary>
        public string CollectionName { get; }
    }
}
