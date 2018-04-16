using System;
using System.ComponentModel;

namespace Tsa.CodingChallenge.Submissions.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string Description(this Enum enumInstance)
        {
            var type = enumInstance.GetType();

            var memberInfos = type.GetMember(enumInstance.ToString());

            if (memberInfos.Length <= 0) return enumInstance.ToString();

            var customAttributes = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return customAttributes.Length > 0
                ? ((DescriptionAttribute)customAttributes[0]).Description
                : enumInstance.ToString();
        }
    }
}