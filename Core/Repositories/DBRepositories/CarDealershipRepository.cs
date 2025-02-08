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
    public class CarDealershipRepository : ICarDealershipRepository
    {
        IAddressRepository _addressRepository;
        public CarDealershipRepository()
        {
            _addressRepository = new AddressRepository();
        }
        public Dealership GetDealership()
        {
            Dealership dealership = new Dealership();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM Salon WHERE SalonId = 1;";
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dealership = new Dealership();
                    dealership.Id = reader.GetInt16(0);
                    dealership.Name = reader.GetString(1);
                    dealership.Address = _addressRepository.getAddressById(reader.GetInt32(2));
                }
            }

            return dealership;
        }
    }
}
