using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CarBrand Brand { get; set; }
        public int BrandId { get; set; }

        public CarModel(int Id, string Name, CarBrand Brand)
        {
            this.Id = Id;
            this.Name = Name;
            this.Brand = Brand;
            this.BrandId = Brand.Id;
        }
        
        public string ToCSV()
        {
            return $"{Id}. {Name}";
        }
    }
}
