using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews.CarManageViews
{
    /// <summary>
    /// Interaction logic for EditCarWindow.xaml
    /// </summary>
    public partial class EditCarWindow : Window
    {
        ObservableCollection<CarModel> carModels;
        EditCarViewModel editCarViewModel;
        public EditCarWindow(Car car)
        {
            InitializeComponent();
            editCarViewModel = new EditCarViewModel(car);
            fuelType.ItemsSource = Enum.GetValues(typeof(FuelType));
            fuelType.SelectedItem = car.FuelType;
            editCarViewModel.CarEditEvent += onCarEdit;
            editCarViewModel.CarEditError += onCarEditError;

            brandCombo.SelectedItem = car.Brand;
            carModels = new ObservableCollection<CarModel>();
            foreach (CarModel model in editCarViewModel.Models) 
            {
                if (model.Brand.Id == car.BrandId)
                {
                    carModels.Add(model);
                }
            }
            modelsCombo.ItemsSource = carModels;
            this.DataContext = editCarViewModel;
        }

        private void brandCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarBrand brand = (CarBrand)brandCombo.SelectedItem;
            carModels = new ObservableCollection<CarModel>();
            foreach (CarModel model in editCarViewModel.Models)
            {
                if (model.Brand == brand)
                {
                    carModels.Add(model);
                }
            }
            modelsCombo.ItemsSource = carModels;
            modelsCombo.SelectedItem = carModels[0];
        }
        private void onCarEdit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onCarEditError(object sender, EventArgs e)
        {
            MessageBox.Show("Please check all fields!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            Trace.WriteLine("Hello");
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ProductionYearTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(ProductionYearTB.Text, null, out int result))
            {
                if ((result < 1950 || result > 2025)) 
                {
                    ProductionYearValidationLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    ProductionYearValidationLabel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void fuelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fuelType.SelectedItem == null)
            {
                FuelTypeValidationLabel.Visibility = Visibility.Visible;
            }
            else
            {
                FuelTypeValidationLabel.Visibility = Visibility.Hidden;
            }
        }

        private void HorsePower_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(HorsePowerTB.Text, null, out int result))
            {
                if (result < 50 || result > 1000)
                {
                    HorsePowerValidationLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    HorsePowerValidationLabel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void PurchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(PurchasePriceTB.Text, null, out int result))
            {
                if (result < 0 || result > 5000000)
                {
                    PurchasePriceValidationLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    PurchasePriceValidationLabel.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
