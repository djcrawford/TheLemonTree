using System;
using System.Collections.Generic;
using System.Text;

namespace TheLemonTree.Biz.Models
{
    public class Vehicle : IEntity<Vehicle, int>
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        
        // Todo: Add other properties

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vehicle()
        {
            VIN = "No VIN provided";
        }

        /// <summary>
        /// All Args Constructor
        /// </summary>
        public Vehicle(int id, string vin, string model, string make, string year)
        {
            this.VIN = vin;
            // Todo: Make this constructor have parameters for all additional properties that are added to this class
        }

        public override string ToString()
        {
            // Todo: Make this ToString make a string that you feel does a good job in displaying the vehicle details
            string toStr = "Vehicle Identification Number: " + VIN + "\n" +
                    "Make: " + Make + "\n" +
                    "Model: " + Model + "\n" +
                    "Year: " + Year + "\n" +
                    "Id: " + Id;

            return VIN;
        }
    }
}
