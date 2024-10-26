using AutoSalonProject2024.Enums;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public bool Sold { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal SalePrice { get; set; }
        public CarModel Model { get; set; }
        public FuelType FuelType { get; set; }
        public Seller ListedBy { get; set; }

    }
}
