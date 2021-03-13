using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;


namespace HangPlayGround.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly  HangPlayGround.Service.IUserServices _userService;


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, HangPlayGround.Service.IUserServices userService)
        {
            _logger = logger;
            _userService = userService;
        }


        public void Loop()
        {
            for (int i = 0; i < 99999; i++)
            {
                Console.WriteLine(i.ToString());
            }
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //executa chamada em backgroud
            BackgroundJob.Enqueue(()=> Loop());

            var x = _userService.GetUserList();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
