namespace JokeApp
{
    public class JokeModel
    {


        public string Setup { get; set; } = "Empty";
        public string Delivery { get; set; } = "Empty";
        public string Category { get; set; } = "Unknown";
        public string ID { get; set; } = "0";

        
        /// <summary>
        /// Converts Joke Model to string while sanitizing
        /// </summary>
        public  string JokeForCSV => $"{ID.PrepStringForCSV()},{Category.PrepStringForCSV()},{Setup.PrepStringForCSV()},{Delivery.PrepStringForCSV()}";
            
    }
}
