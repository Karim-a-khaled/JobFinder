using System.Reflection;

namespace JobFinder.Entities
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnumValues<T>(bool excludeDefualt = false)
            where T : struct, IConvertible
        {
            // Can't use type constraints on value types, so have to do check like this
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();

            return excludeDefualt ? enumValues.Where(e => Convert.ToInt32(e) != 0) : enumValues;
        }

        public static string ToEnumDisplay(this Enum enumValue)
        {
            Type type = enumValue.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException("enumValue must be of Enum type", "enumValue");
            }

            FieldInfo fieldInfo = type.GetField(enumValue.ToString());

            if (fieldInfo == null || fieldInfo.GetCustomAttribute(typeof(EnumDisplayAttribute)) == null)
            {
                throw new ArgumentException("enumValue must contains the EnumDisplayAttribute", "enumValue");
            }

            EnumDisplayAttribute attribute = (EnumDisplayAttribute)fieldInfo.GetCustomAttribute(typeof(EnumDisplayAttribute));


            return attribute.Text;
        }

    }


    public class EnumDisplayAttribute : System.Attribute
    {
        public string Text { get; set; }


        public EnumDisplayAttribute(string text)
        {

            Text = text;
        }


    }
}