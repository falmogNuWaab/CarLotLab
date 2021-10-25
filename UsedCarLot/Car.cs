using System;
using System.Collections.Generic;
using System.Text;

namespace UsedCarLot
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Car()
        {
            this.Make = "Toyota";
            this.Model = "Hilux";
            this.Year = 1997;
            this.Price = 999.99m;
        }
        public Car(string Make, string Model, int Year, decimal Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
        }
        public override string ToString()
        {
            string response = $"{Year} - {Make} {Model}\n";
            response += $"${Price.ToString("0.00")}";
            return response;
        }
    }
}
