using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalBase.Enums;
using TotalDTO.Helpers;
using TotalDTO.Commons;
using TotalDTO.Helpers.Interfaces;


namespace TotalDTO.Purchases
{
    public class PurchaseOrderPrimitiveDTO : VATAmountDTO<PurchaseOrderDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public virtual GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.PurchaseOrder; } }

        public int GetID() { return this.PurchaseOrderID; }
        public void SetID(int id) { this.PurchaseOrderID = id; }

        public int PurchaseOrderID { get; set; }

        [Display(Name = "P.O number")]
        //[Required(ErrorMessage = "Please input P.O number")]
        public string PoNumber { get; set; }

        public virtual int SupplierID { get; set; }
        public virtual int ProjectID { get; set; }

        [Display(Name = "Attention")]
        [Required(ErrorMessage = "Please input name of attention")]
        public string AttentionName { get; set; }
        [Display(Name = "Receiver")]
        [Required(ErrorMessage = "Please input name of receiver")]
        public string Receiver { get; set; }

        [Display(Name = "Payment terms")]
        public int PaymentTermID { get; set; }

        [Display(Name = "Date to be deliveried")]
        [Required(ErrorMessage = "Please input delivery date")]
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public virtual Nullable<System.DateTime> DueDate { get; set; }

        [Display(Name = "Delivery address")]
        [Required(ErrorMessage = "Please input delivery address")]
        [UIHint("Commons/ShippingAddress")]
        public string ShippingAddress { get; set; }

        public virtual int SalespersonID { get; set; }
        public virtual int ControlPersonID { get; set; }
        public virtual int AuthorizedPersonID { get; set; }

        [Display(Name = "Authorized by")]
        public int ManagerID { get; set; }

        [Display(Name = "Verified by")]
        public int VerifierID { get; set; }

        [Display(Name = "Description")]
        public override string Description { get; set; }
        [Display(Name = "Remarks")]
        public override string Remarks { get; set; }


        public override void PerformPresaveRule()
        {
            //this.Approved = true; this.ApprovedDate = this.EntryDate; //At PurchaseOrder, Use this to Approve right after save. Surely, It can be UnApprove later for editing
            this.DtoDetails().ToList().ForEach(e => { e.SupplierID = this.SupplierID; e.ProjectID = this.ProjectID; e.SalespersonID = this.SalespersonID; });
            base.PerformPresaveRule();
        }
    }


    public class PurchaseOrderDTO : PurchaseOrderPrimitiveDTO, IBaseDetailEntity<PurchaseOrderDetailDTO>
    {
        public PurchaseOrderDTO()
        {
            //At TUEVIET, there is no function for Salesperson, ControlPerson, AuthorizedPerson => So we set FIXED VALUE for it. NEVER CHANGE
            this.Salesperson = new EmployeeBaseDTO() { EmployeeID = 1, Name = "FIXED NAME TO PASS OVER Required ATTRIBUTE OF EmployeeBaseDTO" };
            this.ControlPerson = new EmployeeBaseDTO() { EmployeeID = 1, Name = "FIXED NAME TO PASS OVER Required ATTRIBUTE OF EmployeeBaseDTO" };
            this.AuthorizedPerson = new EmployeeBaseDTO() { EmployeeID = 1, Name = "FIXED NAME TO PASS OVER Required ATTRIBUTE OF EmployeeBaseDTO" };


            this.PurchaseOrderViewDetails = new List<PurchaseOrderDetailDTO>();
        }

        public override int SupplierID { get { return (this.Supplier != null ? this.Supplier.CustomerID : 0); } }
        [Display(Name = "Key 3 letters to search a supplier ...")]
        [UIHint("AutoCompletes/CustomerBase")]
        public CustomerBaseDTO Supplier { get; set; }

        public override int ProjectID { get { return (this.Project != null ? this.Project.ProjectID : 0); } }
        [UIHint("AutoCompletes/ProjectBase")]
        public ProjectBaseDTO Project { get; set; }

        public override int SalespersonID { get { return (this.Salesperson != null ? this.Salesperson.EmployeeID : 0); } }
        [Display(Name = "Prepared by")]
        [UIHint("AutoCompletes/EmployeeBase")]
        public EmployeeBaseDTO Salesperson { get; set; }

        public override int ControlPersonID { get { return (this.ControlPerson != null ? this.ControlPerson.EmployeeID : 0); } }
        [Display(Name = "Cost control")]
        [UIHint("AutoCompletes/EmployeeBase")]
        public EmployeeBaseDTO ControlPerson { get; set; }

        public override int AuthorizedPersonID { get { return (this.AuthorizedPerson != null ? this.AuthorizedPerson.EmployeeID : 0); } }
        [Display(Name = "Authorized by")]
        [UIHint("AutoCompletes/EmployeeBase")]
        public EmployeeBaseDTO AuthorizedPerson { get; set; }

        [Display(Name = "Estimated project completion date")]
        public override Nullable<System.DateTime> DueDate { get { return (this.Project != null ? this.Project.DueDate : null); } set { } }

        public List<PurchaseOrderDetailDTO> PurchaseOrderViewDetails { get; set; }
        public List<PurchaseOrderDetailDTO> ViewDetails { get { return this.PurchaseOrderViewDetails; } set { this.PurchaseOrderViewDetails = value; } }

        public ICollection<PurchaseOrderDetailDTO> GetDetails() { return this.PurchaseOrderViewDetails; }

        protected override IEnumerable<PurchaseOrderDetailDTO> DtoDetails() { return this.PurchaseOrderViewDetails; }


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext)) { yield return result; }

            if (this.DeliveryDate != null && this.DeliveryDate > this.DueDate) yield return new ValidationResult("Delivery date must be before due date", new[] { "PODeliveryDate" });
        }
    }


}
