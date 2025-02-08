using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    public class AddressRepository : IAddressRepository
    {
        public Address getAddressById(int id)
        {
            Address address = new Address();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM Address WHERE AddressId = @Id;";
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("Id", id));
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    address.Id = reader.GetInt32(0);
                    address.StreetName = reader.GetString(1);
                    address.StreetNumber = reader.GetString(2);
                    address.PostalCode = reader.GetString(3);
                };
            };

            return address;
        }
    }
}
