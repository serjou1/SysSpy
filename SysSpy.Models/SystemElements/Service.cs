using SysSpy.Models.Attributes;

namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes Windows service.
    /// </summary>
    [CollectionName("Services")]
    public class Service : SystemElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="displayname">Service's display name.</param>
        /// <param name="servicename">Service's service name.</param>
        /// <param name="starttype">Service's start type.</param>
        /// <param name="status">Service's status.</param>
        public Service(string displayName,
            string serviceName,
            string startType,
            string status)
        {
            DisplayName = displayName;
            ServiceName = serviceName;
            StartType = startType;
            Status = status;
        }

        /// <summary>
        /// Service's display name.
        /// </summary>
        public string DisplayName { get; }
        /// <summary>
        /// Service's service name.
        /// </summary>
        public string ServiceName { get; }
        /// <summary>
        /// Service's start type.
        /// </summary>
        public string StartType { get; }
        /// <summary>
        /// Service's status.
        /// </summary>
        public string Status { get; }

        internal override object ID => ServiceName;
    }
}
