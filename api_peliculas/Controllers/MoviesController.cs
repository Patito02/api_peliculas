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
            HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=a847973815573f73a0ba6c59d790d0f9&query=" + title);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var dataResult = JsonSerializer.Deserialize<MovieCompleteModel>(responseBody, options);

            MovieModel movieList = new MovieModel();
            movieList.TitleYear = new List<string>();

            movieList.Title = dataResult.Results[0].Title;
            movieList.Original_Title = dataResult.Results[0].original_title;
            movieList.Vote_Average = dataResult.Results[0].vote_average;
            movieList.Release_Date = dataResult.Results[0].release_date;
            movieList.Overview = dataResult.Results[0].Overview;

            for (int i = 1; i < dataResult.Results.Count - 1; i++)
            {
                if (movieList.TitleYear.Count < 5)
                {
                    movieList.TitleYear.Add(dataResult.Results[i].Title + " (" + dataResult.Results[i].release_date + ")");
                }
                else
                {
                    break;
                }
            }
            if (movieList.Title == null)
            {
                return NotFound("Titulo no encontrado");
            }
            return movieList;
        }
    }
}
