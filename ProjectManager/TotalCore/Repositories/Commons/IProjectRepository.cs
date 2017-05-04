using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        IList<Project> SearchProjects(string searchText);
    }

    public interface IProjectAPIRepository : IGenericAPIRepository
    {
    }

}