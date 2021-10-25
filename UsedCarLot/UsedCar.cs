using System;
using System.Collections.Generic;
using System.Text;

namespace UsedCarLot
{
    class UsedCar: Car
    {
        public double Mileage { get; set; }

        public UsedCar(string Make, string Model, int Year, decimal Price, double Mileage) : base(Make,Model,Year,Price)
        {
            this.Mileage = Mileage;
        }
        public override string ToString()
        {
            return $"Used {Year} - {Make} {Model} \n${Price.ToString("0.00")}\n{Mileage.ToString("0.00")} miles";
        }
    }
}
