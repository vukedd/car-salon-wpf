﻿using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ISellerService
    {
        Seller AuthenticateSeller(string username, string password);
        Seller GetSellerById(int SellerId);
        bool RegisterSeller(Seller seller);

    }
}
