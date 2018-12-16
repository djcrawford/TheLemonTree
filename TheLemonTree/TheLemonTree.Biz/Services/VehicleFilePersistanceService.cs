using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using TheLemonTree.Biz.Models;
using System.Linq;

namespace TheLemonTree.Biz.Services
{
    public class VehicleFilePersistanceService : IPersistanceService<Vehicle, int>
    {
        private string _filepath = (Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "vehicleStorage.json"));

        /// <summary>
        /// Persists Vehicle Info in a JSON file
        /// </summary>
        public VehicleFilePersistanceService() { }

        /// <summary>
        /// Persists Vehicle Info in a JSON file
        /// </summary>
        /// <param name="filepath">the full path for where the info will be saved</param>
        public VehicleFilePersistanceService(string filepath)
        {
            _filepath = filepath;
        }

        #region IPersistanceService Methods

        public Vehicle Create(Vehicle item)
        {
            var vehicles = GetFromFile() ?? new List<Vehicle>();
            vehicles.Add(item);

            // Start the key with the length of the array
            var cantidateKey = vehicles.IndexOf(item);
            // As long as a vehicle in the list already is using that key then increment
            while(vehicles.FirstOrDefault(v => v.Id == cantidateKey) != null)
            {
                cantidateKey++;
            }
            item.Id = cantidateKey;

            Save(vehicles);
            return item;
        }

        public Vehicle Read(int key)
        {
            var vehicle = GetFromFile().AsQueryable().FirstOrDefault(v => v.Id == key);
            return vehicle;
        }

        public IEnumerable<Vehicle> ReadAll()
        {
            var vehicles = GetFromFile() ?? new List<Vehicle>();
            return vehicles;
        }

        public void Update(Vehicle item)
        {
            var vehicles = GetFromFile();
            var vehicle = vehicles.FirstOrDefault(v => v.Id == item.Id) ?? throw new KeyNotFoundException();
            vehicle = item;
            Save(vehicles);
        }

        public void Delete(int key)
        {
            var vehicles = GetFromFile();
            vehicles.RemoveAll(v => v.Id == key);
            Save(vehicles);
        }
        #endregion

        #region Helper Methods

        private bool Save(IEnumerable<Vehicle> obj)
        {
            bool success;
            try
            {
                string objAsJson = JsonConvert.SerializeObject(obj);
                File.WriteAllText(_filepath, objAsJson);
                success = true;
            }
            catch (IOException)
            {
                success = false;
            }

            return success;
        }

        private List<Vehicle> GetFromFile()
        {
            try
            {
                string objAsJson = File.ReadAllText(_filepath);
                List<Vehicle> obj = JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(objAsJson).ToList();
                return obj;
            }
            catch (IOException)
            {
                return null;
            }
        }

        #endregion
    }
}
