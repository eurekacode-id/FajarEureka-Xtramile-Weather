using FE.Weather.Models;
using FE.Weather.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Repositories.Services
{
    public class GetCityService : AbstractService<int, List<City>>
    {
        protected override List<City> ProcessRequest(int request)
        {
            CityRepository repo = new CityRepository();
            return repo.GetCities(request);
        }
    }
}
