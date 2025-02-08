using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using AutoSalonProject2024.Views.LoginViews;
using AutoSalonProject2024.Views.RegisterViews;
using Core.IRepositories;
using Core.Repositories.DBRepositories;
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

        private ICarDealershipRepository _carDealershipRepository;
        public Dealership Salon { get; set; }

        public MainWindowViewModel()
        {
            _carDealershipRepository = new CarDealershipRepository();
            Salon = _carDealershipRepository.GetDealership();
            ShowRegisterAsSellerWindow = new RelayCommand(ShowRegisterAsSellerWindowMet, CanShowRegisterAsSellerWindow);
            ShowLoginWindow = new RelayCommand(ShowLoginWindowMet, CanShowLoginWindow);
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
