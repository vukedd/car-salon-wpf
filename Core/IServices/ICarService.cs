using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICarService
    {
        ObservableCollection<Car> GetAllCars();
        ObservableCollection<Car> FilterCars(string filter);
        ObservableCollection<Car> FilterCarsPrice(int from, int to, string filter);
        Car GetCarById(int Id);
        void DeleteCar(int Id);
        void EditCar(int Id, Car Car);
        void AddCar(Car Car);
    }
}
