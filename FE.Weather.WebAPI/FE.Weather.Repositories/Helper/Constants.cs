using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Repositories.Helper
{
    public static class Constants
    {
        public static class AppSettingName
        {
            public const string API_KEY_TOKEN = "OpenWeatherAPIKey";
            public const string API_BASE_URL = "OpenWeatherAPIUrl";
        }

        public static class AppSettingValue
        {
            public const string API_KEY_TOKEN = "3b597278c6afc12f1b3054cc8a48b277";
            public const string API_BASE_URL = "http://api.openweathermap.org/data/2.5/weather";
        }
    }
}
