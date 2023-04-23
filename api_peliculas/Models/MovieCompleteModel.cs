namespace api_peliculas.Models
{
    public partial class MovieCompleteModel
    {
        public Dates Dates { get; set; }
        public long Page { get; set; }
        public List<Result> Results { get; set; }
        public long Total_Pages { get; set; }
        public long Total_Results { get; set; }
    }

    public partial class Dates
    {
        public DateTimeOffset Maximum { get; set; }
        public DateTimeOffset Minimum { get; set; }
    }

    public partial class Result
    {
        public bool Adult { get; set; }
        public string Backdrop_Path { get; set; }
        public List<long> Genre_Ids { get; set; }
        public long Id { get; set; }
        public OriginalLanguage OriginalLanguage { get; set; }
        public string Original_Title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_Path { get; set; }
        public DateTime Release_Date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public long Vote_Count { get; set; }
    }

    public enum OriginalLanguage { En, Es };

}
