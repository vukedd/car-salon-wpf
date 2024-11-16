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

namespace AutoSalonProject2024.ViewModels
{
    public class AddCarViewModel
    {
        public CarModel? CarModel { get; set; }
        public CarBrand? CarBrand { get; set; }
        public string? ProductionYear { get; set; }
        public string? PurchasePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? SalePrice { get; set; }
        public string? HorsePower { get; set; }
        public FuelType FuelType { get; set; }

        // ViewModel props
        public event EventHandler carAdded;
        public ObservableCollection<CarBrand> Brands { get; set; }
        public ObservableCollection<CarModel> Models { get; set; }
        public ICommand AddCar { get; set; }
        private ICarService _carService { get; set; }
        public AddCarViewModel()
        {
            AddCar = new RelayCommand(AddCarMethod, CanAddCar);
            Brands = CSVResourceProvider.GetInstance().brandsList;
            Models = CSVResourceProvider.GetInstance().modelsList;
            _carService = new CarService();
        }

        private bool CanAddCar(object obj)
        {
            return true;
        }

        private void AddCarMethod(object obj)
        {
            
            DateOnly date = DateOnly.FromDateTime((DateTime)PurchaseDate);
            _carService.AddCar(new Car(0, int.Parse(ProductionYear), int.Parse(HorsePower), false, decimal.Parse(PurchasePrice), date, decimal.Parse(SalePrice), CarModel, CarBrand, FuelType));
            Trace.WriteLine("Car succesfully added!");
            OnCarAdd();
        }

        public void OnCarAdd()
        {
            carAdded?.Invoke(this, EventArgs.Empty);
        }
    }
}
