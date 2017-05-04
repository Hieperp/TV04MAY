using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;


using TotalModel.Models;

using TotalDTO.Sales;
using TotalDTO.Purchases;
using TotalDTO.Inventories;
using TotalDTO.Commons;
using TotalDTO.Accounts;

using TotalPortal.Areas.Sales.ViewModels;
using TotalPortal.Areas.Purchases.ViewModels;
using TotalPortal.Areas.Inventories.ViewModels;
using TotalPortal.Areas.Accounts.ViewModels;
using TotalPortal.Areas.Commons.ViewModels;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TotalPortal.App_Start.AutoMapperConfig), "SetupMappings")]
namespace TotalPortal.App_Start
{
    public static class AutoMapperConfig
    {
        public static void SetupMappings()
        {
        ////////https://github.com/AutoMapper/AutoMapper/wiki/Static-and-Instance-API

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PurchaseOrder, PurchaseOrderViewModel>();
                cfg.CreateMap<PurchaseOrder, PurchaseOrderDTO>();
                cfg.CreateMap<PurchaseOrderPrimitiveDTO, PurchaseOrder>();
                cfg.CreateMap<PurchaseOrderViewDetail, PurchaseOrderDetailDTO>();
                cfg.CreateMap<PurchaseOrderDetailDTO, PurchaseOrderDetail>();

                
                cfg.CreateMap<DeliveryAdvice, DeliveryAdviceViewModel>();
                cfg.CreateMap<DeliveryAdvice, DeliveryAdviceDTO>();
                cfg.CreateMap<DeliveryAdvicePrimitiveDTO, DeliveryAdvice>();
                cfg.CreateMap<DeliveryAdviceViewDetail, DeliveryAdviceDetailDTO>();
                cfg.CreateMap<DeliveryAdviceDetailDTO, DeliveryAdviceDetail>();

                cfg.CreateMap<DeliveryAdvice, DeliveryAdviceBoxDTO>();

                cfg.CreateMap<GoodsIssue, GoodsIssueViewModel>();
                cfg.CreateMap<GoodsIssue, GoodsIssueDTO>();
                cfg.CreateMap<GoodsIssuePrimitiveDTO, GoodsIssue>();
                cfg.CreateMap<GoodsIssueViewDetail, GoodsIssueDetailDTO>();
                cfg.CreateMap<GoodsIssueDetailDTO, GoodsIssueDetail>();

                cfg.CreateMap<GoodsIssue, GoodsIssueBoxDTO>();

                cfg.CreateMap<HandlingUnit, HandlingUnitViewModel>();
                cfg.CreateMap<HandlingUnit, HandlingUnitDTO>();
                cfg.CreateMap<HandlingUnitPrimitiveDTO, HandlingUnit>();
                cfg.CreateMap<HandlingUnitViewDetail, HandlingUnitDetailDTO>();
                cfg.CreateMap<HandlingUnitDetailDTO, HandlingUnitDetail>();

                cfg.CreateMap<GoodsDelivery, GoodsDeliveryViewModel>();
                cfg.CreateMap<GoodsDelivery, GoodsDeliveryDTO>();
                cfg.CreateMap<GoodsDeliveryPrimitiveDTO, GoodsDelivery>();
                cfg.CreateMap<GoodsDeliveryViewDetail, GoodsDeliveryDetailDTO>();
                cfg.CreateMap<GoodsDeliveryDetailDTO, GoodsDeliveryDetail>();

                cfg.CreateMap<AccountInvoice, AccountInvoiceViewModel>();
                cfg.CreateMap<AccountInvoice, AccountInvoiceDTO>();
                cfg.CreateMap<AccountInvoicePrimitiveDTO, AccountInvoice>();
                cfg.CreateMap<AccountInvoiceViewDetail, AccountInvoiceDetailDTO>();
                cfg.CreateMap<AccountInvoiceDetailDTO, AccountInvoiceDetail>();

                cfg.CreateMap<Receipt, ReceiptViewModel>();
                cfg.CreateMap<Receipt, ReceiptDTO>();
                cfg.CreateMap<ReceiptPrimitiveDTO, Receipt>();
                cfg.CreateMap<ReceiptViewDetail, ReceiptDetailDTO>();
                cfg.CreateMap<ReceiptDetailDTO, ReceiptDetail>();



                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<Customer, CustomerBaseDTO>();
                cfg.CreateMap<CustomerPrimitiveDTO, Customer>();

                cfg.CreateMap<Project, ProjectViewModel>();
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<Project, ProjectBaseDTO>();
                cfg.CreateMap<ProjectPrimitiveDTO, Project>();

                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<Employee, EmployeeBaseDTO>();
                cfg.CreateMap<EmployeePrimitiveDTO, Employee>();

                cfg.CreateMap<PaymentTerm, PaymentTermViewModel>();
                cfg.CreateMap<PaymentTerm, PaymentTermDTO>();
                cfg.CreateMap<PaymentTerm, PaymentTermBaseDTO>();
                cfg.CreateMap<PaymentTermPrimitiveDTO, PaymentTerm>();
                
                cfg.CreateMap<Promotion, PromotionDTO>();
                cfg.CreateMap<VoidType, VoidTypeBaseDTO>();
                

                //cfg.CreateMap<Module, ModuleViewModel>();
                //cfg.CreateMap<ModuleDetail, ModuleDetailViewModel>();
            });



            //Mapper.CreateMap<Module, ModuleViewModel>();
            //Mapper.CreateMap<ModuleDetail, ModuleDetailViewModel>();
        }
    }
}