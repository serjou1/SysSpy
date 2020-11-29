using System;

namespace SysSpy.Snapshots.Exceptions
{
    public class CollectorRegistrationException : Exception
    {
        public CollectorRegistrationException(string message) : base(message) { }
    }
}
