using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Net;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("series")]
    public class SeriesController : Controller
    {
        private string _apiKey = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4ZTcyZjZjYzZmMTIyZTEzZjI5ZGNkYjdmOThlZWI4YyIsInN1YiI6IjY0ODIwNmZhZTI3MjYwMDBlOGJmNjgxYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.v6ijSgGSPZeGRimKQmpG1hqo-Q3Sc07-sS-FGgZeCVg";

        [HttpGet("")]
        public async Task<IActionResult> GetSerie()
        {
            string url = "https://api.themoviedb.org/3/tv/popular?language=en-US&page=1";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode
                };
            }
            else
            {
                return new ContentResult
                {
                    Content = "Error",
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerieDetails(int id)
        {
            string url = $"https://api.themoviedb.org/3/tv/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode
                };
            }
            else
            {
                return new ContentResult
                {
                    Content = "Error",
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
        [HttpGet("credits/{id}")]
        public async Task<IActionResult> GetSerieCredits(int id)
        {
            string url = $"https://api.themoviedb.org/3/tv/{id}/credits";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode,
                };
            }
            else
            {
                return new ContentResult
                {
                    Content = "Error",
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
        [HttpGet("{id}/recommendations")]
        public async Task<IActionResult> GetRelatedSeries(int id)
        {
            string url = $"https://api.themoviedb.org/3/tv/{id}/recommendations";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = (int)response.StatusCode,
                };
            }
            else
            {
                return new ContentResult
                {
                    Content = "Error",
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
