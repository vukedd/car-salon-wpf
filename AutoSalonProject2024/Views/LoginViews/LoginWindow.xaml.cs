﻿using AutoSalonProject2024.ViewModels;
using AutoSalonProject2024.Views.SellerViews;
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

namespace AutoSalonProject2024.Views.LoginViews
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();
            this.DataContext = loginViewModel;

            loginViewModel.AuthenticationSuccess += OnAuthenticationSuccess;
            loginViewModel.AuthenticationFailure += OnAuthenticationFailure;
        }

        private void OnAuthenticationFailure(object? sender, EventArgs e)
        {
            validation.Visibility = Visibility.Visible;
        }

        private void OnAuthenticationSuccess(object sender, EventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
                else
                {
                    window.Hide();
                }
            }

            HomepageWindow homepage = new HomepageWindow();
            homepage.Show();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { 
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; 
            }
        }
    }
}
