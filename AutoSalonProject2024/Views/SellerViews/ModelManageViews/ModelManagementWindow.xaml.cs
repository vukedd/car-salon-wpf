using AutoSalonProject2024.Models;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace AutoSalonProject2024.Views.SellerViews.ModelManageViews
{
    /// <summary>
    /// Interaction logic for ModelManagementWindow.xaml
    /// </summary>
    public partial class ModelManagementWindow : Window
    {
        ModelsManagementViewModel modelsManagementViewModel;
        public ModelManagementWindow()
        {
            InitializeComponent();
            modelsManagementViewModel = new ModelsManagementViewModel();
            this.DataContext = modelsManagementViewModel;
        }

        internal void RefreshCarModels()
        {
            modelsManagementViewModel.UpdateModels();
            this.DataContext = modelsManagementViewModel;
        }

        private void AddModelButton_Click(object sender, RoutedEventArgs e)
        {
            AddModelWindow _addModelWindow = new AddModelWindow(this);
            _addModelWindow.ShowDialog();
        }

        private void DeleteModelButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (CarModel)ModelsListView.SelectedItem;
            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to the delete the following model: " + selectedItem.Name, "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    CarModel carModel = (CarModel)ModelsListView.SelectedItem;
                    modelsManagementViewModel.DeleteCarModel(carModel);
                    modelsManagementViewModel.Models.Remove(carModel);
                }
            }
            else
            {
                MessageBox.Show("You must select car model for deletion!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
