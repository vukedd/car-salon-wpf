using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ISellerRepository
    {
        Seller AuthenticateSeller(string username, string password);
        Seller GetSellerById(int SellerId);
        Seller GetSellerByUsername(string username);
        bool RegisterSeller(Seller seller);
    }
}
