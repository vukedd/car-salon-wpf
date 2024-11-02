using AutoSalonProject2024.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static bool[] isInputDataValid { get; set; } = { false, false, false, false };
        public RegisterSellerWindow()
        {
            InitializeComponent();
            RegisterWindowViewModel registerWindowViewModel = new RegisterWindowViewModel();
            this.DataContext = registerWindowViewModel;

            registerWindowViewModel.UserAlreadyExists += onUserAlreadyExists;
            registerWindowViewModel.RegisterSuccess += onRegisterSuccess;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                int length = ((PasswordBox)sender).Password.Length;
                if ((length < 8 | length > 16) || ((PasswordBox)sender).Password.Count(c => (c >= '0' && c <= '9')) < 1) 
                {
                    PasswordValidation.ToolTip = "Password must have from 8 to 16 characters where at least one is a number";
                    PasswordValidation.Visibility = Visibility.Visible;
                    isInputDataValid[0] = false;
                } 
                else
                {
                    ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
                    PasswordValidation.Visibility = Visibility.Hidden;
                    isInputDataValid[0] = true;
                }
            }
        }

        private void previewTextInput(object sender, TextCompositionEventArgs e) 
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void JMBGField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                int length = ((TextBox)sender).Text.Length;
                if (length != 13) 
                {
                    JMBGValidation.Visibility = Visibility.Visible;
                    JMBGValidation.ToolTip = "JMBG must consist of 13 numbers";
                    isInputDataValid[1] = false;
                }
                else
                {
                    JMBGValidation.Visibility = Visibility.Hidden;
                    ((dynamic)this.DataContext).JMBG = ((TextBox)sender).Text;
                    isInputDataValid[1] = true;
                }
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                int length = ((TextBox)sender).Text.Length;
                if ((length < 5 || length > 15) || ((TextBox)sender).Text.Any(c => c == ' ') || ((TextBox)sender).Text.Any(c => c >= '0' && c <= '9'))
                {
                    NameValidation.Visibility = Visibility.Visible;
                    NameValidation.ToolTip = "Name must be at least 5 and maximum 15 characters, without spaces or numbers";
                    isInputDataValid[2] = false;
                }
                else
                {
                    NameValidation.Visibility = Visibility.Hidden;
                    ((dynamic)this.DataContext).Name = ((TextBox)sender).Text;
                    isInputDataValid[2] = true;
                }
            }
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                int length = ((TextBox)sender).Text.Length;
                if ((length < 5 || length > 15) || ((TextBox)sender).Text.Any(c => c == ' '))
                {
                    UsernameValidation.Visibility = Visibility.Visible;
                    UsernameValidation.ToolTip = "Username must be at least 5 and maximum 15 characters, without spaces";
                    isInputDataValid[3] = false;
                }
                else
                {
                    UsernameValidation.Visibility = Visibility.Hidden;
                    ((dynamic)this.DataContext).Username = ((TextBox)sender).Text;
                    isInputDataValid[3] = true;
                }
            }
        }

        private void onUserAlreadyExists(object sender, EventArgs e)
        {
            MessageBox.Show("Username already taken");
        }

        private void onRegisterSuccess(object sender, EventArgs e)
        {
            MessageBox.Show("You have successfully registered!");
            this.Close();
        }
    }
}
