using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ICarRepository
    {
        List<Car> GetAllCars();
        Car? GetCarById(int Id);
        void DeleteCar(int Id);
        void EditCar(int Id, Car car);
        void AddCar(Car car);
    }
}
