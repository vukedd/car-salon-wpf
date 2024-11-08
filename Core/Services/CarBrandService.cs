using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories;
using System;
using System.Collections.Generic;
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
            _carBrandRepository = new CarBrandRepository();
        }
        public List<CarBrand> GetAllBrands()
        {
            return _carBrandRepository.GetAllBrands();
        }
    }
}
