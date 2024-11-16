using AutoSalonProject2024.ViewModels;
using AutoSalonProject2024.Views.SellerViews.CarManageViews;
using Core.Data;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews
{
    /// <summary>
    /// Interaction logic for HomepageWindow.xaml
    /// </summary>
    public partial class HomepageWindow : Window
    {
        public HomepageWindow()
        {
            InitializeComponent();
            HomepageWindowViewModel homePageViewModel = new HomepageWindowViewModel();
            this.DataContext = homePageViewModel;
            WelcomeMsg.Text = "Welcome, " + HomepageWindowViewModel.Seller.Username;
            Balance.Text = "Profit: " + HomepageWindowViewModel.Seller.Profit;
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.ShowDialog();
        }
    }
}
