using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseJoke
{
    internal class AppStrings
    {
        internal static string SelectionInstructions = "Use arrow keys to highligh, space to select. Press enter when finished";
        internal static string MakeSelection = "Please select the categories of jokes you want.";
        /// <summary>
        /// 
        /// </summary>
        internal static List<string> options = new()
        {
            "Programming",
            "Miscellaneous",
            "Dark",
            "Pun",
            "Spooky",
            "Christmas"
        };

        public static string DefaultJokeParam = "Any";
    }
}
