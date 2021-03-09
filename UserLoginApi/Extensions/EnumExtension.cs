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

        /// <summary>
        /// 傳入Enum參數來取得值，並依照傳入的泛型來規範值的範圍
        /// </summary>
        /// <typeparam name="T">供傳入值解析用的泛型</typeparam>
        /// <param name="currentEnum">傳入的Enum參數</param>
        /// <returns></returns>
        public static int GetValue<T>(this Enum currentEnum)
        {
            var result = Convert.ToInt32((T)Enum.Parse(typeof(T), currentEnum.ToString()));
            return result;
        }


        /// <summary>
        /// 傳入Enum參數來取得Int值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetValue(this Enum value)
        {
            var type = value.GetType();
            if (!Enum.IsDefined(type, value))
            {
                throw new Exception($"{type} 找不到此定義值({value.ToString()})");
            }

            return Convert.ToInt32(value);
        }


        /// <summary>
        /// 傳入Enum參數來取得值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInteger(this System.Enum value)
        {
            return value.GetHashCode();
        }
    }
}
