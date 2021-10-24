using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data
{
    public static class EnumExtensions
    {
        public static string GetStringValue<T>(this T enumearble)
        {
            var stringVaueAttribute= enumearble
                .GetType()
                .GetCustomAttributes(true)
                .Where(x => x.GetType() == typeof(StringValueAttribute))
                .FirstOrDefault();

            if (stringVaueAttribute != null)
            {
                var propertyInfo = stringVaueAttribute.GetType().GetProperty(nameof(StringValueAttribute.StringValue));
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(stringVaueAttribute);
                    if (propertyValue != null)
                    {
                        return propertyValue.ToString();
                    }
                }
            }

            return enumearble.ToString();
        }
    }
}
