using TotalModel.Models;
using TotalDTO.Purchases;
using TotalCore.Services.Helpers;

namespace TotalCore.Services.Purchases
{
    public interface IPurchaseOrderService : IGenericWithViewDetailService<PurchaseOrder, PurchaseOrderDetail, PurchaseOrderViewDetail, PurchaseOrderDTO, PurchaseOrderPrimitiveDTO, PurchaseOrderDetailDTO>
    {
    }
}
