namespace JokeApp
{
    public class JokeModel
    {


        public string? Setup { get; set; }
        public string? Delivery { get; set; }
        public string? Category { get; set; }
        public int? ID { get; set; }

        
        /// <summary>
        /// Converts Joke Model to string while sanitizing
        /// </summary>
        public  string JokeForCSV => $"{ID?.ToString().PrepStringForCSV()},{Category?.PrepStringForCSV()},{Setup?.PrepStringForCSV()},{Delivery?.PrepStringForCSV()}";
            
    }
}
