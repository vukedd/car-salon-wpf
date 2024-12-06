using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    internal class SellerRepositoryDB : ISellerRepository
    {
        public Seller AuthenticateSeller(string username, string password)
        {
            List<Seller> sellers = new List<Seller>();

            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "SELECT * FROM Seller;";
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Seller seller = new Seller()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Username = reader.GetString(2),
                        Password = reader.GetString(3),
                        JMBG = reader.GetString(4),
                        Profit = reader.GetDecimal(5),
                        Sales = new List<Transaction>()
                    };

                    sellers.Add(seller);
                }

                connection.Close();
            }

            foreach (Seller seller in sellers)
            {
                if ((username != null && seller.Username.ToLower() == username.ToLower()) && (password != null && seller.Password == password))
                {
                    return seller;
                }
            }
            return null;
        }
    }
}
