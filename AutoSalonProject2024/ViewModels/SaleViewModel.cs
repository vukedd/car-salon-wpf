using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class SaleViewModel : INotifyPropertyChanged
    {
        #region Binding Props
        public int Id { get; set; }
        public Seller Seller { get; set; }
        public Car Car { get; set; }
        public string? BuyerFullName { get; set;}
        public string? BuyerIdNumber { get; set; }
        public string? SalePrice { get; set; }
        public DateOnly SaleDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public ICommand CreateSale { get; set; }

        #endregion

        #region ViewModelProps
        public event EventHandler onSuccess;
        public event EventHandler onFailure;
        public event PropertyChangedEventHandler? PropertyChanged;
        public ITransactionService _transactionService;
        #endregion
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
            if ((BuyerFullName != null && (BuyerFullName.Trim().Length > 2 && BuyerFullName.Trim().Length < 21)) && (BuyerIdNumber != null && BuyerIdNumber.Trim().Length == 9) && (SalePrice != null && decimal.TryParse(SalePrice, null, out decimal result) && result >= 1))
            {
                Transaction transaction = new Transaction(Seller, Car, BuyerFullName, BuyerIdNumber, decimal.Parse(SalePrice));
                _transactionService.AddTransaction(transaction);
                onSaleSuccess();
            } 
            else
            {
                onSaleFailure();
            }
        }

        private void onSaleSuccess()
        {
            decimal profit = decimal.Parse(SalePrice) * (decimal)0.25;

            if (profit > 150)
            {
                Seller.Profit = Seller.Profit + profit;
            }
            else
            {
                Seller.Profit = Seller.Profit + 150;
            }
            onSuccess?.Invoke(this, EventArgs.Empty);
        }

        private void onSaleFailure() 
        {
            onFailure?.Invoke(this, EventArgs.Empty);
        }
    }
}
