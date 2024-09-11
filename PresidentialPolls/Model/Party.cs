using System.Reflection;

namespace PresidentialPolls.Model
{
    public enum Party
    {
        None,
        Democrat,
        Republican,
        Other,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ColorAttribute(string value) : Attribute
    {
        public string Value { get; protected set; } = value;
    }
    public class IdAttribute(string value) : ColorAttribute(value)
    {
    }

    public static class AttributeUtilities
    {
        public static string GetId(this Enum value)
        {
            Type type = value.GetType();
            if( !type.IsEnum )
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(value));

            FieldInfo? fieldInfo = type.GetField(value.ToString());

            IdAttribute? Attribute = fieldInfo?.GetCustomAttribute(
                typeof(IdAttribute)
            ) as IdAttribute;

            string? altValue = Attribute?.Value;
            if( altValue == null )
                return string.Empty;
            return altValue;
        }
    }
    public enum Candidate
    {
        [IdAttribute("10027")]
        Harris,

        [IdAttribute("10011")]
        Biden,

        [IdAttribute("10001")]
        Trump
    }
}

