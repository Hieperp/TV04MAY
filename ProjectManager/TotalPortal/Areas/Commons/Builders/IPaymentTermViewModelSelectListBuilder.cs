using TotalCore.Repositories.Commons;

using TotalPortal.Builders;
using TotalPortal.Areas.Commons.Builders;
using TotalPortal.Areas.Commons.ViewModels;

namespace TotalPortal.Areas.Commons.Builders
{
    public interface IPaymentTermViewModelSelectListBuilder : IViewModelSelectListBuilder<PaymentTermViewModel>
    {
    }

    public class PaymentTermViewModelSelectListBuilder : IPaymentTermViewModelSelectListBuilder
    {
        public virtual void BuildSelectLists(PaymentTermViewModel PaymentTermViewModel)
        {
        }
    }

}