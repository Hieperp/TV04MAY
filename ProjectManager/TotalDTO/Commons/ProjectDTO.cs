using System;
using System.ComponentModel.DataAnnotations;
using TotalBase.Enums;
using TotalModel;

namespace TotalDTO.Commons
{
    public interface IProjectBaseDTO
    {
        int ProjectID { get; set; }
        [Display(Name = "Project")]
        [Required(ErrorMessage = "Please select a project in order to conitune")]
        string Name { get; set; }

        [Display(Name = "Address")]
        string ProjectAddress { get; set; }
        [Display(Name = "Project deadline")]
        Nullable<System.DateTime> DueDate { get; set; }
    }
    public class ProjectBaseDTO : BaseDTO, IProjectBaseDTO
    {
        public int ProjectID { get; set; }

        [Display(Name = "Project name")]
        [Required(ErrorMessage = "Please input project name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please input project address")]
        public string ProjectAddress { get; set; }
        
        [Display(Name = "Date to be deliveried")]
        [Required(ErrorMessage = "Please input delivery date")]
        public Nullable<System.DateTime> DueDate { get; set; }
    }

    public class ProjectPrimitiveDTO : ProjectBaseDTO, IPrimitiveEntity, IPrimitiveDTO
    {
        public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.Project; } }

        public int GetID() { return this.ProjectID; }
        public void SetID(int id) { this.ProjectID = id; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please input project code")]
        public string Code { get; set; }

        [Required]
        public int ProjectCategoryID { get { return 1; } set { } }

        public override int PreparedPersonID { get { return 1; } }
    }


    public class ProjectDTO : ProjectPrimitiveDTO
    {
    }
}
