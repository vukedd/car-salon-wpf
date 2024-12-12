using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.CSVRepositories
{
    public class CarRepository : ICarRepository
    {
        private CSVResourceProvider _dataProvider;

        public CarRepository()
        {
            _dataProvider = CSVResourceProvider.GetInstance();
        }

        public Car? GetCarById(int Id)
        {
            Car? car = _dataProvider.carsList.Where(c => c.Id == Id).FirstOrDefault();

            return car;
        }

        public ObservableCollection<Car> GetAllCars()
        {
            return _dataProvider.carsList;
        }

        public void DeleteCar(int Id)
        {
            Car? car = _dataProvider.carsList.Where(c => c.Id == Id).FirstOrDefault();
            if (car != null)
            {
                _dataProvider.carsList.Remove(car);
                _dataProvider.SaveData();
            }
        }

        public void EditCar(int Id, Car Car)
        {
            Car? carForEdit = _dataProvider.carsList.Where(c => c.Id == Id).FirstOrDefault();
            carForEdit = Car;
            _dataProvider.SaveData();
        }

        public void AddCar(Car Car)
        {
            Car.Id = ++_dataProvider.lastId;
            _dataProvider.carsList.Add(Car);
            _dataProvider.SaveData();
        }

        public ObservableCollection<Car> FilterCars(string filter)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Car> FilterCarsPrice(int from, int to, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
