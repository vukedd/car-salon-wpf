using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Interaction logic for AddBrandWindow.xaml
    /// </summary>
    public partial class AddBrandWindow : Window
    {
        private AddCarBrandViewModel _addCarBrandViewModel;
        private BrandManagementWindow _parent;
        public AddBrandWindow(BrandManagementWindow brandManagementWindow)
        {
            InitializeComponent();
            _addCarBrandViewModel = new AddCarBrandViewModel();
            _addCarBrandViewModel.OnCreationSuccess += OnCreationSuccess;
            _addCarBrandViewModel.OnCreationFailure += OnCreationFailure;
            _parent = brandManagementWindow;
            this.DataContext = _addCarBrandViewModel;
        }

        private void OnCreationFailure(object? sender, EventArgs e)
        {
            MessageBox.Show("Error while creating car brand, please check all field!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            validateFields();
        }

        private void OnCreationSuccess(object? sender, EventArgs e)
        {
            _parent.OnBrandAdd();
            this.Close();
        }

        private void BrandNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateFields();
        }

        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateFields();
        }

        private bool validateFields()
        {
            bool invalidLength = false;
            bool alreadyExists = false;

            if (CountryComboBox.SelectedItem == null)
            {
                comboBoxValidation.Visibility = Visibility.Visible;
                brandNameLBL.Margin = new Thickness(87, 0, 0, 0);
            }
            else
            {
                comboBoxValidation.Visibility = Visibility.Collapsed;
                brandNameLBL.Margin = new Thickness(87, 30, 0, 0);
            }

            if (BrandName.Text.Length < 4)
            {
                lengthValidation.Visibility = Visibility.Visible;
                SubmitBTN.Margin = new Thickness(0, 20, 0, 0);
                invalidLength = true;
            }
            else
            {
                lengthValidation.Visibility = Visibility.Collapsed;
                invalidLength = false;
                if (!alreadyExists)
                    SubmitBTN.Margin = new Thickness(0, 50, 0, 0);
            }

            if (_addCarBrandViewModel.BrandExists(BrandName.Text))
            {
                existValidation.Visibility = Visibility.Visible;
                SubmitBTN.Margin = new Thickness(0, 20, 0, 0);
                alreadyExists = true;
            }
            else
            {
                existValidation.Visibility = Visibility.Collapsed;
                alreadyExists = false;
                if (!invalidLength)
                    SubmitBTN.Margin = new Thickness(0, 50, 0, 0);

            }

            return alreadyExists && invalidLength;
        }
    }
}
