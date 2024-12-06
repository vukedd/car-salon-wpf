using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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


    }
}
