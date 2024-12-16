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
    public class CarModelService : ICarModelService
    {
        private ICarModelRepository _carModelRepository;

        public CarModelService()
        {
            _carModelRepository = new CarModelRepositoryDB();
        }

        public void AddCarModel(CarModel CarModel)
        {
            _carModelRepository.AddCarModel(CarModel);
        }

        public void DeleteCarModel(CarModel carModel)
        {
            _carModelRepository.DeleteCarModel(carModel);
        }

        public ObservableCollection<CarModel> GetAllModels()
        {
            return _carModelRepository.GetAllModels();
        }

    }
}
