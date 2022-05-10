using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data
{
    public static class EnumExtensions
    {
        public static string GetStringValue<T>(this T enumerable)
        {
            var stringValueAttribute = enumerable
                .GetType()
                .GetCustomAttributes(true)
                .FirstOrDefault(x => x.GetType() == typeof(StringValueAttribute));

            if (stringValueAttribute != null)
            {
                var propertyInfo = stringValueAttribute.GetType().GetProperty(nameof(StringValueAttribute.StringValue));
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(stringValueAttribute);
                    if (propertyValue != null)
                    {
                        return propertyValue.ToString();
                    }
                }
            }

            return enumerable.ToString();
        }
    }
}
