using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Commons;


namespace TotalDAL.Repositories.Commons
{
    public class PaymentTermRepository : GenericRepository<PaymentTerm>, IPaymentTermRepository
    {
        private readonly ProjectManagerEntities totalSalesPortalEntities;

        public PaymentTermRepository(ProjectManagerEntities totalSalesPortalEntities)
            : base(totalSalesPortalEntities, "PaymentTermEditable")
        {
            this.totalSalesPortalEntities = totalSalesPortalEntities;
        }

        public IList<PaymentTerm> GetAllPaymentTerms()
        {
            return this.totalSalesPortalEntities.PaymentTerms.ToList();
        }
    }


    public class PaymentTermAPIRepository : GenericAPIRepository, IPaymentTermAPIRepository
    {
        public PaymentTermAPIRepository(ProjectManagerEntities totalSalesPortalEntities)
            : base(totalSalesPortalEntities, "GetPaymentTermIndexes")
        {
        }
    }

}

