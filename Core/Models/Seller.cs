using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoSalonProject2024.Models
{
    public class Seller : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _username;
        private string _password;
        private string _jmbg;
        private decimal _profit;
        private List<Transaction>? _sales;

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

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string JMBG
        {
            get => _jmbg;
            set
            {
                if (_jmbg != value)
                {
                    _jmbg = value;
                    OnPropertyChanged(nameof(JMBG));
                }
            }
        }

        public decimal Profit
        {
            get => _profit;
            set
            {
                if (_profit != value)
                {
                    _profit = value;
                    OnPropertyChanged(nameof(Profit));
                }
            }
        }

        public List<Transaction>? Sales
        {
            get => _sales;
            set
            {
                if (_sales != value)
                {
                    _sales = value;
                    OnPropertyChanged(nameof(Sales));
                }
            }
        }
        public Seller(int Id, string Name, string Username, string Password, string JMBG, decimal Profit)
        {
            this.Id = Id;
            this.Name = Name;
            this.Username = Username;
            this.Password = Password;
            this.JMBG = JMBG;
            this.Profit = Profit;
            this.Sales = new List<Transaction>();
        }

        public Seller(){}

        public void addProfit(decimal profit) 
        {
            Profit = profit;
        }
        internal string toCsv()
        {
            Trace.WriteLine($"{Id},{Name},{Username},{Password},{JMBG},{Profit}");
            return $"{Id},{Name},{Username},{Password},{JMBG},{Profit}";
        }
    }
}
