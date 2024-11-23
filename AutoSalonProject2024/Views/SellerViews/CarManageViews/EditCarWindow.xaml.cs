using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.ViewModels;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
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

    }
}
