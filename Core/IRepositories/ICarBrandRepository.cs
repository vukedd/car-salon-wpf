using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ICarBrandRepository
    {
        public ObservableCollection<CarBrand> GetAllBrands();
        public void AddCarBrand(CarBrand carBrand);
        public bool DeleteCarBrand(CarBrand carBrand);
        public CarBrand GetCarBrandById(int id);
        public bool BrandExistance(string carBrandName);
    }
}
