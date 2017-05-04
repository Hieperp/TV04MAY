using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface IPaymentTermRepository : IGenericRepository<PaymentTerm>
    {
        IList<PaymentTerm> GetAllPaymentTerms();
    }

    public interface IPaymentTermAPIRepository : IGenericAPIRepository
    {
    }

}
