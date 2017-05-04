using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Commons;

namespace TotalDAL.Repositories.Commons
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManagerEntities totalSalesPortalEntities)
            : base(totalSalesPortalEntities, "ProjectEditable")
        {
        }

        public IList<Project> SearchProjects(string searchText)
        {
            this.TotalSalesPortalEntities.Configuration.ProxyCreationEnabled = false;
            List<Project> projects = this.TotalSalesPortalEntities.Projects.Where(w => (w.Code.Contains(searchText) || w.Name.Contains(searchText))).OrderByDescending(or => or.Name).Take(20).ToList();
            this.TotalSalesPortalEntities.Configuration.ProxyCreationEnabled = true;

            return projects;
        }
    }


    public class ProjectAPIRepository : GenericAPIRepository, IProjectAPIRepository
    {
        public ProjectAPIRepository(ProjectManagerEntities totalSalesPortalEntities)
            : base(totalSalesPortalEntities, "GetProjectIndexes")
        {
        }
    }

}