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
        [Display(Name = "Estimated completion date")]
        Nullable<System.DateTime> DueDate { get; set; }
    }
    public class ProjectBaseDTO : BaseDTO, IProjectBaseDTO
    {
        public int ProjectID { get; set; }

        [Display(Name = "Commencement date")]
        [Required(ErrorMessage = "Please input commencement date")]
        public override DateTime? EntryDate { get; set; }

        [Display(Name = "Project name")]
        [Required(ErrorMessage = "Please input project name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please input project address")]
        public string ProjectAddress { get; set; }

        [Display(Name = "Estimated completion date")]
        [Required(ErrorMessage = "Please input estimated completion date")]
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
