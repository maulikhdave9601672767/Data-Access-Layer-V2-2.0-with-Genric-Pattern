using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsPaymentMade
    {

        public int ProjectPaymentID { get; set; }
        public string ProjectPaymentIDs { get; set; }
        public int ProjectId { get; set; }
        public string PaidTo { get; set; }
        public decimal PaidAmt { get; set; }
        public string PaidDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string CheckNumber { get; set; }
        public string AmountPercent { get; set; }
        public string PaymentMadeImageURL { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
