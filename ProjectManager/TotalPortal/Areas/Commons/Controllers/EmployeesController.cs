using TotalModel.Models;

using TotalDTO.Commons;
using TotalCore.Services.Commons;

using TotalPortal.Controllers;
using TotalPortal.Areas.Commons.ViewModels;
using TotalPortal.Areas.Commons.Builders;


namespace TotalPortal.Areas.Commons.Controllers
{
    public class EmployeesController : GenericSimpleController<Employee, EmployeeDTO, EmployeePrimitiveDTO, EmployeeViewModel>
    {
        public EmployeesController(IEmployeeService EmployeeService, IEmployeeViewModelSelectListBuilder EmployeeViewModelSelectListBuilder)
            : base(EmployeeService, EmployeeViewModelSelectListBuilder)
        {
        }
    }
}

