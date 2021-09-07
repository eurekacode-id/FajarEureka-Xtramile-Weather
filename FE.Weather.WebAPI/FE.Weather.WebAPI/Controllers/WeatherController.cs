using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FE.Weather.Models;
using FE.Weather.Repositories;
using FE.Weather.Repositories.Services;

namespace FE.Weather.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public ResultStatus<WeatherResponse> GetWeather(string city)
        {
            GetWeatherService service = new GetWeatherService();
            return service.Execute(city);
        }
    }
}
