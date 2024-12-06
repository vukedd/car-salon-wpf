using AutoSalonProject2024.Models;
using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.CSVRepositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public void AddTransaction(Transaction transaction)
        {
            if (transaction.Id == null)
            {
                transaction.Id = ++CSVResourceProvider.GetInstance().lastTransactionId;
            }
            CSVResourceProvider.GetInstance().transactionList.Add(transaction);
            CSVResourceProvider.GetInstance().SaveData();
        }
    }
}
