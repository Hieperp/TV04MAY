using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using TotalCore.Repositories.Commons;
using TotalModel.Models;
using TotalDTO.Commons;
using TotalPortal.APIs.Sessions;

using Microsoft.AspNet.Identity;

namespace TotalPortal.Areas.Commons.APIs
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class PaymentTermAPIsController : Controller
    {
        private readonly IPaymentTermAPIRepository paymentTermAPIRepository;

        public PaymentTermAPIsController(IPaymentTermAPIRepository paymentTermAPIRepository)
        {
            this.paymentTermAPIRepository = paymentTermAPIRepository;
        }


        public JsonResult GetPaymentTermIndexes([DataSourceRequest] DataSourceRequest request)
        {
            ICollection<PaymentTermIndex> PaymentTermIndexes = this.paymentTermAPIRepository.GetEntityIndexes<PaymentTermIndex>(User.Identity.GetUserId(), HomeSession.GetGlobalFromDate(this.HttpContext), HomeSession.GetGlobalToDate(this.HttpContext));

            DataSourceResult response = PaymentTermIndexes.ToDataSourceResult(request);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}