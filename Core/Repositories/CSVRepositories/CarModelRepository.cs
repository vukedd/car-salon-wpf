using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.CSVRepositories
{
    public class CarModelRepository : ICarModelRepository
    {
        private CSVResourceProvider _dataProvider;
        public CarModelRepository()
        {
            _dataProvider = CSVResourceProvider.GetInstance();
        }

        public void AddCarModel(CarModel CarModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteCarModel(CarModel carModel)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CarModel> GetAllModels()
        {
            return _dataProvider.modelsList;
        }
    }
}
