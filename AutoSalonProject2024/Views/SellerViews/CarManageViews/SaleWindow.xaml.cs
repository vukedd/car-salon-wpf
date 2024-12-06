using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews.CarManageViews
{
    /// <summary>
    /// Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        private Car _carForSale;
        private SaleViewModel _saleViewModel;
        public SaleWindow(Car car)
        {
            InitializeComponent();
            _carForSale = car;
            _saleViewModel = new SaleViewModel();
            _saleViewModel.Car = car;
            _saleViewModel.Seller = HomepageWindowViewModel.Seller;
            _saleViewModel.onFailure += OnSaleFailure;
            _saleViewModel.onSuccess += OnSaleSuccess;
            this.DataContext = _saleViewModel;
        }

        private void OnSaleSuccess(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void OnSaleFailure(object? sender, EventArgs e)
        {
            MessageBox.Show("Please check all fields before submiting", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SalePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void BuyerId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SalePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal purchasePrice = _carForSale.PurchasePrice;
            if (SalePrice.Text != null && int.TryParse(SalePrice.Text, null, out int result))
            {
                if (result >= 500)
                {
                    SalePriceValidationLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    SalePriceValidationLabel.Visibility = Visibility.Visible;
                }
            }
        }

        private void BuyerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BuyerName.Text != null && (BuyerName.Text.Length > 2 && BuyerName.Text.Length < 21))
            {
                BuyerNameValidationLabel.Visibility = Visibility.Hidden;
            } 
            else
            {
                BuyerNameValidationLabel.Visibility = Visibility.Visible;
            }
        }

        private void BuyerIdNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BuyerIdNumber.Text != null && BuyerIdNumber.Text.Length == 9)
            {
                IdNumValidationLabel.Visibility = Visibility.Hidden; 
            } 
            else
            {
                IdNumValidationLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
