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
    
    public partial class GoodsIssueIndex
    {
        public int GoodsIssueID { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string Reference { get; set; }
        public string LocationCode { get; set; }
        public string CustomerName { get; set; }
        public string ReceiverDescription { get; set; }
        public string DeliveryAdviceReferences { get; set; }
        public decimal TotalQuantity { get; set; }
        public Nullable<decimal> TotalFreeQuantity { get; set; }
        public decimal TotalListedGrossAmount { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
    }
}
