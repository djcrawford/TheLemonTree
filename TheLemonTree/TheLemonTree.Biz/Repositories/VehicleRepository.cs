using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheLemonTree.Biz.Models;
using TheLemonTree.Biz.Services;

namespace TheLemonTree.Biz.Repositories
{
    public class VehicleRepository : IRepository<Vehicle,int>
    {
        IPersistanceService<Vehicle,int> _storage;

        public VehicleRepository(IPersistanceService<Vehicle, int> storage)
        {
            _storage = storage;
        }

        public void Add(Vehicle vehicle)
        {
            _storage.Create(vehicle);
        }
        public void Remove(int id)
        {
            _storage.Delete(id);
        }
        public IEnumerable<Vehicle> GetAll()
        {
            return _storage.ReadAll();
        }
    }
}
