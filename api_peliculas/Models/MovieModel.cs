namespace api_peliculas.Models
{
    public class MovieModel
    {
        public string Title { get; set; }
        public string Original_Title { get; set; }
        public double Vote_Average { get; set; }
        public string Release_Date { get; set; }
        public string Overview { get; set; }
        public List<string> TitleYear { get; set; }
        
    }
}
