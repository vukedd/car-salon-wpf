using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories;
using Core.Repositories.DBRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CarServiceDB : ICarService
    {
        private ICarRepository _carRepository;
        public CarServiceDB()
        {
            _carRepository = new CarRepositoryDB();
        }
        public void AddCar(Car Car)
        {
            _carRepository.AddCar(Car);
        }

        public void DeleteCar(int Id)
        {
            _carRepository.DeleteCar(Id);
        }

        public void EditCar(int Id, Car Car)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
