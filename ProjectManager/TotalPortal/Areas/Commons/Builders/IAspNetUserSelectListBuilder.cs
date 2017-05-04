using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using TotalModel.Models;

namespace TotalPortal.Areas.Commons.Builders
{
    public interface IAspNetUserSelectListBuilder
    {
        IEnumerable<SelectListItem> BuildSelectListItemsForAspNetUsers(IEnumerable<AspNetUser> aspNetUsers, int userID);
    }

    public class AspNetUserSelectListBuilder : IAspNetUserSelectListBuilder
    {
        public IEnumerable<SelectListItem> BuildSelectListItemsForAspNetUsers(IEnumerable<AspNetUser> aspNetUsers, int userID)
        {
            return aspNetUsers.OrderBy(od => od.UserID == userID ? 1 : 2).Select(pt => new SelectListItem { Text = pt.FirstName + " " + pt.LastName, Value = pt.UserID.ToString(), Group = new SelectListGroup { Name = (pt.AspNetGroup == null? "": pt.AspNetGroup.Name) } }).ToList(); //Text = pt.LastName + ' ' + pt.FirstName
        }
    }
}
