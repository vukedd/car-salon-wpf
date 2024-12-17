using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using AutoSalonProject2024.Views.SellerViews.BrandManageViews;
using AutoSalonProject2024.Views.SellerViews.CarManageViews;
using AutoSalonProject2024.Views.SellerViews.ModelManageViews;
using Azure.Core.Serialization;
using Core.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews
{
    /// <summary>
    /// Interaction logic for HomepageWindow.xaml
    /// </summary>
    public partial class HomepageWindow : Window
    {
        private HomepageWindowViewModel homePageViewModel;
        private bool isAscending = true;
        private static string[] propertyNames = { "Brand.Name", "Model.Name", "Brand.Country.Name", "Year", "FuelType", "HorsePower", "PurchaseDate", "PurchasePrice" };


        public HomepageWindow()
        {
            InitializeComponent();
            homePageViewModel = new HomepageWindowViewModel();
            WelcomeMsg.Text = "Hello, " + HomepageWindowViewModel.Seller.Username;
            this.DataContext = homePageViewModel;

            string[] propNames = { "Brand name", "Model name", "Country name", "Production year", "Fuel type", "Horse power", "Purchase date", "Purchase price" };
            PropertySortCombo.ItemsSource = propNames;

            string[] order = { "Ascending", "Descending" };
            SortOrderCombo.ItemsSource = order;

            CarListView.Items.SortDescriptions.Add(new SortDescription("Brand.Name", ListSortDirection.Ascending));
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow(this);
            addCarWindow.ShowDialog();
        }

        public void refreshCars()
        {
            homePageViewModel.UpdateCars();
            SearchBar.Text = "";
            PriceRangeFromTxtBox.Text = "";
            PriceRangeToTxtBox.Text = "";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarListView.SelectedItem != null)
            {
                Car car = (Car)CarListView.SelectedItem;
                EditCarWindow editCarWindow = new EditCarWindow(car);
                editCarWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select vehicle for edit!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var carSelected = (Car)CarListView.SelectedItem;
            if (CarListView.SelectedItem != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to remove the following vehicle: " + carSelected.Brand.Name + " " + carSelected.Model.Name + "?", "Confirm deletion", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Car car = carSelected;
                    homePageViewModel.DeleteCar(car.Id);
                    homePageViewModel.Cars.Remove(car);
                }
            }
            else
            {
                MessageBox.Show("Please select vehicle for deletion!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogOutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window == Application.Current.MainWindow)
                {
                    window.Show();
                    HomepageWindowViewModel.Seller = null;
                }
                else
                {
                    window.Close();
                }
            }
        }

        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarListView.SelectedItem != null)
            {
                SaleWindow saleWindow = new SaleWindow((Car)CarListView.SelectedItem, this);
                saleWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select vehicle for sale!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowSalesButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionManagementWindow transactionManagementWindow = new TransactionManagementWindow(HomepageWindowViewModel.Seller);
            transactionManagementWindow.ShowDialog();
        }

        private void ShowBrandsButton_Click(object sender, RoutedEventArgs e)
        {
            BrandManagementWindow brandManagementWindow = new BrandManagementWindow();
            brandManagementWindow.ShowDialog();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            homePageViewModel.FilterCars(SearchBar.Text.Trim());
        }

        private void PriceRangeSubmit(object sender, RoutedEventArgs e)
        {
            bool validFrom = false;
            bool validTo = false;
            bool validSearchBar = false;

            int from = 0;
            if (PriceRangeFromTxtBox.Text.Trim() != "")
            {
                from = int.Parse(PriceRangeFromTxtBox.Text);
                validFrom = true;
            }


            int to = 0;

            if (PriceRangeToTxtBox.Text.Trim() != "")
            {
                to = int.Parse(PriceRangeToTxtBox.Text);
                validTo = true;
            }

            string filter = "";
            if (SearchBar.Text.Trim() != "")
            {
                filter = SearchBar.Text.Trim();
                validSearchBar = true;
            }

            if ((validFrom || validTo))
            {
                homePageViewModel.FilterCarsPrice(from, to, filter);
            }
            else
            {
                MessageBox.Show("Please fill in at least one field!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //homePageViewModel.FilterCarsPrice(from, to, filter);
        }

        private void PriceRangeToTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PriceRangeFromTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ShowModelsButton_Click(object sender, RoutedEventArgs e)
        {
            ModelManagementWindow modelManagementWindow = new ModelManagementWindow();
            modelManagementWindow.ShowDialog();
        }

        private void PropertySortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListView.Items.SortDescriptions[0] = new SortDescription(propertyNames[PropertySortCombo.SelectedIndex], SortOrderCombo.SelectedItem == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        private void SortOrderCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListView.Items.SortDescriptions[0] = new SortDescription(propertyNames[PropertySortCombo.SelectedIndex], SortOrderCombo.SelectedItem == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }
    }
}
