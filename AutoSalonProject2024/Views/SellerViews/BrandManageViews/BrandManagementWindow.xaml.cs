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

namespace AutoSalonProject2024.Views.SellerViews.BrandManageViews
{
    /// <summary>
    /// Interaction logic for BrandManagementWindow.xaml
    /// </summary>
    public partial class BrandManagementWindow : Window
    {
        private BrandManagementViewModel _brandManagementViewModel;
        public BrandManagementWindow()
        {
            InitializeComponent();
            this._brandManagementViewModel = new BrandManagementViewModel();
            this.DataContext = _brandManagementViewModel;
        }

        private void AddBrandButton_Click(object sender, RoutedEventArgs e)
        {
            AddBrandWindow addBrandWindow = new AddBrandWindow(this);
            addBrandWindow.ShowDialog();
        }

        public void OnBrandAdd()
        {
            _brandManagementViewModel.RefreshCars();
        }

        private void EditBrandButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBrandButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrandListView.SelectedItem == null)
            {
                MessageBox.Show("You must select a brand for deletion!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this brand?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    bool deletionResult = _brandManagementViewModel.DeleteBrand(BrandListView.SelectedItem);
                    if (deletionResult)
                    {
                        _brandManagementViewModel.CarBrands.Remove(BrandListView.SelectedItem as CarBrand);
                        
                    } 
                    else
                    {
                        MessageBox.Show("Brand couldn't be deleted because there are cars of the following brand in the system!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
