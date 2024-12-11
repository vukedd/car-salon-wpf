using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    public class CarBrandRepositoryDB : ICarBrandRepository
    {
        ICountryRepository _countryRepository = new CountryRepositoryDB();
        
        public CarBrandRepositoryDB()
        {
            _countryRepository = new CountryRepositoryDB();
        }

        public void AddCarBrand(CarBrand carBrand)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"INSERT INTO CarBrand(Name, CountryId) VALUES (@Name, @CountryId);";
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("Name", carBrand.Name));
                command.Parameters.Add(new SqlParameter("CountryId", carBrand.Country.Id));

                command.ExecuteNonQuery();
            }
        }

        public bool DeleteCarBrand(CarBrand carBrand)
        {
            if (ValidateDeletion(carBrand.Id))
            {
                using (var connection = new SqlConnection(Config.CONNECTION_STRING))
                {
                    string commandText = @"DELETE FROM CarBrand WHERE CarBrandId = @Id;";
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = commandText;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("Id", carBrand.Id));

                    command.ExecuteNonQuery();
                }
                return true;
            }

            return false;
        }

        public ObservableCollection<CarBrand> GetAllBrands()
        {
            ObservableCollection<CarBrand> brands = new ObservableCollection<CarBrand>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM CarBrand";
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var brand = new CarBrand()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CountryId = reader.GetInt32(2)
                    };

                    brand.Country = _countryRepository.GetAllCountries().Where(c => c.Id == brand.CountryId).FirstOrDefault();
                    brands.Add(brand);
                }
            }
            return brands;
        }

        public CarBrand GetCarBrandById(int id)
        {
            throw new NotImplementedException();
        }

        private bool ValidateDeletion(int brandId)
        {
            List<Car> cars = new List<Car>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM Car, CarModel, CarBrand WHERE Car.CarModelId = CarModel.CarModelId AND CarModel.CarBrandId = CarBrand.CarBrandId AND CarBrand.CarBrandId = @id;";
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("id", brandId));

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

                    cars.Add(car);
                }
            }

            if (cars.Count() == 0)
            {
                return true;
            }

            return false;
        }

        public bool BrandExistance(string carBrandName)
        {
            List<CarBrand> carBrands = new List<CarBrand>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM CarBrand WHERE Name = @carBrandName;";
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("carBrandName", carBrandName));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var brand = new CarBrand()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CountryId = reader.GetInt32(2)
                    };
                    carBrands.Add(brand);
                }
            }

            if (carBrands.Count() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
