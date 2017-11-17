using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsInvoice
    {
        
        public int ProjectInvoiceID { get; set; }
        public string OurPONo { get; set; }
        public string ProjectInvoiceIDs { get; set; }
        public int ProjectID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string DateReceived { get; set; }
        public string CheckNumber { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal AmountInPercentage { get; set; }
        public string UploadedImageInvoiceName { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string JobName { get; set; }

        public string JobCity { get; set; }

        public string JobState { get; set; }

        public string JobZip { get; set; }

        public string JobAddress { get; set; }
        public string CompanyName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }

        public string strError { get; set; }

        public string InvoiceFileName { get; set; }


    }
}
