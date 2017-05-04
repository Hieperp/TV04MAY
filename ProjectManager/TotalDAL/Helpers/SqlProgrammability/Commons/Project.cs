using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Project
    {
        private readonly ProjectManagerEntities projectManagerEntities;

        public Project(ProjectManagerEntities projectManagerEntities)
        {
            this.projectManagerEntities = projectManagerEntities;
        }

        public void RestoreProcedure()
        {
            this.GetProjectIndexes();

            this.ProjectEditable();
        }


        private void GetProjectIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      ProjectID, EntryDate, Code, Name, ProjectAddress, DueDate, Remarks " + "\r\n";
            queryString = queryString + "       FROM        Projects " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.projectManagerEntities.CreateStoredProcedure("GetProjectIndexes", queryString);
        }

        private void ProjectEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = ProjectID FROM Projects WHERE ProjectID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = ProjectID FROM GoodsIssueDetails WHERE ProjectID = @EntityID ";

            this.projectManagerEntities.CreateProcedureToCheckExisting("ProjectEditable", queryArray);
        }

    }
}
