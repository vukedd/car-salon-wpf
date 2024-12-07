using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    public class SellerRepositoryDB : ISellerRepository
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

        public Seller GetSellerById(int SellerId)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM Seller WHERE SellerId = @SellerId;";
                
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("SellerId", SellerId));

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
                        Profit = reader.GetDecimal(5)
                    };

                    return seller;
                }
            }

            return null;
        }

        public Seller GetSellerByUsername(string username)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM Seller WHERE Username = @Username;";

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("Username", username));

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
                        Profit = reader.GetDecimal(5)
                    };

                    return seller;
                }
            }

            return null;
        }


        public bool RegisterSeller(Seller seller)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                try
                {
                    string commandText = @"INSERT INTO Seller(Name, Username, Password, JMBG, Profit) VALUES (@Name, @Username, @Password, @JMBG, @Profit);";
                    connection.Open();
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add(new SqlParameter("Name", seller.Name));
                    command.Parameters.Add(new SqlParameter("Username", seller.Username));
                    command.Parameters.Add(new SqlParameter("Password", seller.Password));
                    command.Parameters.Add(new SqlParameter("JMBG", seller.JMBG));
                    command.Parameters.Add(new SqlParameter("Profit", seller.Profit));

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                } 
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    connection.Close();
                    return false;
                }

            }
        }
    }
}
