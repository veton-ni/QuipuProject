using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuipuWeb.Extension
{
    public static class EnumToListExtansion
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(enu => new SelectListItem() { Text = enu!.ToString(), Value = enu.ToString() })
                .ToList();
        }


        /// <summary>
        /// Extension method to return an enum value of type T for the given string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Extension method to return an enum value of type T for the given int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            var name = Enum.GetName(typeof(T), value);
            return name.ToEnum<T>();
        }
    }
}
