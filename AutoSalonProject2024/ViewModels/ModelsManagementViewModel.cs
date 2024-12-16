using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class ModelsManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CarModel> _models;
        private ICarModelService _carModelService;

        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<CarModel> Models
        {
            get
            {
                return _models;
            }

            set
            {
                _models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        public ModelsManagementViewModel()
        {
            _carModelService = new CarModelService();
            Models = _carModelService.GetAllModels();
        }

        internal void UpdateModels()
        {
            Models = _carModelService.GetAllModels();
        }

        public void DeleteCarModel(CarModel CarModel)
        {
            _carModelService.DeleteCarModel(CarModel);
        }
    }
}
