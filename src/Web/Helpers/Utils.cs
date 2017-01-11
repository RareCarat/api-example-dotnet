using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace API.RareCarat.Example.Helpers
{
    public static class Utils
    {
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .FirstOrDefault() as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;
        }
    }
}
