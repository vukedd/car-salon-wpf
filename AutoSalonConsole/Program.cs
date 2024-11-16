using AutoSalonProject2024.Enums;
using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonConsole
{
    public class Program
    {
        private static Handler handler = new Handler();
        public static void Main(string[] args) 
        {
            Console.WriteLine("Welcome");
            startProgram();
        }

        private static void startProgram()
        {
            bool run = true;
            do
            {
                // Start screen
                Console.WriteLine("");
                Console.WriteLine("Select option:");
                Console.WriteLine("1. Get all cars");
                Console.WriteLine("2. Get car by id");
                Console.WriteLine("3. Add a new car");
                Console.WriteLine("4. Edit existing car");
                Console.WriteLine("5. Delete car");
                Console.WriteLine("6. Exit");
                Console.WriteLine("-----Enter option number:----");
                string choice = Console.ReadLine();

                // Request Handling
                Handler handler = new Handler();
                if (int.TryParse(choice, out int result))
                {
                    switch (int.Parse(choice))
                    {
                        case 1:
                            getCars();
                            break;
                        case 2:
                            getCarById();
                            break;
                        case 3:
                            createCar();
                            break;
                        case 4:
                            editCar();
                            break;
                        case 5:
                            deleteCar();
                            break;
                        case 6:
                            run = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please choose a valid option!", Console.ForegroundColor);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                }
            } while (run);
        }

        private static void createCar()
        {
            Car newCar = new Car();
            ObservableCollection<CarBrand> brands = handler.GetAllBrands();
            ObservableCollection<CarModel> models = handler.GetAllModels();
            Console.WriteLine("\nSelect car brand:");
            foreach (CarBrand b in brands)
            {
                Console.WriteLine(b.ToCSV());
            }

            bool validBrandInput = false;
            do
            {
                Console.WriteLine("\nSelect car brand:");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }

                if (int.TryParse(input, out int o))
                {
                    foreach (CarBrand c in brands)
                    {
                        if (c.Id == int.Parse(input))
                        {
                            validBrandInput = true;
                            newCar.Brand = c;
                        }
                    }
                }
            } while (!validBrandInput);

            Console.WriteLine("\nSelect car model:");
            foreach (CarModel m in models)
            {
                if (m.Brand.Id == newCar.Brand.Id)
                {
                    Console.WriteLine(m.ToCSV());
                }
            }

            bool validModelInput = false;
            do
            {
                Console.WriteLine("\nSelect car model:");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (int.TryParse(input, out int o))
                {
                    foreach (CarModel m in models)
                    {
                        if (m.Id == int.Parse(input))
                        {
                            validModelInput = true;
                            newCar.Model = m;
                        }
                    }
                }
            } while (!validModelInput);

            bool validYearInput = false;
            do
            {
                Console.WriteLine("\nEnter production year (1950-2024):");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (int.TryParse(input, out int o))
                {
                    int year = int.Parse(input);
                    if (year > 1950 && year < 2024)
                    {
                        validYearInput = true;
                        newCar.Year = year;
                    }
                }
            } while (!validYearInput);

            bool validHorsePowerInput = false;
            do
            {
                Console.WriteLine("\nEnter horse power:");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (int.TryParse(input, out int o))
                {
                    int horsePower = int.Parse(input);
                    if (horsePower > 20)
                    {
                        validHorsePowerInput = true;
                        newCar.HorsePower = horsePower;
                    }
                }
            } while (!validHorsePowerInput);

            bool validPurchasePriceInput = false;
            do
            {
                Console.WriteLine("\nEnter purchase price:");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (decimal.TryParse(input, out decimal o))
                {
                    decimal purchasePrice = decimal.Parse(input);
                    if (purchasePrice >= 0)
                    {
                        validPurchasePriceInput = true;
                        newCar.PurchasePrice = purchasePrice;
                    }
                }
            } while (!validPurchasePriceInput);

            bool validPurchaseDateInput = false;
            do
            {
                Console.WriteLine("\nEnter purchase date(dd/MM/yyyy):");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (DateOnly.TryParseExact(input, "dd/MM/yyyy", out DateOnly o))
                {
                    DateOnly purchaseDate = DateOnly.ParseExact(input, "dd/MM/yyyy");
                    newCar.PurchaseDate = purchaseDate;
                    validPurchaseDateInput = true;
                }
            } while (!validPurchaseDateInput);


            bool validSalePriceInput = false;
            do
            {
                Console.WriteLine("\nEnter sale price:");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (decimal.TryParse(input, out decimal o))
                {
                    decimal salePriceInput = decimal.Parse(input);
                    if ((salePriceInput - newCar.PurchasePrice) >= (newCar.PurchasePrice * (decimal)0.25))
                    {
                        newCar.SalePrice = salePriceInput;
                        validSalePriceInput = true;
                    }
                }
            } while (!validSalePriceInput);
            newCar.Sold = false;

            bool validFuelTypeInput = false;
            do
            {
                int i = 1;
                Console.WriteLine("\nSelect fuel type:");
                foreach (FuelType f in FuelType.GetValues<FuelType>())
                {
                    Console.WriteLine($"{i}. {f}");
                    i += 1;
                }
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (int.TryParse(input, out int o))
                {
                    int fuelTypeInput = int.Parse(input);
                    if (fuelTypeInput > 0 && fuelTypeInput < 7)
                    {
                        newCar.FuelType = (FuelType)fuelTypeInput;
                        validFuelTypeInput = true;
                    }
                }
            } while (!validFuelTypeInput);

            handler.AddCar(newCar);
        }

        private static void getCarById()
        {
            Console.WriteLine("\nEnter car Id: ");
            string inputId = Console.ReadLine();
            int carId = 0;
            if (int.TryParse(inputId, out int a))
            {
                carId = int.Parse(inputId);
            }

            Car car = handler.GetCarById(carId);
            if (car == null)
            {
                Console.WriteLine("");
                Console.WriteLine("There is no car by the id " + carId);
                return;
            }
            Console.WriteLine(car.toDisplay());
        }

        private static void getCars()
        {
            ObservableCollection<Car> cars = handler.GetAllCars();
            Console.WriteLine("");
            Console.WriteLine("----- All cars -----");
            foreach (Car c in cars)
            {
                Console.WriteLine(c.toDisplay());
            }
        }

        private static void deleteCar()
        {
            ObservableCollection<Car> cars = handler.GetAllCars();
            Console.WriteLine("");
            Console.WriteLine("----- All cars -----");
            foreach (Car c in cars)
            {
                Console.WriteLine(c.toDisplay());
            }

            bool validIdInput = false;
            int carId = 0;
            do
            {
                Console.WriteLine("\nEnter car Id: ");
                string inputId = Console.ReadLine();
                if (int.TryParse(inputId, out int b))
                {
                    carId = int.Parse(inputId);
                    validIdInput = true;
                }
            } while (!validIdInput);

            Car car = handler.GetCarById(carId);
            if (car == null)
            {
                Console.WriteLine("");
                Console.WriteLine("There is no car by the id " + carId);
            }
            else
            {
                Console.WriteLine("Are you sure? (y/n)");
                string res = Console.ReadLine();
                if (res[0].ToString().ToLower() == "y")
                {
                    handler.DeleteCar(car.Id);
                } 
            }

        }

        private static void editCar()
        {
            ObservableCollection<Car> cars = handler.GetAllCars();
            Console.WriteLine("");
            Console.WriteLine("----- All cars -----");
            foreach (Car c in cars)
            {
                Console.WriteLine(c.toDisplay());
            }

            bool validIdInput = false;
            int carId = 0;
            do
            {
                Console.WriteLine("\nEnter car Id: ");
                string inputId = Console.ReadLine();
                if (int.TryParse(inputId, out int b))
                {
                    carId = int.Parse(inputId);
                    validIdInput = true;
                }
            } while (!validIdInput);

            Car car = handler.GetCarById(carId);
            if (car == null)
            {
                Console.WriteLine("");
                Console.WriteLine("There is no car by the id " + carId);
                return;
            }
            
            Console.WriteLine("-----Select property for change-----");
            Console.WriteLine("1. Year of production");
            Console.WriteLine("2. Horse power");
            Console.WriteLine("3. Stock status");
            Console.WriteLine("4. Purchase price");
            Console.WriteLine("5. Purchase date");
            Console.WriteLine("6. Sale price");
            Console.WriteLine("7. Change fuel type");

            bool validOptionInput = false;
            int selectedOption = 0;
            do
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    return;
                }
                if (int.TryParse(input, out int b))
                {
                    selectedOption = int.Parse(input);
                    validOptionInput = true;
                }

            } while (!validOptionInput);

            switch(selectedOption)
            {
                case 1:
                    bool validYearInput = false;
                    do
                    {
                        Console.WriteLine("\nEnter production year (1950-2024):");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "c")
                        {
                            return;
                        }
                        if (int.TryParse(input, out int o))
                        {
                            int year = int.Parse(input);
                            if (year > 1950 && year < 2024)
                            {
                                validYearInput = true;
                                car.Year = year;
                            }
                        }
                    } while (!validYearInput);
                    break;
                case 2:
                    bool validHorsePowerInput = false;
                    do
                    {
                        Console.WriteLine("\nEnter horse power:");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "c")
                        {
                            return;
                        }
                        if (int.TryParse(input, out int o))
                        {
                            int horsePower = int.Parse(input);
                            if (horsePower > 20)
                            {
                                validHorsePowerInput = true;
                                car.HorsePower = horsePower;
                            }
                        }
                    } while (!validHorsePowerInput);
                    break;
                case 3:
                    Console.WriteLine("Is this car sold? (y/n)");
                    string response = Console.ReadLine();
                    if (response[0].ToString().ToLower() == "y")
                    {
                        car.Sold = true;
                    } 
                    else
                    {
                        if (car.Sold != false)
                        {
                            car.Sold = false;
                        }
                    }
                    break;
                case 4:
                    bool validPurchasePriceInput = false;
                    do
                    {
                        Console.WriteLine("\nEnter purchase price:");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "c")
                        {
                            return;
                        }
                        if (decimal.TryParse(input, out decimal o))
                        {
                            decimal purchasePrice = decimal.Parse(input);
                            if (purchasePrice >= 0)
                            {
                                validPurchasePriceInput = true;
                                car.PurchasePrice = purchasePrice;
                            }
                        }
                    } while (!validPurchasePriceInput);
                    break;
                case 5:
                    bool validPurchaseDateInput = false;
                    do
                    {
                        Console.WriteLine("\nEnter purchase date(dd/MM/yyyy):");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "c")
                        {
                            return;
                        }
                        if (DateOnly.TryParseExact(input, "dd/MM/yyyy", out DateOnly o))
                        {
                            DateOnly purchaseDate = DateOnly.ParseExact(input, "dd/MM/yyyy");
                            car.PurchaseDate = purchaseDate;
                            validPurchaseDateInput = true;
                        }
                    } while (!validPurchaseDateInput);
                    break;
                case 6:
                    bool validSalePriceInput = false;
                    do
                    {
                        Console.WriteLine("\nEnter sale price:");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "c")
                        {
                            return;
                        }
                        if (decimal.TryParse(input, out decimal o))
                        {
                            decimal salePriceInput = decimal.Parse(input);
                            if ((salePriceInput - car.PurchasePrice) >= (car.PurchasePrice * (decimal)0.25))
                            {
                                car.SalePrice = salePriceInput;
                                validSalePriceInput = true;
                            }
                        }
                    } while (!validSalePriceInput);
                    car.Sold = false;
                    break;
                case 7:
                    bool validFuelTypeInput = false;
                    do
                    {
                        int i = 1;
                        Console.WriteLine("\nSelect fuel type:");
                        foreach (FuelType f in FuelType.GetValues<FuelType>())
                        {
                            Console.WriteLine($"{i}. {f}");
                            i += 1;
                        }
                        var input = Console.ReadLine();
                        if (input.ToLower() == "c")
                        {
                            return;
                        }

                        if (int.TryParse(input, out int o))
                        {
                            int fuelTypeInput = int.Parse(input);
                            if (fuelTypeInput > 0 && fuelTypeInput < 7)
                            {
                                car.FuelType = (FuelType)fuelTypeInput;
                                validFuelTypeInput = true;
                            }
                        }
                    } while (!validFuelTypeInput);
                    break;
                default:
                    return;

                
            }
            handler.EditCar(car.Id, car);
        }
    }
}
