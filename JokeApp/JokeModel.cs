namespace JokeApp
{
    public class JokeModel
    {


        public string Setup { get; set; }
        public string Delivery { get; set; }
        public string Category { get; set; }
        public string ID { get; set; }

        // TODO: santize string to avoid bad ',' in the joke text and switch delimtor to ','
        /// <summary>
        /// Overrides ToString, concates with '^; delimtor
        /// </summary>
        public new string ToString =>  $"{this.ID}^{this.Category}^{this.Setup}^{this.Delivery}";
    }
}
