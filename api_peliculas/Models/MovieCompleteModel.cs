namespace api_peliculas.Models
{
    public partial class MovieCompleteModel
    {
        public long Page { get; set; }
        public List<Result> Results { get; set; }
        public long TotalPages { get; set; }
        public long TotalResults { get; set; }
    }

    public partial class Result
    {
        public bool Adult { get; set; }
        public string backdrop_path { get; set; }
        public List<long> genre_ids { get; set; }
        public long Id { get; set; }
        public OriginalLanguage OriginalLanguage { get; set; }
        public string original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double vote_average { get; set; }
        public long vote_count { get; set; }
    }

    public enum OriginalLanguage { En, Ja, No, Te };

}
