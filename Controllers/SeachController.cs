using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Net;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("media")]
    public class SearchController : Controller
    {
        private string _apiKey = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4ZTcyZjZjYzZmMTIyZTEzZjI5ZGNkYjdmOThlZWI4YyIsInN1YiI6IjY0ODIwNmZhZTI3MjYwMDBlOGJmNjgxYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.v6ijSgGSPZeGRimKQmpG1hqo-Q3Sc07-sS-FGgZeCVg";

        [HttpPost("GetMovie")]
        public async Task<IActionResult> PostMovie([FromBody] RequestModel movie)
        {
            movie.movie = movie.movie.Replace(" ", "%20");
            string url = $"https://api.themoviedb.org/3/search/movie?query={movie.movie}&include_adult=false&language=en-US&page=1";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await client.GetAsync(url);
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode
                };
            }
            return new ContentResult
            {
                Content = "Error",
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [HttpPost("GetSerie")]
        public async Task<IActionResult> PostSeries([FromBody] RequestModel serie)
        {
            serie.movie = serie.movie.Replace(" ", "%20");
            string url = $"https://api.themoviedb.org/3/search/tv?query={serie.movie}&include_adult=false&language=en-US&page=1";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await client.GetAsync(url);
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode
                };
            }
            return new ContentResult
            {
                Content = "Error",
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
