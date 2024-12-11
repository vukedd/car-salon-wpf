﻿using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using AutoSalonProject2024.Views.SellerViews.BrandManageViews;
using AutoSalonProject2024.Views.SellerViews.CarManageViews;
using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private HomepageWindowViewModel homePageViewModel;
        public HomepageWindow()
        {
            InitializeComponent();
            homePageViewModel = new HomepageWindowViewModel();
            WelcomeMsg.Text = "Hello, " + HomepageWindowViewModel.Seller.Username;
            this.DataContext = homePageViewModel;
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow(this);
            addCarWindow.ShowDialog();
        }

        public void refreshCars()
        {
            homePageViewModel.UpdateCars();
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
                MessageBox.Show("Please select vehicle!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarListView.SelectedItem != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Delete confirmation", System.Windows.MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Car car = (Car)CarListView.SelectedItem;
                    homePageViewModel.DeleteCar(car.Id);
                    homePageViewModel.Cars.Remove(car);
                }
            }
            else
            {
                MessageBox.Show("Please select vehicle!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}
