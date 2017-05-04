using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;
using System.Web.UI;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Purchases;

using TotalCore.Repositories.Purchases;
using TotalPortal.Areas.Purchases.ViewModels;
using TotalPortal.APIs.Sessions;

using Microsoft.AspNet.Identity;

namespace TotalPortal.Areas.Purchases.APIs
{
    public class PurchaseOrderAPIsController : Controller
    {
        private readonly IPurchaseOrderAPIRepository PurchaseOrderAPIRepository;

        public PurchaseOrderAPIsController(IPurchaseOrderAPIRepository PurchaseOrderAPIRepository)
        {
            this.PurchaseOrderAPIRepository = PurchaseOrderAPIRepository;
        }


        public JsonResult GetPurchaseOrderIndexes([DataSourceRequest] DataSourceRequest request)
        {
            ICollection<PurchaseOrderIndex> PurchaseOrderIndexes = this.PurchaseOrderAPIRepository.GetEntityIndexes<PurchaseOrderIndex>(User.Identity.GetUserId(), HomeSession.GetGlobalFromDate(this.HttpContext), HomeSession.GetGlobalToDate(this.HttpContext));

            DataSourceResult response = PurchaseOrderIndexes.ToDataSourceResult(request);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
