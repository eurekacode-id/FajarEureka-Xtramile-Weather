using FE.Weather.Models;
using FE.Weather.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Repositories.Services
{
    public class GetCountryService : AbstractService<string, List<Country>>
    {
        protected override List<Country> ProcessRequest(string request)
        {
            CountryRepository repo = new CountryRepository();
            return repo.GetCountries();
        }
    }
}
