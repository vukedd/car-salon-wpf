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
    public class LoginViewModel
    {
        public ICommand AuthenticateUser { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public LoginViewModel()
        {
            AuthenticateUser = new RelayCommand(AuthenticateUserMet, CanAuthenticateUser);
        }

        private bool CanAuthenticateUser(object obj)
        {
            return true;
        }

        private void AuthenticateUserMet(object obj)
        {
            foreach (User u in UserManager.Users) 
            {
                if (u.Username == Username && u.Password == Password)
                {
                    Trace.WriteLine("You have logged in");
                }
            }
        }
    }
}
