using TotalCore.Repositories.Commons;

using TotalPortal.Builders;
using TotalPortal.Areas.Commons.Builders;
using TotalPortal.Areas.Commons.ViewModels;

namespace TotalPortal.Areas.Commons.Builders
{
    public interface IProjectViewModelSelectListBuilder : IViewModelSelectListBuilder<ProjectViewModel>
    {
    }

    public class ProjectViewModelSelectListBuilder : IProjectViewModelSelectListBuilder
    {
        public virtual void BuildSelectLists(ProjectViewModel ProjectViewModel)
        {
        }
    }

}