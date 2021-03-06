﻿using System;
using System.Web.Mvc;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalDTO.Sales;
using TotalPortal.Builders;
using TotalPortal.ViewModels.Helpers;
using TotalPortal.Areas.Commons.ViewModels.Helpers;

namespace TotalPortal.Areas.Sales.ViewModels
{
    public class DeliveryAdviceViewModel : DeliveryAdviceDTO, IViewDetailViewModel<DeliveryAdviceDetailDTO>, IPreparedPersonDropDownViewModel, IApproverDropDownViewModel, IPaymentTermDropDownViewModel, IA02SimpleViewModel //, IEmployeeAutoCompleteViewModel, IPromotionAutoCompleteViewModel, ICustomerAutoCompleteViewModel
    {
        public IEnumerable<SelectListItem> AspNetUserSelectList { get; set; }
        public IEnumerable<SelectListItem> PaymentTermSelectList { get; set; }
    }

}
