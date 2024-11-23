using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class HomepageWindowViewModel
    {
        public static ObservableCollection<Car> Cars { get; set; }
        public static Seller Seller { get; set; } = null;
        private ICarService _carService { get; set; }
        public HomepageWindowViewModel()
        {
            _carService = new CarService();
            Cars = _carService.GetAllCars();
        }

        public void DeleteCar(int id)
        {
            _carService.DeleteCar(id);
        }
    }
}
