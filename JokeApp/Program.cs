using JokeApp;
using JokeApp.Database;
using System.Configuration;

// set up

string Filename = ConfigurationManager.AppSettings["filename"] ?? "lostJokes.csv";

// load saved data
List<JokeModel> Jokes = Filename.FilePath().ReadFile();

// get a new joke and save it
using (var jokeClient = new JokeClient())
{
    JokeModel Joke = await jokeClient.GetJokeAsync(JokeCategory.Any);
    Jokes.Add(Joke);
    Jokes.WriteFile(Filename);

    // display info to user
    Console.WriteLine(Joke.Setup);
    Console.WriteLine(Joke.Delivery);

    Console.WriteLine("\n");
    Console.WriteLine($"Category: {Joke.Category}");
    Console.WriteLine($"Joke id: {Joke.ID}");
}
//Console.ReadLine();