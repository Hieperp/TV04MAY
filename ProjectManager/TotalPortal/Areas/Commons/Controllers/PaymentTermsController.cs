using TotalModel.Models;

using TotalDTO.Commons;
using TotalCore.Services.Commons;

using TotalPortal.Controllers;
using TotalPortal.Areas.Commons.ViewModels;
using TotalPortal.Areas.Commons.Builders;


namespace TotalPortal.Areas.Commons.Controllers
{
    public class PaymentTermsController : GenericSimpleController<PaymentTerm, PaymentTermDTO, PaymentTermPrimitiveDTO, PaymentTermViewModel>
    {
        public PaymentTermsController(IPaymentTermService PaymentTermService, IPaymentTermViewModelSelectListBuilder PaymentTermViewModelSelectListBuilder)
            : base(PaymentTermService, PaymentTermViewModelSelectListBuilder)
        {
        }
    }
}

