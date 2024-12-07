using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetSellerTransactions(int SellerId);
    }
}
