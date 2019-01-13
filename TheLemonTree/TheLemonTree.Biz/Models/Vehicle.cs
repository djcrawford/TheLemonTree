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
        public Vehicle(string vin)
        {
            this.VIN = vin;
            // Todo: Make this constructor have parameters for all additional properties that are added to this class
        }

        public override string ToString()
        {
            // Todo: Make this ToString make a string that you feel does a good job in displaying the vehicle details
            return VIN;
        }
    }
}
