using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TotalBase.Enums;

namespace TotalDTO.Helpers
{
    public interface IAmountDetailDTO : IQuantityDetailDTO
    {
        int CalculatingTypeID { get; set; }

        decimal UnitPrice { get; set; }
        decimal Amount { get; set; }
    }

    public abstract class RootAmountDetailDTO : QuantityDetailDTO
    {
        [Display(Name = "Giá bán")]
        public virtual decimal UnitPrice { get; set; }
    }

    public abstract class AmountDetailDTO : RootAmountDetailDTO, IAmountDetailDTO
    {
        public int CalculatingTypeID { get; set; }

        [UIHint("DecimalWithMinus")]
        public override decimal Quantity { get; set; }

        //[UIHint("DecimalReadonly")] //[UIHint("Decimal")]
        public override decimal UnitPrice { get; set; }

        [Display(Name = "Thành tiền")]
        [UIHint("DecimalReadonly")]
        public virtual decimal Amount { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext)) { yield return result; }

            if (Math.Round(this.Quantity * this.UnitPrice, GlobalEnums.rndAmount, MidpointRounding.AwayFromZero) != this.Amount) yield return new ValidationResult("Lỗi thành tiền", new[] { "Amount" });
        }
    }
}
