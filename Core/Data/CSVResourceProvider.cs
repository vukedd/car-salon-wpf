using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class CSVResourceProvider
    {
        private static CSVResourceProvider instance;
        private static readonly object _lock = new object();

        public ObservableCollection<Car> carsList { get; } = new ObservableCollection<Car>();
        public ObservableCollection<CarModel> modelsList { get; } = new ObservableCollection<CarModel>();
        public ObservableCollection<CarBrand> brandsList { get; } = new ObservableCollection<CarBrand>();
        public ObservableCollection<Country> countriesList { get; } = new ObservableCollection<Country>();
        public ObservableCollection<Seller> sellerList { get; } = new ObservableCollection<Seller>();
        public ObservableCollection<Transaction> transactionList { get; } = new ObservableCollection<Transaction>();

        public int lastId { get; set; } = 0;
        public int lastUserId { get; set; } = 0;
        public int lastTransactionId { get; set; } = 0;
        private CSVResourceProvider()
        {
            LoadData();
        }

        public static CSVResourceProvider GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new CSVResourceProvider();
                    }
                }
            }

            return instance;
        }

        private void LoadData()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] cars = File.ReadAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Cars.csv");
            string[] brands = File.ReadAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\CarBrands.csv");
            string[] models = File.ReadAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\CarModels.csv");
            string[] countries = File.ReadAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Countries.csv");
            string[] users = File.ReadAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Sellers.csv");
            string[] transactions = File.ReadAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Transactions.csv");

            foreach (string country in countries)
            {
                string[] countryData = country.Split(",");
                int id = int.Parse(countryData[0]);
                string name = countryData[1];

                countriesList.Add(new Country(id, name));
            }

            foreach (string brand in brands)
            {
                string[] brandData = brand.Split(",");
                int id = int.Parse(brandData[0]);
                string name = brandData[1];
                Country country = countriesList.Where(c => c.Id == int.Parse(brandData[2])).FirstOrDefault();

                brandsList.Add(new CarBrand(id, name, country));
            }

            foreach (string model in models)
            {
                string[] modelData = model.Split(",");
                int id = int.Parse(modelData[0]);
                string name = modelData[1];
                CarBrand brand = brandsList.Where(b => b.Id == int.Parse(modelData[2])).FirstOrDefault();


                modelsList.Add(new CarModel(id, name, brand));
            }

            foreach (string car in cars)
            {
                string[] carData = car.Split(",");
                int id = int.Parse(carData[0]);
                int year = int.Parse(carData[1]);
                int horsePower = int.Parse(carData[2]);
                bool sold = true ? int.Parse(carData[3]) == 0 : false;
                decimal purchasePrice = decimal.Parse(carData[4]);
                DateOnly purchaseDate = DateOnly.Parse(carData[5]);
                CarModel model = modelsList.Where(m => m.Id == int.Parse(carData[6])).FirstOrDefault();
                CarBrand brand = brandsList.Where(b => b.Id == int.Parse(carData[7])).FirstOrDefault();
                FuelType fuelType = (FuelType)int.Parse(carData[8]);

                Car newCar = new Car(id, year, horsePower, sold, purchasePrice, purchaseDate, model, brand, fuelType);
                carsList.Add(newCar);

                if (id > lastId)
                {
                    lastId = id;
                }
            }

            foreach (string user in users)
            {
                Trace.WriteLine(user);
                string[] userData = user.Split(",");
                Trace.WriteLine(userData[5]);
                int id = int.Parse(userData[0]);
                string name = userData[1];
                string username = userData[2];
                string password = userData[3];
                string jMBG = userData[4];
                decimal profit = decimal.Parse(userData[5]);
                Seller seller = new Seller(id, name, username, password, jMBG, profit);
                sellerList.Add(seller);

                if (id > lastUserId)
                {
                    lastUserId = id;
                }
            }

            foreach (string transaction in transactions)
            {
                string[] transacData = transaction.Split(",");
                int id = int.Parse(transacData[0]);
                Seller seller = sellerList.Where(s => s.Id == int.Parse(transacData[1])).FirstOrDefault();
                Car car = carsList.Where(c => c.Id == int.Parse(transacData[2])).FirstOrDefault();
                string buyerName = transacData[3];
                string buyerIdNum = transacData[4];
                decimal salePrice = decimal.Parse(transacData[5]);
                DateOnly saleDate = DateOnly.Parse(transacData[6]);

                Transaction newTransac = new Transaction(id, seller, car, buyerName, buyerIdNum, salePrice, saleDate);
                transactionList.Add(newTransac);

                if (id > lastTransactionId)
                {
                    lastTransactionId = id;
                }
            }


        }

        public void SaveData()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            List<string> cars = new List<string>();
            foreach (var item in carsList)
            {
                cars.Add(item.ToCsv());
            }


            File.WriteAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Cars.csv", cars);
            Console.WriteLine("Car saved succesfully");

            List<string> users = new List<string>();
            foreach (var item in sellerList) 
            {
                users.Add(item.toCsv());
            }

            File.WriteAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Sellers.csv", users);
            Console.WriteLine("Users saved succesfully");

            List<string> transactions = new List<string>();
            foreach (var item in transactionList)
            {
                transactions.Add(item.toCsv());
            }

            File.WriteAllLines(Path.Combine(projectDirectory) + "\\Core\\Data\\Transactions.csv", transactions);
            Console.WriteLine("Transaction saved succesfully");
        }
    }
}
