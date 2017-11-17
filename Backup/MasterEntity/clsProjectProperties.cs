using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProject
    {
        public int UserID { get; set; }
        public string UserType { get; set; }

        public int ProjectID { get; set; }
        public string ProjectIDs { get; set; }
        public int ContractorID { get; set; }
        public int ClientID { get; set; }

        //public int OurPONo { get; set; }
        public string OurPONo { get; set; }
        public string SearchText { get; set; }
        public string Address { get; set; }

        //new
        public string Street1 { get; set; }
        public string Street2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        //new


        public string JobAddress { get; set; }
        public string GCClientContact1 { get; set; }
        public string GCClientContact2 { get; set; }
        public string GCContractorContact1 { get; set; }
        public string GCContractorContact2 { get; set; }
        public string GCAddress { get; set; }
        public string GCCity { get; set; }
        public string GCState { get; set; }
        public string GCZip { get; set; }
        public string GCPhone { get; set; }
        public string GCEmail { get; set; }

        public string EngineerName { get; set; }

        // Rebuttle Mgmt

        public int ProjectRebuttleMgmtID { get; set; }
        public string ProjectRebuttleMgmtIDs { get; set; }

        public string RebuttleStatus { get; set; }
        public string ReceiveDate { get; set; }

        public string CompanyName { get; set; }

        public string JobName { get; set; }

        public string JobCity { get; set; }

        public string JobState { get; set; }

        public string JobZip { get; set; }

        public string JobFloor { get; set; }

        public int OurPaymentTerms { get; set; }

        public int EngineerPaymentTerms { get; set; }

        public int EngineerID { get; set; }

        public decimal EngineerCost { get; set; }
        public decimal TotalEngineerCost { get; set; }
        public decimal RevenueCost { get; set; }

        public bool IsAssigned { get; set; }
        public string SearchIsAssigned { get; set; }
        public string SearchIsWon { get; set; }

        public int IsWon { get; set; }

        public string FromPODate { get; set; }
        public string ToPODate { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string PODate { get; set; }
        public string StartDate { get; set; }


        public string strError { get; set; }

        public string FromStartDate { get; set; }

        public string ToStartDate { get; set; }

        public int Reminders { get; set; }

        public bool StartBill { get; set; }

        public bool IsClosed { get; set; }

        public string ProjectCloseDate { get; set; }

        public string AdditionalInformation { get; set; }

        public string xmldoc { get; set; }

        public string xmldocCont { get; set; }

        public string xmldocInt { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}
