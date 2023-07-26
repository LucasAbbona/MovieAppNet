using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using MovieApp.Models;
using System.Net;
using System.Text.Json;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MoviesController : ControllerBase
    {   
        private readonly IConfiguration _configuration;
        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetMovie()
        {
            string url = $"{_configuration["BaseURL"]}movie/now_playing?language=en-US&page=1";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["ApiKey"]}");
            var response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = 200
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
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            string url = $"{_configuration["BaseURL"]}movie/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["ApiKey"]}");
            var response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ContentResult
                {
                    Content = content,
                    ContentType = "application/json",
                    StatusCode = 200
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
            string url = $"{_configuration["BaseURL"]}movie/{id}/credits";
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
        public async Task<IActionResult> GetRelatedMovies(int id)
        {
            string url = $"{_configuration["BaseURL"]}movie/{id}/recommendations";
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