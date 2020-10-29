namespace SysSpy.Models.SystemElements
{
    /// <summary>
    /// Describes COM+ component.
    /// </summary>
    public class COMPlusComponent : SystemElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="COMPlusComponent"/> class.
        /// </summary>
        /// <param name="name">Component's name.</param>
        /// <param name="application">Application to which the component belongs.</param>
        public COMPlusComponent(string name, string application)
        {
            Name = name;
            Application = application;
        }

        /// <summary>
        /// Component's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Application to which the component belongs.
        /// </summary>
        public string Application { get; }
    }
}
