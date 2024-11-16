using AutoSalonProject2024.Enums;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        public DateOnly? PurchaseDate { get; set; }
        public decimal SalePrice { get; set; }
        public CarModel Model { get; set; }
        public CarBrand Brand { get; set;}
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public FuelType? FuelType { get; set; }

        public Car() { }
        public Car(int Id, int Year, int HorsePower, bool Sold, decimal PurchasePrice, DateOnly PurchaseDate, decimal SalePrice, CarModel model, CarBrand brand, FuelType FuelType)
        {
            this.Id = Id;
            this.Year = Year;
            this.HorsePower = HorsePower;
            this.Sold = Sold;
            this.PurchasePrice = PurchasePrice;
            this.PurchaseDate = PurchaseDate;
            this.SalePrice = SalePrice;
            this.Brand = brand;
            this.Model = model;
            this.ModelId = model.Id;
            this.BrandId = brand.Id;
            this.FuelType = FuelType;
        }

        public string ToCsv()
        {
            int sold = 1;
            if (Sold == true)
            {
                sold = 0;
            }
            return $"{this.Id}, {this.Year}, {this.HorsePower}, {sold}, {this.PurchasePrice}, {this.PurchaseDate}, {this.SalePrice}, {this.Model.Id}, {this.Brand.Id}, {(int)(this.FuelType)}";
        }

        public string toDisplay()
        {
            return $"{this.Id}, {this.Year}, {this.HorsePower}, {this.PurchasePrice}, {this.PurchaseDate}, {this.SalePrice}, {this.Model.Name}, {this.Brand.Name}, {(this.FuelType)}";
        }
    }
}
