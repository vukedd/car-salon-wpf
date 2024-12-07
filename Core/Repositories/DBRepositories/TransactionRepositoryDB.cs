using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    public class TransactionRepositoryDB : ITransactionRepository
    {
        private ICarRepository _carRepository;
        private ISellerRepository _sellerRepository;
        public TransactionRepositoryDB()
        {
            _carRepository = new CarRepositoryDB();
            _sellerRepository = new SellerRepositoryDB();
        }
        public void AddTransaction(Transaction transaction)
        {
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText1 = @"INSERT INTO Transactions(DateOfTransaction, BuyerFullName, BuyerIdNumber, SalePrice, CarId, SellerId) VALUES (@DateOfTransaction, @BuyerFullName, @BuyerIdNumber, @SalePrice, @CarId, @SellerId)";
                string commandText2 = @"UPDATE Car SET sold = 1 WHERE CarId = @CarId";
                string commandText3 = @"UPDATE Seller SET profit = profit + @Profit";

                connection.Open();
                SqlTransaction newTransaction = connection.BeginTransaction();

                try
                {
                    // Command 1
                    SqlCommand command1 = new SqlCommand();
                    command1.CommandText = commandText1;
                    command1.Parameters.Add(new SqlParameter("DateOfTransaction", transaction.DateOfTransaction.ToString()));
                    command1.Parameters.Add(new SqlParameter("BuyerFullName", transaction.BuyerFullName));
                    command1.Parameters.Add(new SqlParameter("BuyerIdNumber", transaction.BuyerIdNumber));
                    command1.Parameters.Add(new SqlParameter("SalePrice", transaction.SalePrice));
                    command1.Parameters.Add(new SqlParameter("CarId", transaction.Car.Id));
                    command1.Parameters.Add(new SqlParameter("SellerId", transaction.Seller.Id));
                    command1.Transaction = newTransaction;
                    command1.Connection = connection;

                    command1.ExecuteNonQuery();

                    // Command 2
                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = commandText2;
                    command2.Parameters.Add(new SqlParameter("CarId", transaction.Car.Id));
                    command2.Transaction = newTransaction;
                    command2.Connection = connection;

                    command2.ExecuteNonQuery();

                    // Command 3
                    SqlCommand command3 = new SqlCommand();
                    command3.CommandText = commandText3;
                    command3.Parameters.Add(new SqlParameter("Profit", transaction.SalePrice * (decimal)0.30));
                    command3.Transaction = newTransaction;
                    command3.Connection = connection;

                    command3.ExecuteNonQuery();

                    newTransaction.Commit();
                    connection.Close();
                } 
                catch (Exception e)
                {
                    newTransaction.Rollback();
                    connection.Close();
                }
            }
        }

        public List<Transaction> GetSellerTransactions(int SellerId)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM Transactions WHERE SellerId = @SellerId;";
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add(new SqlParameter("SellerId", SellerId));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Transaction transaction = new Transaction()
                    {
                        Id = reader.GetInt32(0),
                        DateOfTransaction = DateOnly.FromDateTime(reader.GetDateTime(1)),
                        BuyerFullName = reader.GetString(2),
                        BuyerIdNumber = reader.GetString(3),
                        SalePrice = reader.GetDecimal(4),
                        Car = _carRepository.GetCarById(reader.GetInt32(5)),
                        Seller = _sellerRepository.GetSellerById(reader.GetInt32(6)),
                        Profit = reader.GetDecimal(4) - _carRepository.GetCarById(reader.GetInt32(5)).PurchasePrice
                    };

                    transactions.Add(transaction);
                }
            }

            return transactions;
        }
    }
}
