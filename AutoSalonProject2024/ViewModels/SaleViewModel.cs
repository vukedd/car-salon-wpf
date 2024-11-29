using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public Seller Seller { get; set; }
        public Car Car { get; set; }
        public string? BuyerFullName { get; set;}
        public string? BuyerIdNumber { get; set; }
        public decimal? SalePrice { get; set; }
        public DateOnly SaleDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public ICommand CreateSale { get; set; }
        // -------------- //
        public ITransactionService _transactionService;

        public SaleViewModel()
        {
            CreateSale = new RelayCommand(createSaleMet, canCreateSale);
            _transactionService = new TransactionService();
        }

        private bool canCreateSale(object obj)
        {
            return true;
        }

        private void createSaleMet(object obj)
        {
            Transaction transaction = new Transaction(Seller, Car, BuyerFullName, BuyerIdNumber, (decimal)SalePrice);
            _transactionService.AddTransaction(transaction);
            foreach (Transaction t in Seller.Sales) 
            { 
                Trace.WriteLine(t.Car.Model.Name);
            }
        }
    }
}
