using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Models
{
    public class WeatherResponse
    {
        public Location Coord { get; set; }
        public Weather Weather { get; set; }
        public string Base { get; set; }
        public Temperature TemperatureInKelvin { get; set; }
        public Temperature TemperatureInFahrenheit { get; set; }
        public Temperature TemperatureInCelcius { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Visibility { get; set; }
        public Wind Wind { get; set; }
        public double Clouds { get; set; }
        public long DateReceiveInUTC { get; set; }
        public DateTime DateReceive { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public int TimeZone { get; set; }
        public string CityName { get; set; }
    }
}
