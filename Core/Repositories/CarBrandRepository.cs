using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CarBrandRepository : ICarBrandRepository
    {
        private CSVResourceProvider _dataProvider;

        public CarBrandRepository()
        {
            _dataProvider = CSVResourceProvider.GetInstance();
        }
        public List<CarBrand> GetAllBrands()
        {
            return _dataProvider.brandsList;
        }
    }
}
