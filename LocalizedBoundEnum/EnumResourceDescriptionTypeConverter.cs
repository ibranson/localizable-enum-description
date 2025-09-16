using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace LocalizedBoundEnum
{
    internal class EnumResourceDescriptionTypeConverter : EnumConverter
    {
        public EnumResourceDescriptionTypeConverter(Type type)
        : base(type)
        {
        }
        public override object? ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    if (value.GetType().GetField(value.ToString()) is FieldInfo fi)
                    {
                        // Fetch all the instances of ResourceDescription(Attribute) decorating the enum member
                        var attributes = (ResourceDescriptionAttribute[])fi.GetCustomAttributes(typeof(ResourceDescriptionAttribute), false);

                        // The conversion from key to value is done upstream by the ResourceDescriptionAttribute
                        return ((attributes.Length > 0) && (!string.IsNullOrEmpty(attributes[0].Description))) ? attributes[0].Description : value.ToString();
                    }
                }

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
