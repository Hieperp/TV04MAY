//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotalModel.Models
{
    using System;
    
    public partial class PurchaseOrderIndex
    {
        public int PurchaseOrderID { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string PoNumber { get; set; }
        public string Description { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public bool Approved { get; set; }
        public string ProjectName { get; set; }
        public System.DateTime DueDate { get; set; }
        public string SupplierName { get; set; }
        public string PaymentTermName { get; set; }
        public string SalespersonName { get; set; }
        public string ProjectCode { get; set; }
        public string ApprovedText { get; set; }
        public string VoidTypeName { get; set; }
    }
}
