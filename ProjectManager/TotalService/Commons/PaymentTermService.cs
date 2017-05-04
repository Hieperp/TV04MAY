using TotalModel.Models;
using TotalDTO.Commons;
using TotalCore.Repositories.Commons;
using TotalCore.Services.Commons;

namespace TotalService.Commons
{
    public class PaymentTermService : GenericService<PaymentTerm, PaymentTermDTO, PaymentTermPrimitiveDTO>, IPaymentTermService
    {
        public PaymentTermService(IPaymentTermRepository PaymentTermRepository)
            : base(PaymentTermRepository)
        {
        }

    }
}
