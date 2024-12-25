using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using Microsoft.Win32;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace AutoSalonProject2024.Views.SellerViews.CarManageViews
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        private AddCarViewModel addCarViewModel;
        private HomepageWindow _parent;
        public AddCarWindow(HomepageWindow homepageWindow)
        {
            InitializeComponent();
            _parent = homepageWindow;
            addCarViewModel = new AddCarViewModel();
            this.DataContext = addCarViewModel;

            fuelType.ItemsSource = Enum.GetValues(typeof(FuelType));
            addCarViewModel.carAdded += OnCarAdded;
            addCarViewModel.carAddError += OnCarAddError;
            addCarViewModel.onImageUploadChange += OnImageUploadChange;
            modelsCombo.IsEnabled = false;
            PurchaseDateDP.DisplayDateEnd = DateTime.Today;
            PurchaseDateDP.SelectedDate = DateTime.Today;
        }

        private void OnImageUploadChange(object? sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (addCarViewModel.FileNames.Count() > 0 && addCarViewModel.FileNames.Count() < 6)
            {
                foreach (var filename in addCarViewModel.FileNames)
                {
                    sb.Append(filename + ";");
                }

                ImageUploadLBL.Content = sb.ToString();
                ImageUploadLBL.Margin = new Thickness(100, 0, 0, 0);
            }
            else
            {
                MessageBox.Show("You can upload maximum 5 images", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                ImageUploadLBL.Content = "No images uploaded*";
                ImageUploadLBL.Margin = new Thickness(180, 0, 0, 0);
            }
        }

        private void OnCarAddError(object? sender, EventArgs e)
        {
            MessageBox.Show("Please check all fields before submitting!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            validateFields();
        }

        private void BrandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((CarBrand)brandCombo.SelectedItem).Name;
            List<CarModel> models = new List<CarModel>();
            foreach (CarModel model in addCarViewModel.Models)
            {
                if (model.Brand.Name == name)
                    models.Add(model);
            }
            modelsCombo.IsEnabled = true;
            if (models.Count() > 0)
                modelsCombo.SelectedItem = models[0];
            modelsCombo.ItemsSource = models;

            validateFields();
        }

        private void OnCarAdded(object sender, EventArgs e)
        {
            _parent.refreshCars();
            this.Close();
        }

        private void ProductionYearTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateFields();
        }

        private void fuelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateFields();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validateFields();
        }

        private void HorsePower_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateFields();
        }

        private void PurchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateFields();
        }

        private void modelsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateFields();
        }

        private void validateFields()
        {
            bool validPrice = false;
            bool validHP = false;
            bool validFuelType = false;
            bool validProdYear = false;

            if (int.TryParse(PurchasePriceTB.Text, null, out int result1))
            {
                if (result1 < 0 || result1 > 5000000)
                {
                    PurchasePriceValidationLabel.Visibility = Visibility.Visible;
                    validPrice = false;
                }
                else
                {
                    PurchasePriceValidationLabel.Visibility = Visibility.Hidden;
                    validPrice = true;
                }
            }
            else
            {
                PurchasePriceValidationLabel.Visibility = Visibility.Visible;
                validPrice = false;
            }

            if (int.TryParse(HorsePowerTB.Text, null, out int result2))
            {
                if (result2 < 50 || result2 > 1000)
                {
                    HorsePowerValidationLabel.Visibility = Visibility.Visible;
                    validHP = false;
                }
                else
                {
                    HorsePowerValidationLabel.Visibility = Visibility.Hidden;
                    validHP = true;
                }
            }
            else
            {
                HorsePowerValidationLabel.Visibility = Visibility.Visible;
                validHP = false;
            }

            if (fuelType.SelectedItem == null)
            {
                FuelTypeValidationLabel.Visibility = Visibility.Visible;
                validFuelType = false;
            }
            else
            {
                FuelTypeValidationLabel.Visibility = Visibility.Hidden;
                validFuelType = true;
            }

            if (int.TryParse(ProductionYearTB.Text, null, out int result3))
            {
                if (result3 < 1950 || result3 > 2025)
                {
                    ProductionYearValidationLabel.Visibility = Visibility.Visible;
                    validProdYear = false;
                }
                else
                {
                    ProductionYearValidationLabel.Visibility = Visibility.Hidden;
                    validProdYear = true;
                }
            }
            else
            {
                ProductionYearValidationLabel.Visibility = Visibility.Visible;
                validProdYear = false;
            }

            if (brandCombo.SelectedItem == null)
            {
                BrandValidationLabel.Visibility = Visibility.Visible;
            } 
            else
            {
                BrandValidationLabel.Visibility = Visibility.Collapsed;
            }

            if (modelsCombo.SelectedItem == null)
            {
                ModelValidationLabel.Visibility = Visibility.Visible;
            }
            else
            {
                ModelValidationLabel.Visibility = Visibility.Collapsed;
            }
            //return validFuelType && validHP && validPrice && validProdYear;
        }
    }
}
