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
    public class CityController : ControllerBase
    {
        [HttpGet]
        public ResultStatus<List<City>> GetCities(int countryId)
        {
            GetCityService service = new GetCityService();
            return service.Execute(countryId);
        }
    }
}
