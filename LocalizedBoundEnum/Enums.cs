using System.ComponentModel;

namespace LocalizedBoundEnum
{
    [TypeConverter(typeof(EnumResourceDescriptionTypeConverter))]
    internal enum Options
    {
        [ResourceDescription("Combo1_Unselected")]          // Key (not value) in the Strings.resx file, NOT the actual string.
        Unselected,
        [ResourceDescription("Combo1_Option1")] 
        FirstOption,
        [ResourceDescription("Combo1_Option2")]
        SecondOption,
        [ResourceDescription("Combo1_Option3")]
        ThirdOption
    }
}
