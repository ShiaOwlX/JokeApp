using System.Text;
using ChooseJoke;
using JokeApp;


List<OptionModel> options = Options.Categories(AppStrings.options);
string config = AppLoop.Run(options: options);
//menu.LoadMenu(options, options[selectedOption]);
ApiHelper.InitializeApi();
JokeModel Joke = await GetJoke.CallApi(config);
Console.Clear();
Console.WriteLine(Joke.Setup);
Console.WriteLine(Joke.Delivery);
Console.WriteLine();



