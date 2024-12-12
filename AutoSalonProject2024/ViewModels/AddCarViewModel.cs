using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using Core.Data;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoSalonProject2024.ViewModels
{
    public class AddCarViewModel
    {
        public CarModel? CarModel { get; set; }
        public CarBrand? CarBrand { get; set; }
        public string? ProductionYear { get; set; }
        public string? PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public string? HorsePower { get; set; }
        public FuelType FuelType { get; set; }

        // ViewModel props
        public event EventHandler carAdded;
        public event EventHandler carAddError;
        public ObservableCollection<CarBrand> Brands { get; set; }
        public ObservableCollection<CarModel> Models { get; set; }
        public ICommand AddCar { get; set; }
        private ICarService _carService { get; set; }
        private ICarBrandService _carBrandService;
        private ICarModelService _carModelService;
        public AddCarViewModel()
        {
            _carBrandService = new CarBrandService();
            _carModelService = new CarModelService();

            AddCar = new RelayCommand(AddCarMethod, CanAddCar);
            Brands = _carBrandService.GetAllBrands();
            Models = _carModelService.GetAllModels();
            _carService = new CarService();
        }

        private bool CanAddCar(object obj)
        {
            return true;
        }

        private void AddCarMethod(object obj)
        {
            DateOnly date = DateOnly.FromDateTime(PurchaseDate);
            if (ProductionYear != null && HorsePower != null && PurchasePrice != null && CarModel != null)
            {
                if (validateCarDetails(int.Parse(ProductionYear), int.Parse(HorsePower), decimal.Parse(PurchasePrice), CarModel, CarBrand))
                {
                    _carService.AddCar(new Car(0, int.Parse(ProductionYear), int.Parse(HorsePower), false, decimal.Parse(PurchasePrice), date, CarModel, CarBrand, FuelType));
                    OnCarAdd();
                }
            }
            else
            {
                OnCarAddError();
            }
        }

        public void OnCarAdd()
        {
            carAdded?.Invoke(this, EventArgs.Empty);
        }

        public void OnCarAddError()
        {
            carAddError?.Invoke(this, EventArgs.Empty);
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
