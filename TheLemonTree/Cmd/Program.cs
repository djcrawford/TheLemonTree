using System;
using System.Collections.Generic;

namespace Cmd
{
    class Program
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>();

        static void Main(string[] args)
        {
            while (true)
            {
                string year = AskUser("What is the Year of the vehicle you would like to add: ");
                string make = AskUser("What is the Make of the vehicle you would like to add: ");
                string model = AskUser("What is the Model of the vehicle you would like to add: ");

                Vehicle vehicle = new Vehicle(int.Parse(year),make,model);

                Vehicles.Add(vehicle);

                for (int i = 0; i < Vehicles.Count; i++)
                {
                    Console.WriteLine(Vehicles[i].VehicleToString());
                }
                AskUser("Press Enter to Continue...");

                Console.Clear();
            }
        }

        public static string AskUser(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }


        public class Vehicle
        {
            public int Year;
            public string Make;
            public string Model;
            public string Status;

            public Vehicle(int year, string make, string model)
            {
                Year = year;
                Make = make;
                Model = model;
                Status = WorkStatuses.Waiting;
            }

            public string VehicleToString()
            {
                return $"[{Year}] {Make} {Model}";
            }

            public static Vehicle ChangeMake(Vehicle vehicle, string make)
            {
                vehicle.Make = make;
                return vehicle;
            }
        }

        public static class WorkStatuses
        {
            public static string Waiting = "Waiting";
            public static string InProgress = "In Progress";
            public static string Done = "Done";
        }
    }
}
