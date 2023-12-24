using EMS_DAL.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Helper
{
    public  class EnumHelper<T> where T : struct,System.Enum
    {
        public static List<EnumValueDto> GetEnumValues()
        {
            List<EnumValueDto> enumValues = new List<EnumValueDto>();

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                string enumDescription = GetEnumDescription(value);

                enumValues.Add(new EnumValueDto
                {
                    Value = (int)(object)value,
                    Name = value.ToString(),
                    Description = enumDescription
                });
            }
            return enumValues;
        }

        private static string GetEnumDescription(T value)
        {
            var fieldInfo = typeof(T).GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : value.ToString();
        }

    }

}

