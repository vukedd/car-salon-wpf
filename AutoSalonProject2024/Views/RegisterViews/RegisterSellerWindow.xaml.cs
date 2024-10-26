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

namespace AutoSalonProject2024.Views.RegisterViews
{
    /// <summary>
    /// Interaction logic for RegisterProdavacWindow.xaml
    /// </summary>
    public partial class RegisterSellerWindow : Window
    {
        public RegisterSellerWindow()
        {
            InitializeComponent();
            RegisterSellerWindowViewModel registerSellerWindowViewModel = new RegisterSellerWindowViewModel();
            this.DataContext = registerSellerWindowViewModel;
        }
    }
}
