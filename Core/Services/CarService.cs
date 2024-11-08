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
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        public CarService()
        {
            _carRepository = new CarRepository();        
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
            _carRepository.EditCar(Id, Car);
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();   
        }

        public Car GetCarById(int Id)
        {
            return _carRepository.GetCarById(Id);
        }
    }
}
