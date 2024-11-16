using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Managers;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.Views.RegisterViews;
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
        public ICommand RegisterNewSeller { get; set; }
        public string? JMBG { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { private get; set; }

        public RegisterWindowViewModel()
        {
            RegisterNewSeller = new RelayCommand(RegisterNewSellerMet, CanRegisterNewSeller);
            UserManager.Users.Add(new Seller() { Id = 1, Name="Vukasin", JMBG="2805003800003",Username="vukedd", Password = "vukedd"});
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
                foreach (Seller s in UserManager.Users)
                {
                    if (s.Username.ToLower() == Username.ToLower())
                    {
                        onUserAlreadyExists();
                        return;
                    }
                }
                UserManager.Users.Add(new Seller() { Id = 1, Name = Name.Trim().ToLower(), JMBG = JMBG.Trim(), Username = Username.Trim().ToLower(), Password = Password.Trim(), Profit = 0 });
                onRegisterSuccess();
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
