using System.Management;

namespace SysSpy.Core.SystemElements
{
    /// <summary>
    /// Describes driver.
    /// </summary>
    class Driver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Driver"/> class.
        /// </summary>
        /// <param name="driver">Driver as <see cref="ManagementObject"/>.</param>
        public Driver(ManagementObject driver)
        {
            DisplayName = driver["DisplayName"].ToString();
            Name = driver["Name"].ToString();
            State = driver["State"].ToString();
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
    }
}
