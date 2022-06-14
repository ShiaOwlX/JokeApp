using System.Text;
using ChooseJoke;
using JokeApp;


List<OptionModel> options = Options.Categories();
await AppLoop.RunAsync(options: options);




