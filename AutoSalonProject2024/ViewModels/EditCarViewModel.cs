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

namespace AutoSalonProject2024.ViewModels
{
    public class EditCarViewModel
    {
        private Car car;
        public CarModel? CarModel { get; set; }
        public CarBrand? CarBrand { get; set; }
        public int? ProductionYear { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? HorsePower { get; set; }
        public FuelType FuelType { get; set; }
        // ---------------------- //
        public ObservableCollection<CarBrand> Brands { get; set; }
        public ObservableCollection<CarModel> Models { get; set; }
        public ICommand EditCar { get; set;}
        public event EventHandler CarEditEvent;
        private ICarService _carService;

        public EditCarViewModel(Car car)
        {
            this.car = car;
            EditCar = new RelayCommand(editCarMet, canEditCar);
            CarModel = car.Model;
            CarBrand = car.Brand;
            ProductionYear = car.Year;
            PurchasePrice = car.PurchasePrice;
            HorsePower = car.HorsePower;
            FuelType = car.FuelType;
            _carService = new CarService();

            Brands = CSVResourceProvider.GetInstance().brandsList;
            Models = CSVResourceProvider.GetInstance().modelsList;
        }
        private bool canEditCar(object obj)
        {
            return true;
        }

        private void editCarMet(object obj)
        {
            car.Year = ProductionYear.Value;
            car.PurchasePrice = PurchasePrice.Value;
            car.HorsePower = HorsePower.Value;
            car.Brand = CarBrand;
            car.Model = CarModel;
            car.FuelType = FuelType;
            _carService.EditCar(car.Id, car);
            onCarEdit();
        }

        private void onCarEdit() {
            CarEditEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
