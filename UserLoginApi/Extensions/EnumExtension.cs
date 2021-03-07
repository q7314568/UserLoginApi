using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UserLoginApi.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum currentEnum)
        {
            string description = String.Empty;
            DescriptionAttribute da;

            FieldInfo fi = currentEnum.GetType().
                        GetField(currentEnum.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                        typeof(DescriptionAttribute));
            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return description;
        }


        public static int GetValue<T>(this Enum currentEnum)
        {
            var result = Convert.ToInt32((T)Enum.Parse(typeof(T), currentEnum.ToString()));
            return result;
        }

        public static int GetValue(this Enum value)
        {
            var type = value.GetType();
            if (!Enum.IsDefined(type, value))
            {
                throw new Exception($"{type} 找不到此定義值({value.ToString()})");
            }

            return Convert.ToInt32(value);
        }

        public static int ToInteger(this System.Enum value)
        {
            return value.GetHashCode();
        }
    }
}
