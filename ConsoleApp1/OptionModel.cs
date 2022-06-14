using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseJoke
{
    internal class OptionModel
    {
        public string Name { get; set; }
        public bool Selected { get; set; }

        public OptionModel(string name)
        {
            Name = name;
            Selected = false;
        }
    }
}
