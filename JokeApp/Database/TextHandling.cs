using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp
{
    public static class TextHandling
    {
        /// <summary>
        /// Wrap text in qoutes and swap '"' for '""'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string PrepStringForCSV(this string value)
        {
            return "\"" + value.Replace(oldValue: "\"", newValue: "\"\"") + "\"";
        }
        /// <summary>
        /// Remove CSV wrappings
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string PrepStringFromCSV(this string value)
        {
            return value.Substring(1, value.Length - 2).Replace(oldValue: "\"\"", newValue: "\"");
        }
    }
}
