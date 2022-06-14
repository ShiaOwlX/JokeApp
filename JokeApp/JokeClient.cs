using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeApp
{
    public class JokeClient : IDisposable
    {
        private readonly JokeHttpClient _httpClient = new();

        public void Dispose()
        {
            _httpClient.Dispose();
            // TODO: IDE wants this, why??
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Calls the Joke API 
        /// </summary>
        /// <returns>
        /// Joke as JokeModel
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<JokeModel> GetJokeAsync(JokeCategory jokeCategory)
        {
            // TODO: set config for joke catagory, style, nsfw etc

            // Remove spaces
            var category = jokeCategory.ToString().Replace(" ", "");
            
            // saving memory
            using HttpResponseMessage response = await _httpClient.GetAsync($"joke/{category}?type=twopart");
            if (response.IsSuccessStatusCode)
            {
                // get response and extract only the fields of the joke
                var JokeResponse = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(JokeResponse))
                {
                    throw new Exception("Joke response null or empty");
                }
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var Joke = JsonSerializer.Deserialize<JokeModel>(JokeResponse, options);
                if (Joke == null)
                {
                    throw new Exception("JokeModel is null");
                }
                return (JokeModel)Joke;


            }
            else
            {
                // blow up if non success code
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
