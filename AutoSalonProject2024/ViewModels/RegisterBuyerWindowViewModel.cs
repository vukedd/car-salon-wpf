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
    public class RegisterBuyerWindowViewModel
    {
        public ICommand RegisterNewBuyer { get; set; }
        public string? JMBG { get; set; }
        public string? IdNumber { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        
        public RegisterBuyerWindowViewModel()
        {
            RegisterNewBuyer = new RelayCommand(RegisterNewBuyerMet, CanRegisterNewBuyer);
        }

        private bool CanRegisterNewBuyer(object obj)
        {
            return true;
        }

        private void RegisterNewBuyerMet(object obj)
        {
            UserManager.Users.Add(new Buyer() { Id = 1, JMBG = JMBG, IdNumber = IdNumber, Name = Name, Password = "Password", Username = Username});
            Trace.WriteLine(UserManager.Users[0].Name);
        }
    }
}
