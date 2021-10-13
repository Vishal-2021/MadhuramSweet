using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class ComboPack
    {
        public Customer_Registration Customer_Registration { get; set; }
        public Store_AddProduct Store_AddProduct { get; set; }
        public delivery_charges delivery_charges { get; set; }


        public Cart Cart { get; set; }

        public CustomerOrder CustomerOrder { get; set; }

        public OrderedProducts OrderedProducts { get; set; }

        public CustomerDeliveryStatus CustomerDeliveryStatus { get; set; }

        public ItemsCancleReason ItemsCancleReason { get; set; }

        public CustomerSlider CustomerSlider { get; set; }

        public Feedback Feedback { get; set; }



        public Registration Rgst { get; set; }
        public UserAccess_Info UserAccess_Info { get; set; }
        public User_Access User_Access { get; set; }



        public CustomerDetails CustDtl { get; set; }
        public Product_Catagory Product_Catagory { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public OrganizationDetails OrganizationDetails { get; set; }
        public BankDetails BankDetails { get; set; }
        public PurchaseDtl PurchaseDtl { get; set; }
        public PaymentFromSupplier PaymentFromSupplier { get; set; }
        public PurchaseOldRate PurchaseOldRate { get; set; }
        public PurchaseReportBill PurchaseReportBill { get; set; }
        public CustSuppPayment CustSuppPayment { get; set; }
        public CustSupTransaction CustSupTransaction { get; set; }
        public PurchaseForReport PurchaseForReport { get; set; }
        public BillTypes BillTypes { get; set; }
        public TermsCondition TermsCondition { get; set; }



        // Sales bill  without Gst 
        public SalesBillWithoutGstDtl SalesBillWithoutGstDtl { get; set; }
        public TempSalesBillWithoutGstDtl TempSalesBillWithoutGstDtl { get; set; }
        public SalesBillWithoutGstDtl_ChargesDisc SalesBillWithoutGstDtl_ChargesDisc { get; set; }
        public SalesBillWithoutGstDtl_Report SalesBillWithoutGstDtl_Report { get; set; }


        // TnC Sale without Gst
        public SaleWiGstTnC SaleWiGstTnC { get; set; }


        // Payment from sale
        public SaleWiGstPayment SaleWiGstPayment { get; set; }
        public SaleWiGstTransactions SaleWiGstTransactions { get; set; }

        // End Sales bill without Gst

        


        // Sales With Gst
        public SalesGST SalesGST { get; set; }
        public TempSaleGST TempSaleGST { get; set; }
        public SalesGST_ChargeDisc SalesGST_ChargeDisc { get; set; }
        public SalesGST_Report SalesGST_Report { get; set; }
        public SalesGst_Tnc SalesGst_Tnc { get; set; }

        public SalesGST_Payment SalesGST_Payment { get; set; }
        public SalesGST_Transactions SalesGST_Transactions { get; set; }

        // End Sale With Gst

        public CreditNotes CreditNotes { get; set; }
        public TempCreditNotes TempCreditNotes { get; set; }
        public CreditNotesTnC CreditNotesTnC { get; set; }



        public CommanBillNo CommanBillNo { get; set; }
        public TempDataPurchase TempDataPurchase { get; set; }
        public ActivationStatus ActStats { get; set; }
        public State state { get; set; }
        public District district { get; set; }
        public TypesOfGoods TypesOfGoods { get; set; }
        public Mesurement Mesurement { get; set; }
        public ProductGST ProductGST { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }



        public UploadedTb UploadedTb { get; set; }
        public UploadFiles UploadFiles { get; set; }


        public Daily_Business Daily_Business { get; set; }
        public NormalIncomeExpense NormalIncomeExpense { get; set; }

    }
}