using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TotalPortal.Areas.Commons.ViewModels.Helpers
{
    public interface IVerifierDropDownViewModel
    {
        [Display(Name = "Verified by")]
        int VerifierID { get; set; }
        IEnumerable<SelectListItem> AspNetUserSelectList { get; set; }
    }
}
