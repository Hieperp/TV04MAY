using System;
using System.Web.Mvc;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalDTO.Purchases;
using TotalPortal.Builders;
using TotalPortal.ViewModels.Helpers;
using TotalPortal.Areas.Commons.ViewModels.Helpers;

namespace TotalPortal.Areas.Purchases.ViewModels
{
    public class PurchaseOrderViewModel : PurchaseOrderDTO, IViewDetailViewModel<PurchaseOrderDetailDTO>, IPreparedPersonDropDownViewModel, IApproverDropDownViewModel, IVerifierDropDownViewModel, IManagerDropDownViewModel, IPaymentTermDropDownViewModel, IA02SimpleViewModel //, IEmployeeAutoCompleteViewModel, IPromotionAutoCompleteViewModel, ICustomerAutoCompleteViewModel
    {
        public IEnumerable<SelectListItem> AspNetUserSelectList { get; set; }
        public IEnumerable<SelectListItem> PaymentTermSelectList { get; set; }
    }

}
