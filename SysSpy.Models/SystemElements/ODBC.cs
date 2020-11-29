using SysSpy.Models.Attributes;

namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes ODBC.
    /// </summary>
    [CollectionName("ODBCs")]
    public class ODBC : SystemElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ODBC"/> class.
        /// </summary>
        /// <param name="name">ODBC's name.</param>
        public ODBC(string name)
        {
            Name = name;
        }

        /// <summary>
        /// ODBC's name.
        /// </summary>
        public string Name { get; }

        internal override object ID => Name;
    }
}
