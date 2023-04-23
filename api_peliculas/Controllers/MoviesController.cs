using api_peliculas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api_peliculas.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MoviesController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }; 

        [HttpGet("{title}", Name = "GetMovies")]
        public async Task<ActionResult<MovieModel>> GetMovies(string title)
        {
            HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/now_playing?api_key=a847973815573f73a0ba6c59d790d0f9&language=es-ES&page=1");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var dataResult = JsonSerializer.Deserialize<MovieCompleteModel>(responseBody, options);

            MovieModel movieList = new MovieModel();
            movieList.TitleYear = new List<string>();
            
            for (int i = 0; i < dataResult.Results.Count - 1; i++)
            {
                if (title.Trim().ToUpper() == dataResult.Results[i].Title.Trim().ToUpper())
                {
                    movieList.Title = dataResult.Results[i].Title;
                    movieList.Original_Title = dataResult.Results[i].Original_Title;
                    movieList.Vote_Average = dataResult.Results[i].Vote_Average;
                    movieList.Release_Date = dataResult.Results[i].Release_Date.ToString("dd/MM/yyyy");
                    movieList.Overview = dataResult.Results[i].Overview;
                    var genero = dataResult.Results[i].Genre_Ids;
                    for (int j = 0; j < dataResult.Results.Count - 1; j++)
                    {
                        foreach (var k in dataResult.Results[j].Genre_Ids)
                        {
                            if (genero[0] == k && title.Trim().ToUpper() != dataResult.Results[j].Title.Trim().ToUpper())
                            {
                                if (movieList.TitleYear.Count < 5)
                                {
                                    movieList.TitleYear.Add(dataResult.Results[j].Title + " (" + (dataResult.Results[j].Release_Date).ToString("yyyy") + ")");
                                }
                                break;
                            }
                        }
                    }
                }
            }
            if (movieList.Title == null)
            {
                return NotFound("No existe el titulo");
            }
            return movieList;
        }
    }
}
