using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using Core.Repositories.CSVRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    public class CarModelRepositoryDB : ICarModelRepository
    {
        ICarBrandRepository _carBrandRepository;
        public CarModelRepositoryDB()
        {
            _carBrandRepository = new CarBrandRepositoryDB();
        }

        public void AddCarModel(CarModel CarModel)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"INSERT INTO CarModel(Name, CarBrandId) VALUES (@Name, @CarBrandId);";
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("Name", CarModel.Name));
                command.Parameters.Add(new SqlParameter("CarBrandId", CarModel.Brand.Id));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCarModel(CarModel carModel)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"DELETE FROM CarModel WHERE CarModelId = @Id";
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("Id", carModel.Id));
                command.Connection = connection;

                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<CarModel> GetAllModels()
        {
            ObservableCollection<CarModel> models = new ObservableCollection<CarModel>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM CarModel;";
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    var model = new CarModel()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        BrandId = reader.GetInt32(2)
                    };
                    model.Brand = _carBrandRepository.GetAllBrands().Where(b => b.Id == model.BrandId).FirstOrDefault();

                    models.Add(model);
                }
            }
            return models;
        }
    }
}
