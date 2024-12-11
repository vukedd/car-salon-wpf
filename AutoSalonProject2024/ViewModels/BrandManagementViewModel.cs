using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.ViewModels
{
    public class BrandManagementViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CarBrand> _carBrands;
        private ICarBrandService _carBrandService;

        public ObservableCollection<CarBrand> CarBrands 
        {
            get 
            {
                return _carBrands;
            }

            set
            {
                _carBrands = value;
                OnPropertyChanged(nameof(CarBrands));
            }
        }

        public BrandManagementViewModel()
        {
            _carBrandService = new CarBrandService();
            CarBrands = _carBrandService.GetAllBrands();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void RefreshCars()
        {
            CarBrands = _carBrandService.GetAllBrands();
        }

        internal bool DeleteBrand(object selectedItem)
        {
           return _carBrandService.DeleteCarBrand(selectedItem as CarBrand);
        }
    }
}
