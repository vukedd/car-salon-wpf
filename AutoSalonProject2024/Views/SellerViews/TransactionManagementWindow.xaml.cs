using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews
{
    /// <summary>
    /// Interaction logic for TransactionManagementWindow.xaml
    /// </summary>
    public partial class TransactionManagementWindow : Window
    {
        public TransactionManagementWindow(Seller seller)
        {
            InitializeComponent();
            TransactionManagementViewModel transactionManagementViewModel = new TransactionManagementViewModel(seller.Id);
            this.DataContext = transactionManagementViewModel;

            decimal totalProfitSum = 0;
            foreach (Transaction t in transactionManagementViewModel.transactions)
            {
                totalProfitSum += t.Profit;
            }

            if (totalProfitSum < 0)
            {
                TotalProfitLBL.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (totalProfitSum > 0)
            {
                TotalProfitLBL.Foreground = new SolidColorBrush(Colors.Green);
            }

            TotalProfitLBL.Content = "Total profit: " + ((int)totalProfitSum).ToString() + "€";
        }
    }
}
