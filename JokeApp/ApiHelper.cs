using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp
{
    public class ApiHelper
    {
        public static HttpClient Instance { get; set; }= new HttpClient();

        /// <summary>
        /// Set up HttpClient with header and base URI
        /// </summary>
        public static void InitializeApi()
        {
            Instance.DefaultRequestHeaders.Accept.Clear();
            Instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Instance.BaseAddress = new Uri("https://v2.jokeapi.dev/");

        }
    }
}
