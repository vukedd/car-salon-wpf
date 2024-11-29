using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }
        public void AddTransaction(Transaction transaction)
        {
            transaction.Car.Sold = true;
            transaction.Seller.Profit += (decimal)(transaction.SalePrice - transaction.Car.PurchasePrice);
            transaction.Seller.Sales.Add(transaction);
            _transactionRepository.AddTransaction(transaction);
        }
    }
}
