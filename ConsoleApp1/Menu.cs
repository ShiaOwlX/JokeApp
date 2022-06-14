using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseJoke
{
    class Menu
    {
        public void LoadMenu(List<OptionModel> options, OptionModel selected)
        {
            Console.Clear();
            Console.WriteLine(AppStrings.MakeSelection);
            foreach (OptionModel option in options)
            {
                
                if (option.Selected)
                {
                    Console.Write("> ");
                } else
                {
                    Console.Write("  ");
                }
                if (option == selected)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(option.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(AppStrings.SelectionInstructions);
        }
    }
}
