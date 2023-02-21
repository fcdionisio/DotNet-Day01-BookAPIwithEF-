namespace BookAPIwithEF.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int AgeLimit { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
    }
}
