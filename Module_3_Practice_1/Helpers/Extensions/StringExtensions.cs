using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3_Practice_1.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string text)
        {
            int result;
            return int.TryParse(text, out result);
        }
    }
}
