using SysSpy.Models.Attributes;

namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes startup pogram.
    /// </summary>
    [CollectionName("Startup Programs")]
    public class StartupProgram : SystemElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartupProgram"/> class.
        /// </summary>
        /// <param name="name">Startup's name.</param>
        /// <param name="location">Startup's location.</param>
        public StartupProgram(string name, string location)
        {
            Name = name;
            Location = location;
        }

        /// <summary>
        /// Startup's name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Startup's location.
        /// </summary>
        public string Location { get; }

        internal override object ID => Name;
    }
}
