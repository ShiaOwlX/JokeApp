using JokeApp;
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
        public static async Task RunAsync(List<OptionModel> options)
        {

            var menu = new Menu();
            using var jokeClient = new JokeClient();
            var selectedOption = 0;
            do
            {
                menu.LoadMenu(options, options[selectedOption]);

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
                            
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            selectedOption--;
                            if (selectedOption < 0)
                            {
                                selectedOption = options.Count - 1;
                            }
                            
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            options[selectedOption].Selected = !options[selectedOption].Selected;
                            
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            JokeCategory jokeCategory =  JokeCategory.Any;
                            foreach (var option in options)
                            {
                                if (option.Selected)
                                {
                                    jokeCategory |= (JokeCategory)Enum.Parse(typeof(JokeCategory),option.Name);
                                }
                            }

                            

                            JokeModel Joke = await jokeClient.GetJokeAsync(jokeCategory);

                            Console.Clear();
                            Console.WriteLine(Joke.Setup);
                            Console.WriteLine(Joke.Delivery);
                            Console.WriteLine();
                            Console.WriteLine(AppStrings.EnterToContinue);
                            Console.ReadLine();
                            
                        }
                        break;
                }
            } while (true);
        }
    }
}
