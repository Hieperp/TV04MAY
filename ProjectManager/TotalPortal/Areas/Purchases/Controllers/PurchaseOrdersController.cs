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



    }

}