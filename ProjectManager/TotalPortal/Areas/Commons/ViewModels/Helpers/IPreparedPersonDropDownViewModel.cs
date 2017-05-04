using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TotalPortal.Areas.Commons.ViewModels.Helpers
{
    public interface IPreparedPersonDropDownViewModel
    {
        [Display(Name = "Prepared by")]
        int PreparedPersonID { get; set; }
        IEnumerable<SelectListItem> AspNetUserSelectList { get; set; }
    }
}