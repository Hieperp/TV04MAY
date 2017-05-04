using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class PaymentTerm
    {
        private readonly ProjectManagerEntities projectManagerEntities;

        public PaymentTerm(ProjectManagerEntities projectManagerEntities)
        {
            this.projectManagerEntities = projectManagerEntities;
        }

        public void RestoreProcedure()
        {
            this.GetPaymentTermIndexes();

            this.PaymentTermEditable();
        }


        private void GetPaymentTermIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      PaymentTermID, Name, Remarks " + "\r\n";
            queryString = queryString + "       FROM        PaymentTerms " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.projectManagerEntities.CreateStoredProcedure("GetPaymentTermIndexes", queryString);
        }

        private void PaymentTermEditable()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = PaymentTermID FROM PaymentTerms WHERE @EntityID = 1"; //AT TUE VIET ONLY: Don't allow edit default payment term, because it is related to CustomerCategories

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = PaymentTermID FROM PaymentTerms WHERE PaymentTermID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = PaymentTermID FROM GoodsIssueDetails WHERE PaymentTermID = @EntityID ";

            this.projectManagerEntities.CreateProcedureToCheckExisting("PaymentTermEditable", queryArray);
        }

    }
}
