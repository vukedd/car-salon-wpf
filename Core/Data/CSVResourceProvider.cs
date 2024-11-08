using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class CSVResourceProvider
    {
        private static CSVResourceProvider instance;
        private static readonly object _lock = new object();

        public List<Car> carsList { get; } = new List<Car>();
        public List<CarModel> modelsList { get; } = new List<CarModel>();
        public List<CarBrand> brandsList { get; } = new List<CarBrand>();
        public List<Country> countriesList { get; } = new List<Country>();
        public int lastId { get; set; } = 0;
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

            foreach (string country in countries)
            {
                string[] countryData = country.Split(",");
                int id = int.Parse(countryData[0]);
                string name = countryData[1];

                countriesList.Add(new Country(id, name));
            }

            foreach (string brand in brands)
            {
                Console.WriteLine(brand);
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
                decimal salePrice = decimal.Parse(carData[6]);
                CarModel model = modelsList.Where(m => m.Id == int.Parse(carData[7])).FirstOrDefault();
                CarBrand brand = brandsList.Where(b => b.Id == int.Parse(carData[8])).FirstOrDefault();
                FuelType fuelType = (FuelType)int.Parse(carData[9]);

                if (id > lastId)
                {
                    lastId = id;
                }

                Car newCar = new Car(id, year, horsePower, sold, purchasePrice, purchaseDate, salePrice, model, brand, fuelType);
                carsList.Add(newCar);
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
        }
    }
}
