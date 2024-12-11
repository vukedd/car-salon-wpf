using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICarBrandService
    {
        public ObservableCollection<CarBrand> GetAllBrands();
        public void AddCarBrand(CarBrand carBrand);
        public bool DeleteCarBrand(CarBrand carBrand);
        public void GetCarBrandById(int id);
        public bool BrandExistance(string carBrandName);
    }
}
