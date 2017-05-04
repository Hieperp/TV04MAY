using TotalCore.Repositories.Commons;

using TotalPortal.Builders;
using TotalPortal.Areas.Commons.Builders;
using TotalPortal.Areas.Commons.ViewModels;

namespace TotalPortal.Areas.Commons.Builders
{
    public interface IEmployeeViewModelSelectListBuilder : IViewModelSelectListBuilder<EmployeeViewModel>
    {
    }

    public class EmployeeViewModelSelectListBuilder : IEmployeeViewModelSelectListBuilder
    {
        public virtual void BuildSelectLists(EmployeeViewModel EmployeeViewModel)
        {
        }
    }

}