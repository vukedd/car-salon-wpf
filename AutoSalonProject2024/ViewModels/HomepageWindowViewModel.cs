using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class HomepageWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> _cars;
        public static Seller Seller { get; set; }
        private ICarService _carService { get; set; }
        public HomepageWindowViewModel()
        {
            _carService = new CarService();
            Cars = _carService.GetAllCars();
        } 

        public ObservableCollection<Car> Cars
        {
            get
            {
                return _cars;
            }

            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void DeleteCar(int id)
        {
            _carService.DeleteCar(id);
        }

        public void UpdateCars()
        {
            Cars = _carService.GetAllCars();
        }
    }
}
