using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories;
using Core.Repositories.CSVRepositories;
using Core.Repositories.DBRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CarBrandService : ICarBrandService
    {
        private ICarBrandRepository _carBrandRepository;
        public CarBrandService()
        {
            _carBrandRepository = new CarBrandRepositoryDB();
        }

        public void AddCarBrand(CarBrand carBrand)
        {
            _carBrandRepository.AddCarBrand(carBrand);
        }

        public bool BrandExistance(string carBrandName)
        {
            return _carBrandRepository.BrandExistance(carBrandName);
        }

        public bool DeleteCarBrand(CarBrand carBrand)
        {
            return _carBrandRepository.DeleteCarBrand(carBrand);
        }

        public ObservableCollection<CarBrand> GetAllBrands()
        {
            return _carBrandRepository.GetAllBrands();
        }

        public void GetCarBrandById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
