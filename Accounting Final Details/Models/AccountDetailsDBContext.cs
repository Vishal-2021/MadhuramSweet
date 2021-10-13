using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class AccountDetailsDBContext : DbContext
    {
        // Store
        public DbSet<Customer_Registration> Customer_Registration { get; set; }
        public DbSet<Store_AddProduct> Store_AddProduct { get; set; }
        public DbSet<delivery_charges> delivery_charges { get; set; }


        public DbSet<Cart> Cart { get; set; }

        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<OrderedProducts> OrderedProducts { get; set; }
        public DbSet<CustomerDeliveryStatus> CustomerDeliveryStatus { get; set; }
        public DbSet<ItemsCancleReason> ItemsCancleReason { get; set; }


        public DbSet<CustomerSlider> CustomerSlider { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        


        // End store





        public DbSet<AdminLogin> AdminLogin { get; set; }

        public DbSet<User_Access> User_Access { get; set; }

        public DbSet<UserAccess_Info> UserAccess_Info { get; set; }
   
       
        public DbSet<Registration> Registration { get; set; }
        //    public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<PurchaseForReport> PurchaseForReport { get; set; }
        
        public DbSet<Product_Catagory> Product_Catagory { get; set; }
        public DbSet<PurchaseDtl> PurchaseDtl { get; set; }
        public DbSet<PurchaseReportBill> PurchaseDtlPurchaseReportBill { get; set; }
        public DbSet<CustSuppPayment> CustSuppPayment { get; set; }      
        public DbSet<CustSupTransaction> CustSupTransaction { get; set; }



        // Sales bill without gst
        public DbSet<SalesBillWithoutGstDtl> SalesBillWithoutGstDtl { get; set; }
        public DbSet<TempSalesBillWithoutGstDtl> TempSalesBillWithoutGstDtl { get; set; }
        public DbSet<SalesBillWithoutGstDtl_ChargesDisc> SalesBillWithoutGstDtl_ChargesDisc { get; set; }
        public DbSet<SalesBillWithoutGstDtl_Report> SalesBillWithoutGstDtl_Report { get; set; }

        // TnC Sale without Gst
        public DbSet<SaleWiGstTnC> SaleWiGstTnC { get; set; }


        // Payment from Sale
        public DbSet<SaleWiGstPayment> SaleWiGstPayment { get; set; }
        public DbSet<SaleWiGstTransactions> SaleWiGstTransactions { get; set; }
        // End Sales bill without gst


        // Sale Bill With GST
        public DbSet<SalesGST> SalesGST { get; set; }
        public DbSet<TempSaleGST> TempSaleGST { get; set; }
        // End Sale Bill With GST


        // Credit Notes 
         public DbSet<CreditNotes> CreditNotes { get; set; }
         public DbSet<TempCreditNotes> TempCreditNotes { get; set; }
         public DbSet<CreditNotesTnC> CreditNotesTnC { get; set; }

        
        // end Credit notes


        // Comman bill no
        public DbSet<CommanBillNo> CommanBillNo { get; set; }
        // End Comman Bill No

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



        // Sales Gst

        public DbSet<SalesGST_ChargeDisc> SalesGST_ChargeDisc { get; set; }
        public DbSet<SalesGST_Report> SalesGST_Report { get; set; }

        public DbSet<SalesGST_Payment> SalesGST_Payment { get; set; }
        public DbSet<SalesGST_Transactions> SalesGST_Transactions { get; set; }
      


        public DbSet<SalesGst_Tnc> SalesGst_Tnc { get; set; }

        // End Sales Gst




















        //  belows are dropdownlists

        public DbSet<BillTypes> BillTypes { get; set; }
        public DbSet<TermsCondition> TermsCondition { get; set; }




        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Wearhouse> Wearhouse { get; set; }

        public DbSet<OrganizationDetails> OrganizationDetails { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }
        public DbSet<PaymentFromSupplier> PaymentFromSupplier { get; set; }
        public DbSet<PurchaseOldRate> PurchaseOldRate { get; set; }



        // Temp purchase
        public DbSet<TempDataPurchase> TempDataPurchase { get; set; }

        

        // All DropdownList Tables
        public DbSet<ActivationStatus> ActivationStatus { get; set; }
        public DbSet<Mesurement> Mesurement { get; set; }
        public DbSet<TypesOfGoods> TypesOfGoods { get; set; }
        public DbSet<State> state { get; set; }
        public DbSet<District> district { get; set; }
        public DbSet<ProductGST> ProductGST { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }









        public DbSet<UploadedTb> UploadedTb { get; set; }
        public DbSet<UploadFiles> UploadFiles { get; set; }




        public DbSet<Daily_Business> Daily_Business { get; set; }

        public DbSet<NormalIncomeExpense> NormalIncomeExpense { get; set; }
        

    }
}