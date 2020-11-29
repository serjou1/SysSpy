using System;
using System.Collections.Generic;
using SysSpy.Models.SystemElements;

namespace SysSpy.Models
{
    // todo add comments
    public class SystemElementsCollection : List<SystemElement>
    {
        //private readonly Type _type;

        public SystemElementsCollection(/*string name, Type type*/)
        {
            //Name = name;

            //_type = type;
        }

        //public string Name { get; }

        //public new void Add(SystemElement item)
        //{
        //    if (!item.GetType().Equals(_type))
        //        throw WrongTypeException();

        //    Add(item);
        //}
    }
}
