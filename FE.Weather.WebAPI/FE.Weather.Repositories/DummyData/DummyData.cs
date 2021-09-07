using FE.Weather.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Repositories.DummyData
{
    public static class DummyData
    {
        public static List<Country> GetDummyCountries()
        {
            List<Country> dummyCountries = new List<Country>() { 
                new Country() {ID = 1, CountryName = "Indonesia"},
                new Country() {ID = 2, CountryName = "Australia"},
                new Country() {ID = 3, CountryName = "Malaysia"},
                new Country() {ID = 4, CountryName = "Singapure"}
            };

            return dummyCountries;
        }

        public static List<City> GetDummyCities()
        {
            List<City> dummyCities = new List<City>() {
                new City() {ID = 1, CountryID = 1, CityName = "Jakarta"},
                new City() {ID = 2, CountryID = 1, CityName = "Bandung"},
                new City() {ID = 3, CountryID = 1, CityName = "Surabaya"},
                new City() {ID = 4, CountryID = 1, CityName = "Medan"},
                new City() {ID = 5, CountryID = 2, CityName = "Sydney"},
                new City() {ID = 6, CountryID = 2, CityName = "Melbourne"},
                new City() {ID = 7, CountryID = 2, CityName = "Brisbane"},
                new City() {ID = 8, CountryID = 2, CityName = "Perth"},
                new City() {ID = 9, CountryID = 3, CityName = "Kuala Lumpur"},
                new City() {ID = 10, CountryID = 3, CityName = "Kuching"},
                new City() {ID = 11, CountryID = 3, CityName = "Johor Bahru"},
                new City() {ID = 12, CountryID = 4, CityName = "Singapura"},
            };

            return dummyCities;
        }
    }
}
