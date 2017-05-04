using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using AutoMapper;

using TotalBase.Enums;
using TotalModel.Models;
using TotalDTO.Purchases;
using TotalCore.Repositories.Purchases;
using TotalCore.Repositories.Commons;
using TotalCore.Services.Purchases;

namespace TotalService.Purchases
{
    public class PurchaseOrderService : GenericWithViewDetailService<PurchaseOrder, PurchaseOrderDetail, PurchaseOrderViewDetail, PurchaseOrderDTO, PurchaseOrderPrimitiveDTO, PurchaseOrderDetailDTO>, IPurchaseOrderService
    {
        public PurchaseOrderService(IPurchaseOrderRepository PurchaseOrderRepository)
            : base(PurchaseOrderRepository, "PurchaseOrderPostSaveValidate", "PurchaseOrderSaveRelative", "PurchaseOrderToggleApproved", "PurchaseOrderToggleVoid", "PurchaseOrderToggleVoidDetail", "GetPurchaseOrderViewDetails")
        {
        }

        public override ICollection<PurchaseOrderViewDetail> GetViewDetails(int PurchaseOrderID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("PurchaseOrderID", PurchaseOrderID) };
            return this.GetViewDetails(parameters);
        }

        public override bool Save(PurchaseOrderDTO PurchaseOrderDTO)
        {
            PurchaseOrderDTO.PurchaseOrderViewDetails.RemoveAll(x => x.Quantity == 0);
            return base.Save(PurchaseOrderDTO);
        }
    }

}
