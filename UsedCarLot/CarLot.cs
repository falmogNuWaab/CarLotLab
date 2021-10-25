using System;
using System.Collections.Generic;
using System.Text;

namespace UsedCarLot
{
    class CarLot
    {
        public List<Car> Inventory { get; set; } = new List<Car>();

        public CarLot()
        {
            Inventory.Add(new Car());
            Inventory.Add(new Car("Pontiac","Firebird Formula 400",1970, 9.99m));
            Inventory.Add(new Car());
            Inventory.Add(new Car("Ford","Focus",2020,14000));
            Inventory.Add(new UsedCar("Dodge", "PowerWagon", 1953, 25000, 100000));
            Inventory.Add(new UsedCar("Mercedes", "Bongo truck", 1999, 250.32m, 3000));
            Inventory.Add(new UsedCar("Lincoln", "Batmobile", 1966, 198, 90000));
            Inventory.Add(new UsedCar("BAE Systems", "Paladin", 2004, 155, 7000));
        }

        public void ShowCarListings()
        {
            for(int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine((i+1) + ":" + Inventory[i]);
                Console.WriteLine();
            }
        }
        public void RemoveCarFromInventory(Car carToRemove)
        {
            Inventory.Remove(carToRemove);
        }
        public Car FindCarInInventory(string searchString)
        {
            for(int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].Make.Contains(searchString) || Inventory[i].Model.Contains(searchString))
                {
                    return Inventory[i];
                }
            }
            Console.WriteLine("Car not found");
            return null;
        }
        public Car FindCarInInventory(int searchIndex)
        {
            searchIndex = searchIndex - 1;
            return Inventory[searchIndex];
        }
        public void AddCarToInventory()
        {
            bool validateMeBaby = true;
            bool isNew = true;
            while (validateMeBaby)
            {
                Console.Write("Is this vehicle new or used?");
                string response = Console.ReadLine().Trim().ToLower();
                if (response == "used")
                {
                    isNew = false;
                    break;
                }
                else if (response == "new")
                {
                    isNew = true;
                    break;
                }
                else
                {
                    Console.WriteLine("I didn't understand that, please respond with 'new' or 'used'.");
                }
            }
            Console.WriteLine("Please enter the following information to add a vehicle to Inventory: ");
            Console.Write("Make:");
            string make = Console.ReadLine().Trim();
            
            Console.Write("Model:");
            string model = Console.ReadLine().Trim();
           
            int yearInt = 1971;
            while (validateMeBaby)
            {
                Console.Write("Year:");
                if(int.TryParse(Console.ReadLine().Trim(), out int result))
                {
                    yearInt = result;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid number, please try again");
                }
            }

            decimal priceDecimal = 0.99m;
            while (validateMeBaby)
            {
                Console.Write("Price:");
                if(decimal.TryParse(Console.ReadLine(), out decimal tempPrice))
                {
                    priceDecimal = tempPrice;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid number, please try again");
                }
            }

            double mileage = 0.00;
            if (isNew)
            {
                Inventory.Add(new Car(make, model, yearInt, priceDecimal));
            }
            else
            {
                while (validateMeBaby)
                {
                    Console.Write("Current Mileage:");
                    if (double.TryParse(Console.ReadLine(), out double result))
                    {
                        mileage = result;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid number");
                    }
                }
                Inventory.Add(new UsedCar(make, model, yearInt, priceDecimal, mileage));
            }
            
        }

    }
}
