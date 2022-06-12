using JokeApp;
using JokeApp.Database;
using System.Configuration;

// set up
ApiHelper.InitializeApi();
string Filename = ConfigurationManager.AppSettings["filename"] ?? "lostJokes.csv";

// load saved data
List<JokeModel> Jokes = Filename.FilePath().ReadFile();

// get a new joke and save it
JokeModel Joke = await GetJoke.CallApi();
Jokes.Add(Joke);
Jokes.WriteFile(Filename);

// display info to user
Console.WriteLine("\n");
Console.WriteLine(Joke.Setup);
Console.WriteLine(Joke.Delivery);

Console.WriteLine("\n");
Console.WriteLine($"Category: {Joke.Category}");
Console.WriteLine($"Joke id: {Joke.ID}");
Console.WriteLine("\n");

//Console.ReadLine();