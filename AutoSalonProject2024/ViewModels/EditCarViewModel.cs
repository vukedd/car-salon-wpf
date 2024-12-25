using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using Core.Data;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoSalonProject2024.ViewModels
{
    public class EditCarViewModel
    {
        private Car car;
        public CarModel? CarModel { get; set; }
        public CarBrand? CarBrand { get; set; }
        public string? ProductionYear { get; set; }
        public string? PurchasePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? HorsePower { get; set; }
        public FuelType FuelType { get; set; }
        // ---------------------- //
        public ObservableCollection<CarBrand> Brands { get; set; }
        public ObservableCollection<CarModel> Models { get; set; }
        public ICommand EditCar { get; set; }
        public event EventHandler CarEditError;
        public event EventHandler CarEditEvent;
        private ICarService _carService;
        private ICarBrandService _carBrandService;
        private ICarModelService _carModelService;

        public EditCarViewModel(Car car)
        {
            this.car = car;
            EditCar = new RelayCommand(editCarMet, canEditCar);
            CarModel = car.Model;
            CarBrand = car.Brand;
            ProductionYear = car.Year.ToString();
            PurchasePrice = car.PurchasePrice.ToString();
            HorsePower = car.HorsePower.ToString();
            FuelType = car.FuelType;
            _carService = new CarService();
            _carBrandService = new CarBrandService();
            _carModelService = new CarModelService();
            Brands = _carBrandService.GetAllBrands();
            Models = _carModelService.GetAllModels();
            Trace.WriteLine(_carService.GetCarById(car.Id).Images.Count());

        }
        private bool canEditCar(object obj)
        {
            return true;
        }

        private void editCarMet(object obj)
        {
            if (ProductionYear != "" && HorsePower != "" && PurchasePrice != "" && CarModel != null)
            {
                if (validateCarDetails(int.Parse(ProductionYear), int.Parse(HorsePower), decimal.Parse(PurchasePrice), CarModel, CarBrand))
                {
                    car.Year = int.Parse(ProductionYear);
                    car.PurchasePrice = decimal.Parse(PurchasePrice);
                    car.HorsePower = int.Parse(HorsePower);
                    car.Brand = CarBrand;
                    car.Model = CarModel;
                    car.FuelType = FuelType;
                    _carService.EditCar(car.Id, car);
                    onCarEdit();
                }
            }
            else
            {
                OnCarEditError();
            }
        }

        private void onCarEdit() {
            CarEditEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnCarEditError()
        {
            CarEditError?.Invoke(this, EventArgs.Empty);
        }

        private bool validateCarDetails(int? year, int? horsePower, decimal? purchasePrice, CarModel model, CarBrand brand)
        {
            if (year != null && horsePower != null && purchasePrice != null && model != null && brand != null)
            {
                if (year < 1950 || year > 2025)
                {
                    Console.WriteLine("Year must be between 1950 and 2025.");
                    return false;
                }

                if (horsePower < 50 || horsePower > 1000)
                {
                    Console.WriteLine("Horsepower must be between 50 and 1000.");
                    return false;
                }

                if (purchasePrice <= 0 || purchasePrice > 5000000)
                {
                    Console.WriteLine("Purchase price must be greater than 0 and less than 5 million.");
                    return false;
                }

                if (model == null)
                {
                    Console.WriteLine("Car model cannot be null.");
                    return false;
                }

                if (brand == null)
                {
                    Console.WriteLine("Car brand cannot be null.");
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
