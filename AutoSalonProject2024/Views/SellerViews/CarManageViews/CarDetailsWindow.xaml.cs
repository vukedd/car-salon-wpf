using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace AutoSalonProject2024.Views.SellerViews.CarManageViews
{
    /// <summary>
    /// Interaction logic for CarDetailsWindow.xaml
    /// </summary>
    public partial class CarDetailsWindow : Window
    {
        private CarDetailsViewModel _carDetailsViewModel;
        public CarDetailsWindow(int id)
        {
            InitializeComponent();
            _carDetailsViewModel = new CarDetailsViewModel(id);
            this.DataContext = _carDetailsViewModel;            
        }
    }
}
