using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Purchases;



namespace TotalDAL.Repositories.Purchases
{
    public class PurchaseOrderRepository : GenericWithDetailRepository<PurchaseOrder, PurchaseOrderDetail>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ProjectManagerEntities totalSalesPortalEntities)
            : base(totalSalesPortalEntities, "PurchaseOrderEditable", "PurchaseOrderApproved", null, "PurchaseOrderVoidable")
        {
        }
    }








    public class PurchaseOrderAPIRepository : GenericAPIRepository, IPurchaseOrderAPIRepository
    {
        public PurchaseOrderAPIRepository(ProjectManagerEntities totalSalesPortalEntities)
            : base(totalSalesPortalEntities, "GetPurchaseOrderIndexes")
        {
        }
    }


}
