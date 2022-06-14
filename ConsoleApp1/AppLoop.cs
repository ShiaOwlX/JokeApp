using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseJoke
{
    internal class AppLoop
    {
        /// <summary>
        /// Loads Menu and runs a loop to get users selection
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Comma separated list of users choice</returns>
        public static string Run( List<OptionModel> options)
        {
            var menu = new Menu();
            var selectedOption = 0;
            menu.LoadMenu(options, options[selectedOption]);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            selectedOption++;
                            if (selectedOption >= options.Count)
                            {
                                selectedOption = 0;
                            }
                            menu.LoadMenu(options, options[selectedOption]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            selectedOption--;
                            if (selectedOption < 0)
                            {
                                selectedOption = options.Count - 1;
                            }
                            menu.LoadMenu(options, options[selectedOption]);
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            options[selectedOption].Selected = !options[selectedOption].Selected;
                            menu.LoadMenu(options, options[selectedOption]);
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            StringBuilder stringBuilder = new();
                            foreach (var option in options)
                            {
                                if (option.Selected)
                                {
                                    stringBuilder.Append(option.Name + ',');
                                }
                            }

                            if (stringBuilder.Length != 0)
                            {
                                stringBuilder.Length--;
                            }
                            else
                            {
                                stringBuilder = new StringBuilder(AppStrings.DefaultJokeParam);
                            }
                            return stringBuilder.ToString();
                        }     
                }
            } while (true);
        }
    }
}
