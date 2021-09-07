using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FE.Weather.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string CountryName { get; set; }
    }
}
