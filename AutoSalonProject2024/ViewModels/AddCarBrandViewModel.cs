using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class AddCarBrandViewModel
    {
        public Country? Country { get; set; }
        public string BrandName { get; set; }
        public ObservableCollection<Country> Countries { get; set; }
        public ICommand CreateBrand { get; set; }
        //--------------------------------------------//
        public event EventHandler OnCreationSuccess;
        public event EventHandler OnCreationFailure;
        private ICountryService _countryService;
        private ICarBrandService _carBrandService;
        public AddCarBrandViewModel()
        {
            _countryService = new CountryService();
            _carBrandService = new CarBrandService();
            Countries = _countryService.GetAllCountries();
            CreateBrand = new RelayCommand(createBrandmet, canCreateBrand);
        }

        private bool canCreateBrand(object obj)
        {
            return true;
        }

        public bool BrandExists(string carBrandName)
        {
            return _carBrandService.BrandExistance(carBrandName);
        }    

        private void createBrandmet(object obj)
        {
            if (Country != null && BrandName != null && !BrandExists(BrandName.Trim()) && BrandName.Length > 3)
            {
                _carBrandService.AddCarBrand(new CarBrand(BrandName, Country));
                onCreationSuccess();
            } 
            else
            {
                onCreationFailure();
            }
        }

        private void onCreationSuccess()
        {
            OnCreationSuccess?.Invoke(this, EventArgs.Empty);
        }

        private void onCreationFailure()
        {
            OnCreationFailure?.Invoke(this, EventArgs.Empty);
        }
    }
}
