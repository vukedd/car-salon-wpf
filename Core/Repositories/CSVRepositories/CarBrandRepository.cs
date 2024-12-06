using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.CSVRepositories
{
    public class CarBrandRepository : ICarBrandRepository
    {
        private CSVResourceProvider _dataProvider;

        public CarBrandRepository()
        {
            _dataProvider = CSVResourceProvider.GetInstance();
        }
        public ObservableCollection<CarBrand> GetAllBrands()
        {
            return _dataProvider.brandsList;
        }
    }
}
