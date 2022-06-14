using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp
{
    public class JokeHttpClient : HttpClient
    {
        public JokeHttpClient() : base()
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            BaseAddress = new Uri("https://v2.jokeapi.dev/");
        }
    }
}
