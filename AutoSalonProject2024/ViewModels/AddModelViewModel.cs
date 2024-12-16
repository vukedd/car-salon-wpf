using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class AddModelViewModel
    {
        #region binding
        public CarBrand carBrand { get; set; }
        public string carModelName { get; set; }
        public ICommand AddCarModel { get; set; }
        public ObservableCollection<CarBrand> Brands { get; set; }
        public event EventHandler OnCarModelAddSuccess;
        public event EventHandler OnCarModelAddFailure;
        #endregion
        private ICarModelService _carModelService;
        private ICarBrandService _carBrandService;
        public AddModelViewModel()
        {
            _carModelService = new CarModelService();
            _carBrandService = new CarBrandService();
            Brands = _carBrandService.GetAllBrands();
            AddCarModel = new RelayCommand(addCarBrandMet, canAddCarBrand);
        }

        private bool canAddCarBrand(object obj)
        {
            return true;
        }

        private void addCarBrandMet(object obj)
        {
            if (carBrand != null && carModelName != null && carModelName.Trim().Length > 3)
            {
                CarModel CarModel = new CarModel();
                CarModel.Brand = carBrand;
                CarModel.Name = carModelName;
                _carModelService.AddCarModel(CarModel);
                onCarModelAddSuccess();
            } 
            else
            {
                onCarModelAddFailure();
            }
        }

        private void onCarModelAddFailure()
        {
            OnCarModelAddFailure?.Invoke(this, EventArgs.Empty);
        }

        private void onCarModelAddSuccess()
        {
            OnCarModelAddSuccess?.Invoke(this, EventArgs.Empty);
        }
    }
}
