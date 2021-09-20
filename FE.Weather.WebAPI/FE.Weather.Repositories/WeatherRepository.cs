using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using FE.Weather.Models;
using System.Security.Cryptography;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace FE.Weather.Repositories
{
    public class WeatherRepository
    {
        private string apiBaseUrl;
        private string apiToken;
        private string encryptedApiToken;

        public WeatherResponse GetWeather(string city)
        {
            //string apiBaseUrl = ConfigurationManager.AppSettings.Get(Helper.Constants.AppSettingName.API_BASE_URL);
            //string apiToken = ConfigurationManager.AppSettings.Get(Helper.Constants.AppSettingName.API_KEY_TOKEN);

            apiBaseUrl = Helper.Constants.AppSettingValue.API_BASE_URL;
            apiToken = Helper.Constants.AppSettingValue.API_KEY_TOKEN;

            if (string.IsNullOrWhiteSpace(apiBaseUrl)) throw new Exception($"No value for AppSetting {Helper.Constants.AppSettingName.API_BASE_URL}. Please check your Web.config/App.config");
            if (string.IsNullOrWhiteSpace(apiToken)) throw new Exception($"No value for AppSetting {Helper.Constants.AppSettingName.API_KEY_TOKEN}. Please check your Web.config/App.config");


            Initialize(apiBaseUrl, apiToken);

            StringBuilder paramBuilder = new StringBuilder(0);
            #region Build Param
            if (!string.IsNullOrWhiteSpace(city))
            {
                paramBuilder
                    .Append("q=").Append(city)
                    .Append("&appid=").Append(apiToken);
            }
            else { }

            if (paramBuilder.Length > 0) { paramBuilder.Insert(0, "?"); }
            #endregion Build Param

            //string result = GetAsync("", paramBuilder.ToString());
            string result = @"{ 'coord':{ 'lon':103.8501,'lat':1.2897},
                            'weather':[{ 'id':803,'main':'Clouds','description':'broken clouds','icon':'04d'}],
                            'base':'stations',
                            'main':{ 'temp':300.78,'feels_like':304.75,'temp_min':297.23,'temp_max':301.12,'pressure':1011,'humidity':83},
                            'visibility':10000,
                            'wind':{ 'speed':2.06,'deg':150},
                            'clouds':{ 'all':75},
                            'dt':1630888745,
                            'sys':{ 'type':1,'id':9470,'country':'SG','sunrise':1630882759,'sunset':1630926430},
                            'timezone':28800,
                            'id':1880252,
                            'name':'Singapore',
                            'cod':200}";

            dynamic response = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime dtDateTimeReceive = dtDateTime.AddSeconds((long)response["dt"]).ToLocalTime();
            dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime dtSunrise = dtDateTime.AddSeconds((long)response["sys"]["sunrise"]).ToLocalTime();
            dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime dtSunset = dtDateTime.AddSeconds((long)response["sys"]["sunset"]).ToLocalTime();

            WeatherResponse weatherResponse = new WeatherResponse() { 
                Coord = new Location() { 
                    Latitude = (double)response["coord"]["lat"], 
                    Longitude = (double)response["coord"]["lon"] 
                },
                Weather = new Models.Weather() { 
                    ID = (int)response["weather"][0]["id"],
                    Main = response["weather"][0]["main"],
                    Description = response["weather"][0]["description"]
                },
                Base = response["base"],
                TemperatureInKelvin = new Temperature() { 
                    Temp = (double)response["main"]["temp"],
                    TempMin = (double)response["main"]["temp_min"],
                    TempMax = (double)response["main"]["temp_max"],
                    FeelsLike = (double)response["main"]["feels_like"]
                },
                TemperatureInCelcius = new Temperature() {
                    Temp = TemperatureConverter.KelvinToCelcius((double)response["main"]["temp"]),
                    TempMin = TemperatureConverter.KelvinToCelcius((double)response["main"]["temp_min"]),
                    TempMax = TemperatureConverter.KelvinToCelcius((double)response["main"]["temp_max"]),
                    FeelsLike = TemperatureConverter.KelvinToCelcius((double)response["main"]["feels_like"])
                },
                TemperatureInFahrenheit = new Temperature()
                {
                    Temp = TemperatureConverter.CelciusToFahrenheit(TemperatureConverter.KelvinToCelcius((double)response["main"]["temp"])),
                    TempMin = TemperatureConverter.CelciusToFahrenheit(TemperatureConverter.KelvinToCelcius((double)response["main"]["temp_min"])),
                    TempMax = TemperatureConverter.CelciusToFahrenheit(TemperatureConverter.KelvinToCelcius((double)response["main"]["temp_max"])),
                    FeelsLike = TemperatureConverter.CelciusToFahrenheit(TemperatureConverter.KelvinToCelcius((double)response["main"]["feels_like"]))
                },
                Pressure = (double)response["main"]["pressure"],
                Humidity = (double)response["main"]["humidity"],
                Visibility = (double)response["visibility"],
                Wind = new Wind() { 
                    Speed = (double)response["wind"]["speed"],
                    Direction = (double)response["wind"]["deg"]
                },
                Clouds = (double)response["clouds"]["all"],
                DateReceiveInUTC = (long)response["dt"],
                DateReceive = dtDateTimeReceive,
                Sunrise = dtSunrise,
                Sunset = dtSunset,
                TimeZone = response["timezone"],
                CityName = response["name"]
            };

            return weatherResponse;
        }

        private void Initialize(string apiBaseUrl, string apiToken)
        {
            this.apiBaseUrl = apiBaseUrl;
            this.apiToken = apiToken;
            encryptedApiToken = ComputeSha256Hash(apiToken);
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void BuildRequestHeader(HttpClient httpClient, string method, string apiPath)
        {
            string formattedDate = $"{DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss")} GMT";

            StringBuilder signatureBuilder = new StringBuilder(0);
            signatureBuilder
                .Append(method).Append("\n")
                .Append(formattedDate).Append("\n")
                .Append(apiPath);

            string hmacResult = string.Empty;
            using (HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(encryptedApiToken)))
            {
                byte[] dataToHmac = Encoding.UTF8.GetBytes(signatureBuilder.ToString());
                hmacResult = Convert.ToBase64String(hmac.ComputeHash(dataToHmac));
            }

            //httpClient.DefaultRequestHeaders.Add("Authorization", $"OB02 {apiUsername}:{hmacResult}");
            httpClient.DefaultRequestHeaders.Add("Date", formattedDate);
        }

        private string GetAsync(string apiPath, string param)
        {
            string result;
            string url = $"{apiBaseUrl}{apiPath}{param}";

            using (HttpClient httpClient = new HttpClient())
            {
                BuildRequestHeader(httpClient, HttpMethod.Get.Method, apiPath);

                var httpResponse = httpClient.GetAsync(url).Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed retrieving data: {httpResponse}");
                }
                result = httpResponse.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}
