using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lection1_Core_29_06.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> WeatherForecasts { get; set; }

        static WeatherForecastController()
        {
            WeatherForecasts = new List<WeatherForecast>();
            WeatherForecasts.Add(new WeatherForecast
            {
                Date = DateTime.Now,
                Summary = "Hot",
                TemperatureC = 35
            });
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Create(WeatherForecast weatherForecast)
        {
            WeatherForecasts.Add(weatherForecast);
        }

        [HttpPut("{id}")]
        public void Update(int id, WeatherForecast weatherForecast)
        {
            WeatherForecasts[id] = weatherForecast;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            WeatherForecasts.Remove(WeatherForecasts[id]);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForecasts;
        }
    }
}
