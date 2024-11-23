using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
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

namespace AutoSalonProject2024.Views.SellerViews.CarManageViews
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        private AddCarViewModel addCarViewModel;
        public AddCarWindow()
        {
            InitializeComponent();
            addCarViewModel = new AddCarViewModel();
            this.DataContext = addCarViewModel;
            fuelType.ItemsSource = Enum.GetValues(typeof(FuelType));
            addCarViewModel.carAdded += OnCarAdded;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((CarBrand)brandCombo.SelectedItem).Name;
            List<CarModel> models = new List<CarModel>();
            foreach (CarModel model in addCarViewModel.Models)
            {
                if (model.Brand.Name == name)
                    models.Add(model);
            }
            modelsCombo.IsEnabled = true;
            modelsCombo.ItemsSource = models;
        }

        private void OnCarAdded(object sender, EventArgs e) 
        {
            this.Close();
        }
    }
}
