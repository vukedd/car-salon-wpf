using AutoSalonProject2024.Enums;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class Car : INotifyPropertyChanged
    {
        private int _id;
        private int _year;
        private int _horsePower;
        private bool _sold;
        private decimal _purchasePrice;
        private DateOnly? _purchaseDate;
        private CarModel _model;
        private CarBrand _brand;
        private int _brandId;
        private int _modelId;
        private FuelType _fuelType;

        private List<byte[]> _images;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id)); 
                }
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        public int HorsePower
        {
            get => _horsePower;
            set
            {
                if (_horsePower != value)
                {
                    _horsePower = value;
                    OnPropertyChanged(nameof(HorsePower)); 
                }
            }
        }

        public bool Sold
        {
            get => _sold;
            set
            {
                if (_sold != value)
                {
                    _sold = value;
                    OnPropertyChanged(nameof(Sold));
                }
            }
        }

        public decimal PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                if (_purchasePrice != value)
                {
                    _purchasePrice = value;
                    OnPropertyChanged(nameof(PurchasePrice));
                }
            }
        }

        public DateOnly? PurchaseDate
        {
            get => _purchaseDate;
            set
            {
                if (_purchaseDate != value)
                {
                    _purchaseDate = value;
                    OnPropertyChanged(nameof(PurchaseDate)); 
                }
            }
        }

        public CarModel Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public CarBrand Brand
        {
            get => _brand;
            set
            {
                if (_brand != value)
                {
                    _brand = value;
                    OnPropertyChanged(nameof(Brand)); 
                }
            }
        }

        public int BrandId
        {
            get => _brandId;
            set
            {
                if (_brandId != value)
                {
                    _brandId = value;
                    OnPropertyChanged(nameof(BrandId)); 
                }
            }
        }

        public int ModelId
        {
            get => _modelId;
            set
            {
                if (_modelId != value)
                {
                    _modelId = value;
                    OnPropertyChanged(nameof(ModelId));
                }
            }
        }

        public FuelType FuelType
        {
            get => _fuelType;
            set
            {
                if (_fuelType != value)
                {
                    _fuelType = value;
                    OnPropertyChanged(nameof(FuelType)); 
                }
            }
        }

        public List<byte[]> Images
        {
            get => _images;
            set
            {
                if (_images != value)
                {
                    _images = value;
                    OnPropertyChanged(nameof(Images)); 
                }
            }
        }

        public Car() { }
        public Car(int Id, int Year, int HorsePower, bool Sold, decimal PurchasePrice, DateOnly PurchaseDate, CarModel model, CarBrand brand, FuelType FuelType)
        {
            this.Id = Id;
            this.Year = Year;
            this.HorsePower = HorsePower;
            this.Sold = Sold;
            this.PurchasePrice = PurchasePrice;
            this.PurchaseDate = PurchaseDate;
            this.Brand = brand;
            this.Model = model;
            this.ModelId = model.Id;
            this.BrandId = brand.Id;
            this.FuelType = FuelType;
        }

        public Car(int Id, int Year, int HorsePower, bool Sold, decimal PurchasePrice, DateOnly PurchaseDate, CarModel model, CarBrand brand, FuelType FuelType, List<byte[]> Images)
        {
            this.Id = Id;
            this.Year = Year;
            this.HorsePower = HorsePower;
            this.Sold = Sold;
            this.PurchasePrice = PurchasePrice;
            this.PurchaseDate = PurchaseDate;
            this.Brand = brand;
            this.Model = model;
            this.ModelId = model.Id;
            this.BrandId = brand.Id;
            this.FuelType = FuelType;
            this.Images = Images;
        }

        public Car(Car otherCar)
        {
            if (otherCar == null)
            {
                throw new ArgumentNullException(nameof(otherCar), "The car to copy cannot be null.");
            }

            Id = otherCar.Id;
            Year = otherCar.Year;
            HorsePower = otherCar.HorsePower;
            Sold = otherCar.Sold;
            PurchasePrice = otherCar.PurchasePrice;
            PurchaseDate = otherCar.PurchaseDate;
            Model = otherCar.Model;
            Brand = otherCar.Brand;
            BrandId = otherCar.BrandId;
            ModelId = otherCar.ModelId;
            FuelType = otherCar.FuelType;
        }
        public string ToCsv()
        {
            int sold = 1;
            if (Sold == true)
            {
                sold = 0;
            }
            return $"{this.Id}, {this.Year}, {this.HorsePower}, {sold}, {this.PurchasePrice}, {this.PurchaseDate}, {this.Model.Id}, {this.Brand.Id}, {(int)(this.FuelType)}";
        }

        public string toDisplay()
        {
            return $"{this.Id}, {this.Year}, {this.HorsePower}, {this.PurchasePrice}, {this.PurchaseDate}, {this.Model.Name}, {this.Brand.Name}, {(this.FuelType)}";
        }

    }
}
