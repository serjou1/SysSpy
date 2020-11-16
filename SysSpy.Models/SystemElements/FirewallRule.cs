using SysSpy.Models.Attributes;

namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes firewall rule.
    /// </summary>
    [CollectionName("Firewall Rules")]
    public class FirewallRule : SystemElement
    {
        private FirewallRule() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FirewallRule"/> class.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <param name="isEnabled">Is the rule enabled.</param>
        /// <param name="localAddresses">Local addresses of the rule.</param>
        /// <param name="localPorts">Local ports of the rule.</param>
        /// <param name="remoteAddresses">Remote addresses of the rule.</param>
        /// <param name="remotePorts">Remote ports of the rule.</param>
        public FirewallRule(string name,
            bool isEnabled,
            string localAddresses,
            string localPorts,
            string remoteAddresses,
            string remotePorts)
        {
            Name = name;
            IsEnabled = isEnabled;
            LocalAddresses = localAddresses;
            LocalPorts = localPorts;
            RemoteAddresses = remoteAddresses;
            RemotePorts = remotePorts;
        }

        /// <summary>
        /// Rule's name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Is rule enabled.
        /// </summary>
        public bool IsEnabled { get; }
        /// <summary>
        /// Rule's local addresses.
        /// </summary>
        public string LocalAddresses { get; }
        /// <summary>
        /// Rule's local ports.
        /// </summary>
        public string LocalPorts { get; }
        /// <summary>
        /// Rule's remote addresses.
        /// </summary>
        public string RemoteAddresses { get; }
        /// <summary>
        /// Rule's remote ports.
        /// </summary>
        public string RemotePorts { get; }
    }
}
