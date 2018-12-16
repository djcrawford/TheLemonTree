using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheLemonTree.Biz.Models;
using TheLemonTree.Biz.Repositories;
using TheLemonTree.Biz.Services;
using static TheLemonTree.Cmd.Extensions.Utilities;

namespace TheLemonTree.Cmd
{
    public class MaintainVehicles
    {
        VehicleRepository _vehicles;
        public MaintainVehicles()
        {
            _vehicles = new VehicleRepository(new VehicleFilePersistanceService());
        }

        public bool Run()
        {
            Console.Clear();
            Console.Title = "The Lemon Tree: Maintain Vehicles";

            switch (GetMenuSelection())
            {
                case 1:
                    AddANewVehicle();
                    break;
                case 2:
                    RemoveAVehicle();
                    break;
                case 3:
                    ViewAll();
                    break;
                case 4: return false;
            }
            return true;
        }

        private int GetMenuSelection()
        {
            var menuText =
                "\n" +
                "The Lemon Tree: Maintain Vehicles\n\n" +
                "" +
                "   Please select a task:\n" +
                "   1. Add a new Vehicle\n" +
                "   2. Remove an existing Vehicle\n" +
                "   3. View All of the Vehicles\n" +
                "   4. Exit\n";

            return AskUserForInt(menuText);
        }
        private void AddANewVehicle()
        {
            Vehicle vehicle = new Vehicle();

            vehicle.VIN = AskUser("What is the VIN number for the vehicle?");
            // Todo: fill out the rest after you add the other properties to vehicle            
            // example
            // vehicle.Make = AskUser("Who is the manufacturer for the vehicle?);

            _vehicles.Add(vehicle);
            TellUser("Vehicle was added");
        }
        private void RemoveAVehicle()
        {
            string displayText = "";
            foreach (var vehicle in _vehicles.GetAll())
            {
                displayText += $"{vehicle.Id} - {vehicle}\n";
            }
            displayText += "(-1) - Cancel\n";
            Console.WriteLine(displayText);
            int selection = AskUserForInt("Which vehicle would you like to remove?");

            if (selection == -1)
            {
                TellUser("The operation has been canceled");
                return;
            }

            _vehicles.Remove(selection);
            TellUser("The vehicle has been removed");
        }
        private void ViewAll()
        {
            string displayText = "";
            foreach (var vehicle in _vehicles.GetAll())
            {
                displayText += $"{vehicle.Id} - {vehicle}\n";
            }

            TellUser(displayText);
        }
    }
}
