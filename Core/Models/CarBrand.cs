using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public CarBrand(int Id, string Name, Country country)
        {
            this.Id = Id;
            this.Name = Name;
            this.Country = country;
            this.CountryId = country.Id;
        }

        public string ToCSV()
        {
            return $"{Id}. {Name}";
        }
    }
}
