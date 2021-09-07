using FE.Weather.Models;
using FE.Weather.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Repositories.Services
{
    public class GetWeatherService : AbstractService<string, WeatherResponse>
    {
        protected override WeatherResponse ProcessRequest(string request)
        {
            WeatherRepository repo = new WeatherRepository();
            return repo.GetWeather(request);
        }
    }
}
