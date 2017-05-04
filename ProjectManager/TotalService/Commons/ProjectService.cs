using TotalModel.Models;
using TotalDTO.Commons;
using TotalCore.Repositories.Commons;
using TotalCore.Services.Commons;

namespace TotalService.Commons
{
    public class ProjectService : GenericService<Project, ProjectDTO, ProjectPrimitiveDTO>, IProjectService
    {
        public ProjectService(IProjectRepository ProjectRepository)
            : base(ProjectRepository)
        {
        }

    }
}
