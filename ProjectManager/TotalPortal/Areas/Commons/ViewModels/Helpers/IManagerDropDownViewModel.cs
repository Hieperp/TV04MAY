using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TotalPortal.Areas.Commons.ViewModels.Helpers
{
    public interface IManagerDropDownViewModel
    {
        [Display(Name = "Authorized by")]
        int ManagerID { get; set; }
        IEnumerable<SelectListItem> AspNetUserSelectList { get; set; }
    }
}
