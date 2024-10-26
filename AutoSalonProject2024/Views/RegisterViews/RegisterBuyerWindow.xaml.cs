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
    /// Interaction logic for RegisterKupacWindow.xaml
    /// </summary>
    public partial class RegisterBuyerWindow : Window
    {
        public RegisterBuyerWindow()
        {
            InitializeComponent();
            RegisterBuyerWindowViewModel registerBuyerWindowViewModel = new RegisterBuyerWindowViewModel();
            this.DataContext = registerBuyerWindowViewModel;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
