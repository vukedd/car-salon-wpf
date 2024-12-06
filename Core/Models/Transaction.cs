using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoSalonProject2024.Models
{
    public class Transaction : INotifyPropertyChanged
    {
        private int? _id;
        private Seller _seller;
        private Car _car;
        private string _buyerFullName;
        private string _buyerIdNumber;
        private decimal? _salePrice;
        private DateOnly _dateOfTransaction;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int? Id
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

        public Seller Seller
        {
            get => _seller;
            set
            {
                if (_seller != value)
                {
                    _seller = value;
                    OnPropertyChanged(nameof(Seller));
                }
            }
        }

        public Car Car
        {
            get => _car;
            set
            {
                if (_car != value)
                {
                    _car = value;
                    OnPropertyChanged(nameof(Car));
                }
            }
        }

        public string BuyerFullName
        {
            get => _buyerFullName;
            set
            {
                if (_buyerFullName != value)
                {
                    _buyerFullName = value;
                    OnPropertyChanged(nameof(BuyerFullName));
                }
            }
        }

        public string BuyerIdNumber
        {
            get => _buyerIdNumber;
            set
            {
                if (_buyerIdNumber != value)
                {
                    _buyerIdNumber = value;
                    OnPropertyChanged(nameof(BuyerIdNumber));
                }
            }
        }

        public decimal? SalePrice
        {
            get => _salePrice;
            set
            {
                if (_salePrice != value)
                {
                    _salePrice = value;
                    OnPropertyChanged(nameof(SalePrice));
                }
            }
        }

        public DateOnly DateOfTransaction
        {
            get => _dateOfTransaction;
            set
            {
                if (_dateOfTransaction != value)
                {
                    _dateOfTransaction = value;
                    OnPropertyChanged(nameof(DateOfTransaction));
                }
            }
        }

        public Transaction(int Id, Seller seller, Car car, string BuyerFullName, string BuyerIdNumber, decimal SalePrice, DateOnly SaleDate)
        {
            this.Id = Id;
            this.Seller = seller;
            this.Car = car;
            this.BuyerFullName = BuyerFullName;
            this.BuyerIdNumber = BuyerIdNumber;
            this.SalePrice = SalePrice;
            this.DateOfTransaction = DateOnly.FromDateTime(DateTime.Now);
        }

        public Transaction(int Id, Seller seller, Car car, string BuyerFullName, string BuyerIdNumber, decimal SalePrice)
        {
            this.Id = Id;
            this.Seller = seller;
            this.Car = car;
            this.BuyerFullName = BuyerFullName;
            this.BuyerIdNumber = BuyerIdNumber;
            this.SalePrice = SalePrice;
            this.DateOfTransaction = DateOnly.FromDateTime(DateTime.Now);
        }

        public Transaction(Seller seller, Car car, string BuyerFullName, string BuyerIdNumber, decimal SalePrice)
        {
            this.Seller = seller;
            this.Car = car;
            this.BuyerFullName = BuyerFullName;
            this.BuyerIdNumber = BuyerIdNumber;
            this.SalePrice = SalePrice;
            this.DateOfTransaction = DateOnly.FromDateTime(DateTime.Now);
        }

        public string toCsv()
        {
            return $"{Id},{Seller.Id},{Car.Id},{BuyerFullName},{BuyerIdNumber},{SalePrice},{DateOfTransaction}";
        }
    }
}
