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
        /// <summary>
        /// Gets the file path from config and appends  'filename'
        /// </summary>
        /// <param name="fileName">
        /// name of file (do not add leading slash)
        /// </param>
        /// <returns> String of proper path</returns>
        public static string FilePath(this string fileName)
        {
            // get app config path if set
            string folder = ConfigurationManager.AppSettings["dataLocation"] ?? @"C:\lost";
            // make sure folder exsits
            InitializeFolder(folder);

            return $"{folder}\\{fileName}";
        }

        /// <summary>
        /// Make sure folder exsits, create if not found
        /// </summary>
        /// <param name="folder"> Path to folder</param>
        internal static void InitializeFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        /// <summary>
        /// Read file (full path), convert each line to a joke model and return a List<JokeModel> (if no file returns empty List<JokeModel>)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<JokeModel> ReadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<JokeModel>();
            }

            List<string> Lines = File.ReadAllLines(file).ToList();

            // new list to add each joke
            List<JokeModel> Jokes = new();

            // convert joke and add to list
            foreach (string line in Lines)
            {
                string[] parts = line.Split(',');
                JokeModel j = new()
                {
                    ID = int.Parse(parts[0].PrepStringFromCSV()),
                    Category = parts[1].PrepStringFromCSV(),
                    Setup = parts[2].PrepStringFromCSV(),
                    Delivery = parts[3].PrepStringFromCSV()
                };
                Jokes.Add(j);
            }
            return Jokes;
        }

        /// <summary>
        /// Save all jokes to file
        /// </summary>
        /// <param name="jokes"></param>
        /// <param name="filename"></param>
        public static void WriteFile(this List<JokeModel> jokes, string filename)
        {
            // new list for each row in the csv
            List<string> JokeLines = new();

            // convert to string and add to list
            foreach (JokeModel joke in jokes)
            {
                string JokeLine = joke.JokeForCSV;
                JokeLines.Add(JokeLine);
            }

            // save data to file
            File.WriteAllLines(filename.FilePath(), JokeLines);
        }
    }
}
