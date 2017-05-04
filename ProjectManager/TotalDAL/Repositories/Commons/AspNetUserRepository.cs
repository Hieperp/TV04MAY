using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Commons;

namespace TotalDAL.Repositories.Commons
{
    public class AspNetUserRepository : IAspNetUserRepository
    {
        private readonly ProjectManagerEntities totalSalesPortalEntities;

        public AspNetUserRepository(ProjectManagerEntities totalSalesPortalEntities)
        {
            this.totalSalesPortalEntities = totalSalesPortalEntities;
        }

        public IList<AspNetUser> GetAllAspNetUsers()
        {
            return this.totalSalesPortalEntities.AspNetUsers.ToList();
        }
    }
}
