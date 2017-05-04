using System;
using System.ComponentModel.DataAnnotations;
using TotalBase.Enums;
using TotalModel;

namespace TotalDTO.Commons
{
    public interface IPaymentTermBaseDTO
    {
        int PaymentTermID { get; set; }
        [Display(Name = "PaymentTerm")]
        [Required(ErrorMessage = "Please select a payment term in order to conitune")]
        string Name { get; set; }        
    }
    public class PaymentTermBaseDTO : BaseDTO, IPaymentTermBaseDTO
    {
        public int PaymentTermID { get; set; }

        public string Name { get; set; }        
    }

    public class PaymentTermPrimitiveDTO : PaymentTermBaseDTO, IPrimitiveEntity, IPrimitiveDTO
    {
        public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.PaymentTerm; } }

        public int GetID() { return this.PaymentTermID; }
        public void SetID(int id) { this.PaymentTermID = id; }

        [Required]
        public int PaymentTermCategoryID { get { return 1; } set { } }

        public override int PreparedPersonID { get { return 1; } }
    }


    public class PaymentTermDTO : PaymentTermPrimitiveDTO
    {
    }
}
