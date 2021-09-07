using FE.Weather.Models;
using System;
using System.Collections.Generic;

namespace FE.Weather.Repositories
{
    public class CityRepository
    {
        public List<City> GetCities(int iCountryId)
        {
            List<City> listCities = new List<City>();
            listCities = DummyData.DummyData.GetDummyCities().FindAll(x => x.CountryID == iCountryId);

            return listCities;
        }
    }
}
