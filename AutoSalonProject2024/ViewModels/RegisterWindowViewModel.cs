using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Managers;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.Views.RegisterViews;
using Core.IServices;
using Core.Repositories.DBRepositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class RegisterWindowViewModel
    {
        public event EventHandler UserAlreadyExists;
        public event EventHandler RegisterSuccess;
        public ISellerService _sellerService;
        public ICommand RegisterNewSeller { get; set; }
        public string? JMBG { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { private get; set; }

        public RegisterWindowViewModel()
        {
            RegisterNewSeller = new RelayCommand(RegisterNewSellerMet, CanRegisterNewSeller);
            _sellerService = new SellerService();
        }

        private bool CanRegisterNewSeller(object obj)
        {
            return true;
        }

        private void RegisterNewSellerMet(object obj)
        {
            if (RegisterSellerWindow.isInputDataValid.Any(e => e == false))
            {
                Trace.WriteLine("Input valid data");
            }
            else
            {
                if (_sellerService.RegisterSeller(new Seller() { Id = 0, Name = Name.Trim().ToLower(), JMBG = JMBG.Trim(), Username = Username.Trim().ToLower(), Password = Password.Trim(), Profit = 0 }))
                {
                    onRegisterSuccess();
                } 
                else
                {
                    onUserAlreadyExists();
                }
            }
        }

        private void onRegisterSuccess()
        {
            RegisterSuccess?.Invoke(this, EventArgs.Empty);
        }

        private void onUserAlreadyExists()
        {
            UserAlreadyExists?.Invoke(this, EventArgs.Empty);
        }
    }
}
