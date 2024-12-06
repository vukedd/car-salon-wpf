using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories.DBRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SellerService : ISellerService
    {
        private ISellerRepository _sellerRepository;
        public SellerService()
        {
            _sellerRepository = new SellerRepositoryDB();
        }
        public Seller AuthenticateSeller(string username, string password)
        {
            return _sellerRepository.AuthenticateSeller(username, password);
        }
    }
}
