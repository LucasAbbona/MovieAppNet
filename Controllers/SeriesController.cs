using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Net;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("series")]
    public class SeriesController : Controller
    {   
        private readonly IConfiguration _configuration;
        public SeriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetSerie()
        {
            string url = $"{_configuration["BaseURL"]}tv/popular?language=en-US&page=1";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["ApiKey"]}");
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
            string url = $"{_configuration["BaseURL"]}tv/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["ApiKey"]}");
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
            string url = $"{_configuration["BaseURL"]}tv/{id}/credits";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["ApiKey"]}");
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
            string url = $"{_configuration["BaseURL"]}tv/{id}/recommendations";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["ApiKey"]}");
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
