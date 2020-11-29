using System;

namespace SysSpy.Models.SystemElements
{
    // todo add comments
    public abstract class SystemElement : IEquatable<SystemElement>
    {
        /// <summary>
        /// Element's unique ID.
        /// </summary>
        internal abstract object ID { get; }

        public bool Equals(SystemElement other)
        {
            if (other is null)
                return false;

            return ID.Equals(other.ID);
        }

        public override bool Equals(object obj) => Equals(obj as SystemElement);
        public override int GetHashCode() => ID.GetHashCode();
    }
}
