using SysSpy.Models.Attributes;

namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes driver.
    /// </summary>
    [CollectionName("Drivers")]
    public class Driver : SystemElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Driver"/> class.
        /// </summary>
        /// <param name="displayName">Display Name of the driver.</param>
        /// <param name="name">Name of the driver.</param>
        /// <param name="state">State of the driver.</param>
        public Driver(string displayName, string name, string state)
        {
            DisplayName = displayName;
            Name = name;
            State = state;
        }

        /// <summary>
        /// Driver's display name.
        /// </summary>
        public string DisplayName { get; }
        /// <summary>
        /// Driver's name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Driver's state.
        /// </summary>
        public string State { get; }

        internal override object ID => Name;
    }
}
