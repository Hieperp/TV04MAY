using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Purchases
{
    public class PurchaseOrder
    {
        private readonly ProjectManagerEntities projectManagerEntities;

        public PurchaseOrder(ProjectManagerEntities projectManagerEntities)
        {
            this.projectManagerEntities = projectManagerEntities;
        }

        public void RestoreProcedure()
        {
            this.GetPurchaseOrderIndexes();

            this.GetPurchaseOrderViewDetails();
            this.PurchaseOrderSaveRelative();
            this.PurchaseOrderPostSaveValidate();

            this.PurchaseOrderApproved();
            this.PurchaseOrderEditable();
            this.PurchaseOrderVoidable();

            this.PurchaseOrderToggleApproved();
            this.PurchaseOrderToggleVoid();
            this.PurchaseOrderToggleVoidDetail();

            //this.PurchaseOrderInitReference(); //CHU Y: FOR EACH PROJECT
            this.PurchaseOrderSheet();
        }


        private void GetPurchaseOrderIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      PurchaseOrders.PurchaseOrderID, CAST(PurchaseOrders.EntryDate AS DATE) AS EntryDate, PurchaseOrders.PoNumber, Projects.Code AS ProjectCode, Projects.Name AS ProjectName, PurchaseOrders.DeliveryDate, Projects.DueDate, Suppliers.Name AS SupplierName, PaymentTerms.Name AS PaymentTermName, PurchaseOrders.TotalGrossAmount, Salespersons.Name AS SalespersonName, PurchaseOrders.Description, PurchaseOrders.Approved " + "\r\n";
            queryString = queryString + "       FROM        PurchaseOrders " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON PurchaseOrders.EntryDate >= @FromDate AND PurchaseOrders.EntryDate <= @ToDate AND PurchaseOrders.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.PurchaseOrder + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = PurchaseOrders.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers Suppliers ON PurchaseOrders.SupplierID = Suppliers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Projects ON PurchaseOrders.ProjectID = Projects.ProjectID " + "\r\n";
            queryString = queryString + "                   INNER JOIN PaymentTerms ON PurchaseOrders.PaymentTermID = PaymentTerms.PaymentTermID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Employees Salespersons ON PurchaseOrders.SalespersonID = Salespersons.EmployeeID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.projectManagerEntities.CreateStoredProcedure("GetPurchaseOrderIndexes", queryString);
        }



        private void GetPurchaseOrderViewDetails()
        {
            string queryString;
            SqlProgrammability.Inventories.Inventories inventories = new Inventories.Inventories(this.projectManagerEntities);

            queryString = " @PurchaseOrderID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      PurchaseOrderDetails.PurchaseOrderDetailID, PurchaseOrderDetails.PurchaseOrderID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, PurchaseOrderDetails.CommodityTypeID, PurchaseOrderDetails.CalculatingTypeID, PurchaseOrderDetails.RowCategory, PurchaseOrderDetails.RowDescription, PurchaseOrderDetails.RowSpecification, PurchaseOrderDetails.RowUnit, PurchaseOrderDetails.RequestNo, PurchaseOrderDetails.JobType, PurchaseOrderDetails.JobNo, PurchaseOrderDetails.CodeSection, PurchaseOrderDetails.CodeItem, " + "\r\n";
            queryString = queryString + "                   PurchaseOrderDetails.Quantity, PurchaseOrderDetails.UnitPrice, PurchaseOrderDetails.VATPercent, PurchaseOrderDetails.GrossPrice, PurchaseOrderDetails.Amount, PurchaseOrderDetails.VATAmount, PurchaseOrderDetails.GrossAmount, PurchaseOrderDetails.IsBonus, PurchaseOrderDetails.InActivePartial, PurchaseOrderDetails.InActivePartialDate, PurchaseOrderDetails.Remarks " + "\r\n";
            queryString = queryString + "       FROM        PurchaseOrderDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON PurchaseOrderDetails.PurchaseOrderID = @PurchaseOrderID AND PurchaseOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "       ORDER BY    PurchaseOrderDetails.RowCategory, PurchaseOrderDetails.PurchaseOrderDetailID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.projectManagerEntities.CreateStoredProcedure("GetPurchaseOrderViewDetails", queryString);
        }

        private void PurchaseOrderSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            //queryString = queryString + "       EXEC        PurchaseOrderUpdateQuotation @EntityID, @SaveRelativeOption " + "\r\n";

            //queryString = queryString + "       SET         @SaveRelativeOption = -@SaveRelativeOption" + "\r\n";
            //queryString = queryString + "       EXEC        UpdateWarehouseBalance @SaveRelativeOption, 0, @EntityID, 0, 0 ";

            this.projectManagerEntities.CreateStoredProcedure("PurchaseOrderSaveRelative", queryString);
        }

        private void PurchaseOrderPostSaveValidate()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = 'Service Date: ' + CAST(ServiceInvoices.EntryDate AS nvarchar) FROM PurchaseOrders INNER JOIN PurchaseOrders AS ServiceInvoices ON PurchaseOrders.PurchaseOrderID = @EntityID AND PurchaseOrders.ServiceInvoiceID = ServiceInvoices.PurchaseOrderID AND PurchaseOrders.EntryDate < ServiceInvoices.EntryDate ";

            this.projectManagerEntities.CreateProcedureToCheckExisting("PurchaseOrderPostSaveValidate", queryArray);
        }




        private void PurchaseOrderApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = PurchaseOrderID FROM PurchaseOrders WHERE PurchaseOrderID = @EntityID AND Approved = 1";

            this.projectManagerEntities.CreateProcedureToCheckExisting("PurchaseOrderApproved", queryArray);
        }


        private void PurchaseOrderEditable()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = PurchaseOrderID FROM PurchaseOrders WHERE PurchaseOrderID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = PurchaseOrderID FROM GoodsIssueDetails WHERE PurchaseOrderID = @EntityID ";

            this.projectManagerEntities.CreateProcedureToCheckExisting("PurchaseOrderEditable", queryArray);
        }

        private void PurchaseOrderVoidable()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = PurchaseOrderID FROM PurchaseOrders WHERE PurchaseOrderID = @EntityID AND Approved = 0"; //Must approve in order to allow void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = PurchaseOrderID FROM GoodsIssueDetails WHERE PurchaseOrderID = @EntityID ";

            this.projectManagerEntities.CreateProcedureToCheckExisting("PurchaseOrderVoidable", queryArray);
        }


        private void PurchaseOrderToggleApproved()
        {
            string queryString = " @EntityID int, @ApproverID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      PurchaseOrders  SET ApproverID = @ApproverID, Approved = @Approved, ApprovedDate = GetDate() WHERE PurchaseOrderID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           UPDATE          PurchaseOrderDetails  SET Approved = @Approved WHERE PurchaseOrderID = @EntityID ; " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.projectManagerEntities.CreateStoredProcedure("PurchaseOrderToggleApproved", queryString);
        }

        private void PurchaseOrderToggleVoid()
        {
            string queryString = " @EntityID int, @InActive bit, @VoidTypeID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      PurchaseOrders  SET InActive = @InActive, InActiveDate = GetDate(), VoidTypeID = IIF(@InActive = 1, @VoidTypeID, NULL) WHERE PurchaseOrderID = @EntityID AND InActive = ~@InActive" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           UPDATE          PurchaseOrderDetails  SET InActive = @InActive WHERE PurchaseOrderID = @EntityID ; " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@InActive = 0, 'phục hồi lệnh', '')  + ' hủy' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";


            this.projectManagerEntities.CreateStoredProcedure("PurchaseOrderToggleVoid", queryString);
        }

        private void PurchaseOrderToggleVoidDetail()
        {
            string queryString = " @EntityID int, @EntityDetailID int, @InActivePartial bit, @VoidTypeID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      PurchaseOrderDetails  SET InActivePartial = @InActivePartial, InActivePartialDate = GetDate(), VoidTypeID = IIF(@InActivePartial = 1, @VoidTypeID, NULL) WHERE PurchaseOrderID = @EntityID AND PurchaseOrderDetailID = @EntityDetailID AND InActivePartial = ~@InActivePartial ; " + "\r\n";
            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           UPDATE          PurchaseOrders  SET InActivePartial = (SELECT MAX(CAST(InActivePartial AS int)) FROM PurchaseOrderDetails WHERE PurchaseOrderID = @EntityID) WHERE PurchaseOrderID = @EntityID ; " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@InActivePartial = 0, 'phục hồi lệnh', '')  + ' hủy' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            this.projectManagerEntities.CreateStoredProcedure("PurchaseOrderToggleVoidDetail", queryString);
        }


        private void PurchaseOrderInitReference()
        {
            //            USE [ProjectManager]
            //GO
            ///****** Object:  Trigger [dbo].[PurchaseOrderInitReference]    Script Date: 04/05/2017 13:28:24 ******/
            //SET ANSI_NULLS ON
            //GO
            //SET QUOTED_IDENTIFIER ON
            //GO
            //ALTER TRIGGER [dbo].[PurchaseOrderInitReference]
            // ON [dbo].[PurchaseOrders] AFTER INSERT 
            // AS 
            //          DECLARE     @LocationID int         SET @LocationID = (SELECT LocationID FROM Inserted) 
            //   DECLARE     @EntityID int           SET @EntityID = (SELECT PurchaseOrderID FROM Inserted) 
            //   DECLARE     @EntryDate DateTime     SET @EntryDate = (SELECT EntryDate FROM Inserted) 

            //   DECLARE     @ProjectID int           SET @ProjectID = (SELECT PurchaseOrderID FROM Inserted) 

            //          DECLARE     @PrefixLetter varchar(10)   SET @PrefixLetter = 'D'

            //   DECLARE     @columnNameMax int 
            //   SET         @columnNameMax = (SELECT MAX(CAST( SUBSTRING(Reference, LEN(@PrefixLetter) + 1, CASE PATINDEX('%.%', Reference) WHEN 0 THEN LEN(Reference) - LEN(@PrefixLetter) ELSE PATINDEX('%.%', Reference) - 1 - LEN(@PrefixLetter) END) AS Int)) AS columnNameMax FROM PurchaseOrders  WHERE LocationID = @LocationID AND ProjectID = @ProjectID 
            //)    IF          @columnNameMax IS NULL SET @columnNameMax = 1 ELSE SET @columnNameMax = @columnNameMax + 1    UPDATE      PurchaseOrders
            //   SET         Reference = @PrefixLetter + RIGHT(CAST(100000000 + @columnNameMax as varchar), 6 - LEN(@PrefixLetter)) 
            //   WHERE       PurchaseOrderID = @EntityID 
            // UPDATE PurchaseOrders SET PoNumber = RIGHT(Reference, 5) WHERE PurchaseOrderID = @EntityID



            SimpleInitReference simpleInitReference = new SimpleInitReference("PurchaseOrders", "PurchaseOrderID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.PurchaseOrder));
            this.projectManagerEntities.CreateTrigger("PurchaseOrderInitReference", simpleInitReference.CreateQuery() + " UPDATE PurchaseOrders SET PoNumber = RIGHT(Reference, 5) WHERE PurchaseOrderID = @EntityID ");
        }


        private void PurchaseOrderSheet()
        {
            string queryString = " @PurchaseOrderID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE         @LocalPurchaseOrderID int    SET @LocalPurchaseOrderID = @PurchaseOrderID" + "\r\n";

            queryString = queryString + "       SELECT          PurchaseOrders.PurchaseOrderID, PurchaseOrders.EntryDate, PurchaseOrders.Reference, PurchaseOrders.PoNumber, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, Customers.BillingAddress, Customers.Telephone, Customers.Facsimile, PurchaseOrders.AttentionName, PurchaseOrders.Receiver, PurchaseOrders.ShippingAddress, PurchaseOrders.DeliveryDate, PurchaseOrders.Description, PaymentTerms.Name AS PaymentTermName, Projects.Code AS ProjectCode, Projects.Name AS ProjectName, " + "\r\n";
            queryString = queryString + "                       PurchaseOrderDetails.RowCategory, PurchaseOrderDetails.RowDescription, PurchaseOrderDetails.RowSpecification, PurchaseOrderDetails.RowUnit, PurchaseOrderDetails.RequestNo, PurchaseOrderDetails.JobType, PurchaseOrderDetails.JobNo, PurchaseOrderDetails.CodeSection, PurchaseOrderDetails.CodeItem, PurchaseOrderDetails.Quantity, PurchaseOrderDetails.UnitPrice, PurchaseOrderDetails.Amount, PurchaseOrderDetails.VATPercent, PurchaseOrderDetails.VATAmount, PurchaseOrderDetails.GrossAmount, " + "\r\n";
            queryString = queryString + "                       Salespersons.FirstName + ' ' + Salespersons.LastName AS SalespersonName, VerifierPersons.FirstName + ' ' + VerifierPersons.LastName AS VerifierPerson, ControlPersons.FirstName + ' ' + ControlPersons.LastName AS ControlPersonName, AuthorizedPersons.FirstName + ' ' + AuthorizedPersons.LastName AS AuthorizedPersonName " + "\r\n";

            queryString = queryString + "       FROM            PurchaseOrders " + "\r\n";
            queryString = queryString + "                       INNER JOIN Projects ON PurchaseOrders.PurchaseOrderID = @LocalPurchaseOrderID AND PurchaseOrders.ProjectID = Projects.ProjectID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON PurchaseOrders.SupplierID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                       INNER JOIN PaymentTerms ON PurchaseOrders.PaymentTermID = PaymentTerms.PaymentTermID " + "\r\n";
            queryString = queryString + "                       INNER JOIN PurchaseOrderDetails ON PurchaseOrders.PurchaseOrderID = PurchaseOrderDetails.PurchaseOrderID " + "\r\n";
            queryString = queryString + "                       INNER JOIN AspNetUsers Salespersons ON PurchaseOrders.PreparedPersonID = Salespersons.UserID " + "\r\n";
            queryString = queryString + "                       INNER JOIN AspNetUsers VerifierPersons ON PurchaseOrders.VerifierID = VerifierPersons.UserID " + "\r\n";
            queryString = queryString + "                       INNER JOIN AspNetUsers ControlPersons ON PurchaseOrders.ApproverID = ControlPersons.UserID " + "\r\n";
            queryString = queryString + "                       INNER JOIN AspNetUsers AuthorizedPersons ON PurchaseOrders.ManagerID = AuthorizedPersons.UserID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.projectManagerEntities.CreateStoredProcedure("PurchaseOrderSheet", queryString);
        }
    }
}
