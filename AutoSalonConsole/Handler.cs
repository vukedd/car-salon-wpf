using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonConsole
{
    public class Handler
    {
        private ICarService _carService;
        private ICarBrandService _carBrandService;
        private ICarModelService _carModelService;
        public Handler()
        {
            this._carService = new CarService();
            this._carBrandService = new CarBrandService();
            this._carModelService = new CarModelService();
        }

        public ObservableCollection<Car> GetAllCars()
        {
            return _carService.GetAllCars();
        }

        public ObservableCollection<CarModel> GetAllModels()
        {
            return _carModelService.GetAllModels();
        }

        public ObservableCollection<CarBrand> GetAllBrands()
        {
            return _carBrandService.GetAllBrands();
        }

        public Car? GetCarById(int Id)
        {
            return _carService.GetCarById(Id);
        }
        
        public void AddCar(Car car)
        {
            _carService.AddCar(car);
        }

        public void DeleteCar(int Id)
        {
            _carService.DeleteCar(Id);
        }
        
        public void EditCar(int Id, Car Car)
        {
            _carService.EditCar(Id, Car);
        }
    }
}
