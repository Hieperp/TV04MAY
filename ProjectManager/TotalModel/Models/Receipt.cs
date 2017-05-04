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
    using System.Collections.Generic;
    
    public partial class Receipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receipt()
        {
            this.ReceiptDetails = new HashSet<ReceiptDetail>();
        }
    
        public int ReceiptID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public Nullable<int> GoodsIssueID { get; set; }
        public int CustomerID { get; set; }
        public int CashierID { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public int ApproverID { get; set; }
        public decimal TotalReceiptAmount { get; set; }
        public decimal TotalCashDiscount { get; set; }
        public decimal TotalFluctuationAmount { get; set; }
        public decimal TotalDepositAmount { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public bool InActive { get; set; }
        public bool InActivePartial { get; set; }
        public Nullable<System.DateTime> InActiveDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual GoodsIssue GoodsIssue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
        public virtual Employee Employee { get; set; }
    }
}