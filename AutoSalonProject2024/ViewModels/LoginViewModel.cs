using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Managers;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.Views.SellerViews;
using Core.Data;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class LoginViewModel
    {
        public event EventHandler AuthenticationSuccess;
        public event EventHandler AuthenticationFailure;

        private ISellerService _sellerService;
        public ICommand AuthenticateUser { get; set; }
        public string? Username { get; set; }
        public string? Password { private get; set; }

        public LoginViewModel()
        {
            AuthenticateUser = new RelayCommand(AuthenticateUserMet, CanAuthenticateUser);
            _sellerService = new SellerService();
        }

        private bool CanAuthenticateUser(object obj)
        {
            return true;
        }

        private void AuthenticateUserMet(object obj)
        {
            Seller seller = _sellerService.AuthenticateSeller(Username, Password);
            if (seller != null)
            {
                HomepageWindowViewModel.Seller = seller;
                OnAuthenticationSuccess();
                return;
            }

            OnAuthenticationFailure();
        }

        protected void OnAuthenticationFailure()
        {
            AuthenticationFailure?.Invoke(this, EventArgs.Empty);
        }

        protected void OnAuthenticationSuccess()
        {
            AuthenticationSuccess?.Invoke(this, EventArgs.Empty);
        }
    }
}
