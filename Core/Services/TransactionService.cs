using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories;
using Core.Repositories.CSVRepositories;
using Core.Repositories.DBRepositories;
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
            _transactionRepository = new TransactionRepositoryDB();
        }
        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }
        public List<Transaction> GetSellerTransactions(int SellerId)
        {
            return _transactionRepository.GetSellerTransactions(SellerId);
        }
    }
}
