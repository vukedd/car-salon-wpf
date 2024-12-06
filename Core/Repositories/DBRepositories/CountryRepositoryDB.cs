using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    internal class CountryRepositoryDB : ICountryRepository
    {
        public ObservableCollection<Country> GetAllCountries()
        {
            ObservableCollection <Country> countries = new ObservableCollection<Country>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM Country;";
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var country = new Country()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };

                    countries.Add(country);
                }
            }

            return countries;
        }
    }
}
