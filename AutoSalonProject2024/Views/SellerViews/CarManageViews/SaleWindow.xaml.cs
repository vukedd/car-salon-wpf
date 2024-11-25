using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
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
            this.DataContext = _saleViewModel;
        }


    }
}
