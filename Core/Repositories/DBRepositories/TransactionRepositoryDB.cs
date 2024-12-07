using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
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
    }
}
