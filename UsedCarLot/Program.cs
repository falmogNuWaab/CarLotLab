using System;

namespace UsedCarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            bool looper = true;
            Console.WriteLine("Welcome to Jimmy's Used Car Lot!");
            Console.WriteLine("Guaranteed to present you with an Offer you cannot refuse!");
            
            CarLot jimmyJamesLot = new CarLot();
            while (looper)
            {
                Console.WriteLine("Please select an option from the menu to continue: ");
                Console.WriteLine("[1] Buy a Car\n[2] Sell a Car");
                Console.Write("Selection:");
                string response = Console.ReadLine();
                if(response == "1" || int.Parse(response) == 1)
                {
                    jimmyJamesLot.ShowCarListings();
                    string chooseACar = GetUserInput("Selection:");
                    Car CarToBuy = new Car();
                    if (int.TryParse(chooseACar,out int result))
                    {
                        CarToBuy = jimmyJamesLot.FindCarInInventory(result);                        
                    }
                    else
                    {
                        CarToBuy = jimmyJamesLot.FindCarInInventory(chooseACar);                        
                    }

                    string areYouBuyingThisCar = GetUserInput($"Would you like to purchase {CarToBuy.Make} {CarToBuy.Model}?(y/n)");
                    areYouBuyingThisCar = areYouBuyingThisCar.Trim().ToLower();
                    if(areYouBuyingThisCar == "y")
                    {
                        Console.WriteLine("Congratulations on your purchase!\n" + CarToBuy);
                        jimmyJamesLot.RemoveCarFromInventory(CarToBuy);
                    }                
                                                       
                } 
                else if(response == "2" || int.Parse(response) == 2)
                {
                    Console.WriteLine("Thanks for the new inventory!");
                    jimmyJamesLot.AddCarToInventory();
                    Console.WriteLine("Added to inventory: ");
                    Console.WriteLine(jimmyJamesLot.Inventory[jimmyJamesLot.Inventory.Count-1]);
                }
                looper = KeepLooping();
            }


        }
        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string response = Console.ReadLine();
            return response;
        }

        public static bool KeepLooping()
        {
            string response = GetUserInput("Would you like to continue?(y/n)");
            response = response.Trim().ToLower();
            if(response == "y")
            {
                return true;
            }
            else if (response == "n")
            {
                return false;
            } else
            {
                Console.WriteLine("I didn't understand that.");
                return KeepLooping();
            }
        }
    }
}
