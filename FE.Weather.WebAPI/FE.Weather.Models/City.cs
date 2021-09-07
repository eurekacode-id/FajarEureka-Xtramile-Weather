using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FE.Weather.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public int CountryID { get; set; }
        public string CityName { get; set; }
    }
}
