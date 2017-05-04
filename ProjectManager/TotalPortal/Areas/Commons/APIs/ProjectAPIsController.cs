using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using TotalCore.Repositories.Commons;
using TotalModel.Models;
using TotalDTO.Commons;
using TotalPortal.APIs.Sessions;

using Microsoft.AspNet.Identity;

namespace TotalPortal.Areas.Commons.APIs
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ProjectAPIsController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IProjectAPIRepository projectAPIRepository;

        public ProjectAPIsController(IProjectRepository projectRepository, IProjectAPIRepository projectAPIRepository)
        {
            this.projectRepository = projectRepository;
            this.projectAPIRepository = projectAPIRepository;
        }


        public JsonResult GetProjectIndexes([DataSourceRequest] DataSourceRequest request)
        {
            ICollection<ProjectIndex> ProjectIndexes = this.projectAPIRepository.GetEntityIndexes<ProjectIndex>(User.Identity.GetUserId(), HomeSession.GetGlobalFromDate(this.HttpContext), HomeSession.GetGlobalToDate(this.HttpContext));

            DataSourceResult response = ProjectIndexes.ToDataSourceResult(request);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchProjects(string searchText)
        {
            var result = projectRepository.SearchProjects(searchText).Select(s => new { s.ProjectID, s.Code, s.Name, s.DueDate, s.ProjectAddress });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}