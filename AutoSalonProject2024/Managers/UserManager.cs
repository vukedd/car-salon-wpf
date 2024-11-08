using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Managers
{
    public class UserManager
    {
        public static ObservableCollection<Seller> Users { get; set; } = new ObservableCollection<Seller>();

        public UserManager(){}

        public void AddUser(Seller seller)
        {
            Users.Add(seller);
        }
    }
}
