using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalBase.Enums;

namespace TotalDTO.Commons
{
    public interface IEmployeeBaseDTO
    {
        int EmployeeID { get; set; }
        [Display(Name = "Staff name")]
        [Required(ErrorMessage = "Please select a person")]
        string Name { get; set; }        
    }
    public class EmployeeBaseDTO : BaseDTO, IEmployeeBaseDTO
    {
        public int EmployeeID { get; set; }
        
        [Display(Name = "Staff name")]
        [Required(ErrorMessage = "Please input name")]
        public string Name { get ; set; }
    }

    public class EmployeePrimitiveDTO : EmployeeBaseDTO, IPrimitiveEntity, IPrimitiveDTO
    {
        public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.Employee; } }

        public int GetID() { return this.EmployeeID; }
        public void SetID(int id) { this.EmployeeID = id; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please input code")]
        public string Code { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please input title")]
        public string Title { get; set; }
        public string Birthday { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        [Required]
        public int EmployeeTypeID { get { return 1; } set { } }

        public override int PreparedPersonID { get { return 1; } }
    }


    public class EmployeeDTO : EmployeePrimitiveDTO
    {
    }

}
