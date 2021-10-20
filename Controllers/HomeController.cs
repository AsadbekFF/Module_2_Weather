using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Module_2_Weather.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module_2_Weather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static Task<WeatherContent> weatherContent;
        
        public HomeController(ILogger<HomeController> logger)
        {
            string? city;
            if (!((city = Request?.Form?["Input"]) == null))
            {
                weatherContent = WeatherContent(city);
            }
            else
            {
                weatherContent = WeatherContent("Ferghana");
            }
            _logger = logger;
        }

        public async Task<WeatherContent> WeatherContent(string city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid=096705135d17ed57f50fd794b16fad59&units=metric");
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                var WeatherContent = JsonConvert.DeserializeObject<WeatherContent>(content);
                return WeatherContent;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
