using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.ViewModels
{
    public class TransactionManagementViewModel
    {
        public List<Transaction> transactions { get; set; }

        private ITransactionService _transactionService;
        public TransactionManagementViewModel(int SellerId)
        {
            _transactionService = new TransactionService();
            transactions = _transactionService.GetSellerTransactions(SellerId);
            foreach (Transaction t in transactions)
            {
                Trace.WriteLine(t.Id);
            }
        }


    }
}
