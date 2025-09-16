using System.ComponentModel;
using System.Globalization;

namespace LocalizedBoundEnum
{
    [AttributeUsage(AttributeTargets.All)]
    internal class ResourceDescriptionAttribute : Attribute
    {
        private const string NOTFOUND = "<resource not found>";

        /// <summary>Specifies the default value for the <see cref="LocalizedBoundEnum.ResourceDescriptionAttribute" />, which is an empty string (""). This <see langword="static" /> field is read-only.</summary>
        public static readonly ResourceDescriptionAttribute Default = new ResourceDescriptionAttribute();
        private string? m_description;
        private static System.Resources.ResourceManager m_resourceManager;

        /// <summary>Initializes a new instance of the <see cref="T:LocalizedBoundEnum.ResourceDescriptionAttribute" /> class with no parameters.</summary>
        public ResourceDescriptionAttribute() : this(string.Empty)
        {
            m_description = NOTFOUND;
        }

        /// <summary>Initializes a new instance of the <see cref="LocalizedBoundEnum.ResourceDescriptionAttribute" /> class with a description.</summary>
        /// <param name="description">The description text.</param>
        public ResourceDescriptionAttribute(string description)
        {
            if (App.Current.Resources != null) // If we can't even find the resource class...
            {
                m_description = Strings.ResourceManager.GetString(description, CultureInfo.CurrentCulture) ?? NOTFOUND;
            }
        }

        /// <summary>Gets the description stored in this attribute.</summary>
        /// <returns>The description stored in this attribute.</returns>
        public virtual string? Description
        {
            get
            {
                return DescriptionValue;
            }
        }
        /// <summary>Gets or sets the string stored as the description.</summary>
        /// <returns>The string stored as the description. The default value is an empty string ("").</returns>
        protected string? DescriptionValue
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }
        /// <summary>Returns whether the value of the given object is equal to the current <see cref="T:LocalizedBoundEnum.ResourceDescriptionAttribute" />.</summary>
        /// <param name="obj">The object to test the value equality of.</param>
        /// <returns>
        /// <see langword="true" /> if the value of the given object is equal to that of the current; otherwise, <see langword = "false" />.</ returns >
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj is ResourceDescriptionAttribute descAttr)
            {
                return descAttr.Description == Description;
            }
            return false;
        }
        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Description!.GetHashCode();
        }
        /// <summary>Returns a value indicating whether this is the default <see cref="T:LocalizedBoundEnum.ResourceDescriptionAttribute" /> instance.</summary>
        /// <returns>
        /// <see langword="true" />, if this is the default <see cref="T:LocalizedBoundEnum.ResourceDescriptionAttribute" /> instance; otherwise, <see langword = "false" />.</ returns >
        public override bool IsDefaultAttribute()
        {
            return Equals((object)DescriptionAttribute.Default);
        }
    }
}
