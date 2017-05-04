using TotalModel.Models;

using TotalDTO.Commons;
using TotalCore.Services.Commons;

using TotalPortal.Controllers;
using TotalPortal.Areas.Commons.ViewModels;
using TotalPortal.Areas.Commons.Builders;


namespace TotalPortal.Areas.Commons.Controllers
{
    public class ProjectsController : GenericSimpleController<Project, ProjectDTO, ProjectPrimitiveDTO, ProjectViewModel>
    {
        public ProjectsController(IProjectService ProjectService, IProjectViewModelSelectListBuilder ProjectViewModelSelectListBuilder)
            : base(ProjectService, ProjectViewModelSelectListBuilder)
        {
        }
    }
}

