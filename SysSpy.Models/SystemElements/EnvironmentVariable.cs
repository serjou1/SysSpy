using SysSpy.Models.Attributes;
using SysSpy.Models.Enums;

namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes environment variable.
    /// </summary>
    [CollectionName("Environment Variables")]
    public class EnvironmentVariable : SystemElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentVariable"/> class.
        /// </summary>
        /// <param name="name">Variable's name.</param>
        /// <param name="value">Variable's value.</param>
        public EnvironmentVariable(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Variable's name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Variable's value.
        /// </summary>
        public string Value { get; }

        public Hive Hive { get; set; }

        internal override object ID { get { return Name + Hive; } }
    }
}
