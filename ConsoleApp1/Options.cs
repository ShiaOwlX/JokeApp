using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseJoke
{
    internal class Options
    {
        /// <summary>
        /// Create a list of Categories for joke selection
        /// </summary>
        /// <returns>List of OptionModels</returns>
        public static List<OptionModel> Categories(List<string> optionStrings)
        {
            List<OptionModel> options = new();
            foreach (string category in optionStrings)
            {
                options.Add(new OptionModel(category));
            }
            return options;
        }


    }
}
