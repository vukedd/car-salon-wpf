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
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews.ModelManageViews
{
    /// <summary>
    /// Interaction logic for AddModelWindow.xaml
    /// </summary>
    public partial class AddModelWindow : Window
    {
        private AddModelViewModel _addModelViewModel;
        private ModelManagementWindow _parent;
        public AddModelWindow(ModelManagementWindow modelManagementWindow)
        {
            InitializeComponent();
            _addModelViewModel = new AddModelViewModel();
            this.DataContext = _addModelViewModel;
            _addModelViewModel.OnCarModelAddSuccess += OnCarModelAddSuccess;
            _addModelViewModel.OnCarModelAddFailure += OnCarModelAddFailure;
            _parent = modelManagementWindow;
        }

        private void OnCarModelAddFailure(object? sender, EventArgs e)
        {
            MessageBox.Show("Please check all fields before submiting!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            validateFields();
        }

        private void OnCarModelAddSuccess(object? sender, EventArgs e)
        {
            _parent.RefreshCarModels();
            this.Close();
        }

        private void CarModelNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateFields();
        }

        private void CarBrandCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateFields();
        }

        private void validateFields()
        {
            if (CarModelNameTB.Text.Length < 3)
            {
                CarModelValidation.Visibility = Visibility.Visible;
            }
            else
            {
                CarModelValidation.Visibility = Visibility.Collapsed;
            }

            if (CarBrandCombo.SelectedItem == null)
            {
                CarBrandValidation.Visibility = Visibility.Visible;
            }
            else
            {
                CarBrandValidation.Visibility = Visibility.Collapsed;
            }
        }
    }
}
