using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Commons;

namespace TotalDAL.Repositories.Commons
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ProjectManagerEntities totalSalesPortalEntities;

        public VehicleRepository(ProjectManagerEntities totalSalesPortalEntities)
        {
            this.totalSalesPortalEntities = totalSalesPortalEntities;
        }

        public IList<Vehicle> GetAllVehicles()
        {
            return this.totalSalesPortalEntities.Vehicles.ToList();
        }
    }
}