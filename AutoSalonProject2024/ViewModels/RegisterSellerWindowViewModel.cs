using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Managers;
using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class RegisterSellerWindowViewModel
    {
        public ICommand RegisterNewSeller { get; set; }
        public string? JMBG { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }

        public RegisterSellerWindowViewModel()
        {
            RegisterNewSeller = new RelayCommand(RegisterNewSellerMet, CanRegisterNewSeller);
        }

        private bool CanRegisterNewSeller(object obj)
        {
            return true;
        }

        private void RegisterNewSellerMet(object obj)
        {
            UserManager.Users.Add(new Seller() { Id = 1, Name = Name, JMBG = JMBG, Username = Username, Password = "Password", Profit = 0 });
            Trace.WriteLine(UserManager.Users[0].Name);
        }
    }
}
