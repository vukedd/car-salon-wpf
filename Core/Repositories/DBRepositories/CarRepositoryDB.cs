using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using AutoSalonProject2024.Enums;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Reflection;

namespace Core.Repositories.DBRepositories
{
    public class CarRepositoryDB : ICarRepository
    {
        ICarModelRepository _carModelRepository;
        public CarRepositoryDB()
        {
            _carModelRepository = new CarModelRepositoryDB();
        }
        public void AddCar(Car car)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Car(ProductionYear, HorsePower, Sold, PurchasePrice, PurchaseDate, FuelType, CarModelId) VALUES (@ProductionYear, @HorsePower, @Sold, @PurchasePrice, @PurchaseDate, @FuelType, @CarModelId)";
                command.Parameters.Add(new SqlParameter("ProductionYear", car.Year));
                command.Parameters.Add(new SqlParameter("HorsePower", car.HorsePower));
                command.Parameters.Add(new SqlParameter("Sold", car.Sold));
                command.Parameters.Add(new SqlParameter("PurchasePrice", car.PurchasePrice));
                command.Parameters.Add(new SqlParameter("PurchaseDate", car.PurchaseDate));
                command.Parameters.Add(new SqlParameter("FuelType", (int)car.FuelType));
                command.Parameters.Add(new SqlParameter("CarModelId", car.Model.Id));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int Id)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Car WHERE CarId = @CarId";
                command.Parameters.Add(new SqlParameter("CarId", Id));


                command.ExecuteScalar();
            }
        }

        public void EditCar(int Id, Car car)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"UPDATE Car SET ProductionYear = @ProductionYear, HorsePower = @HorsePower, PurchasePrice = @PurchasePrice, FuelType = @FuelType, CarModelId = @CarModelId WHERE CarId = @Id;";
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("ProductionYear", car.Year));
                command.Parameters.Add(new SqlParameter("HorsePower", car.HorsePower));
                command.Parameters.Add(new SqlParameter("PurchasePrice", car.PurchasePrice));
                command.Parameters.Add(new SqlParameter("FuelType", (int)car.FuelType));
                command.Parameters.Add(new SqlParameter("CarModelId", car.Model.Id));
                command.Parameters.Add(new SqlParameter("Id", Id));

                command.ExecuteNonQuery();
            }  
        }

        public ObservableCollection<Car> GetAllCars()
        {
            ObservableCollection<Car> cars = new ObservableCollection<Car>();
            ObservableCollection<CarModel> models = _carModelRepository.GetAllModels();

            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM Car, CarModel, CarBrand WHERE Car.CarModelId = CarModel.CarModelId AND CarModel.CarBrandId = CarBrand.CarBrandId AND Sold = 0;";

                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int sold = reader.GetInt32(3);
                    bool soldBool = false;
                    if (sold == 1) {
                        soldBool = true;
                    } else
                    {
                        soldBool = false;
                    }

                    Car car = new Car
                    {
                        Id = reader.GetInt32(0),
                        Year = reader.GetInt16(1),
                        HorsePower = reader.GetInt16(2),
                        Sold = soldBool,
                        PurchasePrice = reader.GetDecimal(4),
                        PurchaseDate = DateOnly.FromDateTime(reader.GetDateTime(5)),
                        FuelType = (FuelType)(reader.GetByte(6)),
                        ModelId = reader.GetInt32(7)
                    };

                    car.Model = models.Where(m => m.Id == car.ModelId).FirstOrDefault();
                    car.Brand = car.Model.Brand;
                    Trace.WriteLine(models.Count);
                    // Add the car object to the ObservableCollection
                    cars.Add(car);
                }

                reader.Close();
            }

            return cars;
        }

        public Car? GetCarById(int Id)
        {
            Car selectedCar = new Car();
            ObservableCollection<CarModel> models = _carModelRepository.GetAllModels();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM Car, CarModel, CarBrand WHERE Car.CarModelId = CarModel.CarModelId AND CarModel.CarBrandId = CarBrand.CarBrandId WHERE CarId = @Id;";
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("Id", Id));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int sold = reader.GetInt32(3);
                    bool soldBool = false;
                    if (sold == 1)
                    {
                        soldBool = true;
                    }
                    else
                    {
                        soldBool = false;
                    }

                    Car car = new Car
                    {
                        Id = reader.GetInt32(0),
                        Year = reader.GetInt16(1),
                        HorsePower = reader.GetInt16(2),
                        Sold = soldBool,
                        PurchasePrice = reader.GetDecimal(4),
                        PurchaseDate = DateOnly.FromDateTime(reader.GetDateTime(5)),
                        FuelType = (FuelType)(reader.GetByte(6)),
                        ModelId = reader.GetInt32(7)
                    };

                    car.Model = models.Where(m => m.Id == car.ModelId).FirstOrDefault();
                    car.Brand = car.Model.Brand;
                    selectedCar = car;
                }
            }

            return selectedCar;
        }

        public void SellCar(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
