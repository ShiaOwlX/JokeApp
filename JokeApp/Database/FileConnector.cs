using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp.Database
{
    public static class FileConnector
    {
        public static string FilePath(this string fileName)
        {
            // get app config path if set
            string folder = ConfigurationManager.AppSettings["dataLocation"] ?? @"C:\lost";
            // make sure folder exsits
            InitializeFolder(folder);

            return $"{folder}\\{fileName}";
        }

        // check if folder exists
        internal static void InitializeFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        // read file, convert each line to a joke model and return a list (if no file retirn empty)
        public static List<JokeModel> ReadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<JokeModel>();
            }

            List<string> Lines = File.ReadAllLines(file).ToList();

            // new list to add each joke
            List<JokeModel> Jokes = new List<JokeModel>();

            // convert joke and add to list
            foreach (string line in Lines)
            {
                string[] parts = line.Split('^');
                JokeModel j = new JokeModel();
                j.ID = parts[0];
                j.Category = parts[1];
                j.Setup = parts[2];
                j.Delivery = parts[3];
                Jokes.Add(j);
            }
            return Jokes;
        }

        // save all jokes to file
        public static void WriteFile(this List<JokeModel> jokes, string filename)
        {
            // new list for each row in the csv
            List<string> JokeLines = new List<string>();

            // convert to string and add to list
            foreach (JokeModel joke in jokes)
            {
                string JokeLine = joke.ToString;
                JokeLines.Add(JokeLine);
            }

            // save data to file
            File.WriteAllLines(filename.FilePath(), JokeLines);
        }
    }
}
