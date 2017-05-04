using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalModel.Helpers;
using TotalDTO.Helpers;

namespace TotalDTO.Purchases
{
    public class PurchaseOrderDetailDTO : VATAmountDetailDTO, IPrimitiveEntity, IHelperCommodityID, IHelperCommodityTypeID
    {
        public int GetID() { return this.PurchaseOrderDetailID; }

        public int PurchaseOrderDetailID { get; set; }
        public int PurchaseOrderID { get; set; }

        public int SupplierID { get; set; }
        public int ProjectID { get; set; }
        public int SalespersonID { get; set; }

        [UIHint("Decimal")]
        [Display(Name = "Rate")]
        public override decimal UnitPrice { get; set; }
        [Display(Name = "Net Cost")]
        public override decimal Amount  { get; set; }
        [Display(Name = "% VAT")]
        public override decimal VATPercent { get; set; }
        [Display(Name = "Gross Amount")]
        public override decimal GrossAmount { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please input item category")]
        public string RowCategory { get; set; }
        [Display(Name = "Item")]
        [Required(ErrorMessage = "Please input item description")]
        public string RowDescription { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please input item specification")]
        public string RowSpecification { get; set; }
        [Display(Name = "Unit")]
        [Required(ErrorMessage = "Please input item category")]
        public string RowUnit { get; set; }
        [Display(Name = "Request #")]
        [Required(ErrorMessage = "Please input Unit")]
        public string RequestNo { get; set; }
        [Display(Name = "Job Type")]
        [Required(ErrorMessage = "Please input job type")]
        public string JobType { get; set; }
        [Display(Name = "Job #")]
        [Required(ErrorMessage = "Please input job no")]
        public string JobNo { get; set; }
        [Display(Name = "Section #")]
        public string CodeSection { get; set; }
        [Display(Name = "Item #")]
        public string CodeItem { get; set; }
    }
}
