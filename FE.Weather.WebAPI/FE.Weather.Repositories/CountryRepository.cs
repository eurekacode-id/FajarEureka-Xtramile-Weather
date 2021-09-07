using FE.Weather.Models;
using System;
using System.Collections.Generic;

namespace FE.Weather.Repositories
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            List<Country> listCountries = new List<Country>();
            listCountries = DummyData.DummyData.GetDummyCountries();

            return listCountries;
        }
    }
}
