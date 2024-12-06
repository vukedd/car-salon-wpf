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
        public ObservableCollection<CarModel> GetAllModels()
        {
            return _dataProvider.modelsList;
        }
    }
}
