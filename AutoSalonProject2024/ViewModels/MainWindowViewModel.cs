using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.Views.LoginViews;
using AutoSalonProject2024.Views.RegisterViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand ShowLoginWindow { get; set; }
        public ICommand ShowRegisterAsSellerWindow { get; set; }
        public ICommand ShowRegisterAsBuyerWindow { get; set; }


        public Salon Salon { get; set; }

        public MainWindowViewModel()
        {
            Salon = new Salon();
            Salon.Name = "Auto Salon Djuricic";
            Salon.Address = new Address(1, "Trg Dositeja Obradovica", "7A", "21000");
            ShowRegisterAsSellerWindow = new RelayCommand(ShowRegisterAsSellerWindowMet, CanShowRegisterAsSellerWindow);
            ShowRegisterAsBuyerWindow = new RelayCommand(ShowRegisterAsBuyerWindowMet, CanShowRegisterAsBuyerWindow);
            ShowLoginWindow = new RelayCommand(ShowLoginWindowMet, CanShowLoginWindow);
        }

        public bool CanShowRegisterAsBuyerWindow(object obj)
        {
            return true;
        }

        public void ShowRegisterAsBuyerWindowMet(object obj)
        {
            RegisterBuyerWindow RegisterBuyerWindow = new RegisterBuyerWindow();
            RegisterBuyerWindow.ShowDialog();
        }

        public bool CanShowRegisterAsSellerWindow(object obj)
        {
            return true;
        }

        public void ShowRegisterAsSellerWindowMet(object obj)
        {
            RegisterSellerWindow RegisterSellerWindow = new RegisterSellerWindow();
            RegisterSellerWindow.ShowDialog();
        }

        public void ShowLoginWindowMet(object obj)
        {
            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.ShowDialog();
        }
        public bool CanShowLoginWindow(object obj)
        {
            return true;
        }
        

    }
}
