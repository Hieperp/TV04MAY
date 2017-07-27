using System.Net;
using System.Web.Mvc;
using System.Text;

using AutoMapper;
using RequireJsNet;

using TotalBase.Enums;

using TotalModel.Models;

using TotalCore.Services.Purchases;

using TotalDTO.Purchases;

using TotalPortal.Controllers;
using TotalPortal.Areas.Purchases.ViewModels;
using TotalPortal.Areas.Purchases.Builders;
using TotalPortal.ViewModels.Helpers;



namespace TotalPortal.Areas.Purchases.Controllers
{
    public class PurchaseOrdersController : GenericViewDetailController<PurchaseOrder, PurchaseOrderDetail, PurchaseOrderViewDetail, PurchaseOrderDTO, PurchaseOrderPrimitiveDTO, PurchaseOrderDetailDTO, PurchaseOrderViewModel>
    {

        public PurchaseOrdersController(IPurchaseOrderService PurchaseOrderService, IPurchaseOrderViewModelSelectListBuilder PurchaseOrderViewModelSelectListBuilder)
            : base(PurchaseOrderService, PurchaseOrderViewModelSelectListBuilder, true)
        {
        }

        public override void AddRequireJsOptions()
        {
            base.AddRequireJsOptions();

            StringBuilder commodityTypeIDList = new StringBuilder();
            commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Parts);
            commodityTypeIDList.Append(","); commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Consumables);

            RequireJsOptions.Add("commodityTypeIDList", commodityTypeIDList.ToString(), RequireJsOptionsScope.Page);
        }


        protected override PrintViewModel InitPrintViewModel(int? id)
        {
            PrintViewModel printViewModel = base.InitPrintViewModel(id);
            printViewModel.ReportPath = "/ProjectManagers/PurchaseOrderSheet";
            return printViewModel;
        }


        [OnResultExecutingFilterAttribute]
        public ActionResult Print1Page(int? id)
        {
            PrintViewModel printViewModel = base.InitPrintViewModel(id);
            printViewModel.ReportPath = "/ProjectManagers/PurchaseOrderSheet1Page";
            return View("Print", printViewModel);
        }

    }

}