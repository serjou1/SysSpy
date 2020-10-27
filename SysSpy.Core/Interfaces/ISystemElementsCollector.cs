using SysSpy.Core.SystemElements;

namespace SysSpy.Core.Interfaces
{
    public interface ISystemElementsCollector<T>
        : ISystemElementsCollector
        where T : SystemElement
    {
        SystemElementsCollection<T> ISystemElementsCollector.Collect();
    }

    public interface ISystemElementsCollector
    {
        SystemElementsCollection<SystemElement> Collect();
    }
}
