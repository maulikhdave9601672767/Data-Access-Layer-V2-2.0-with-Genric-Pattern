using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectEngineer
    {
        public int ProjectEngineerID { get; set; }
        public int EngineerID { get; set; }
        public string EngineerIDs { get; set; }
        public string ProjectEngineerIDs { get; set; }
        public string JobName{ get; set; }
        public string OurPONo { get; set; }
        public string EngineerName { get; set; }

        public int ProjectID { get; set; }

        public decimal  EngineerCost { get; set; }
        public int OurPaymentTerms { get; set; }
        public int EngineerPaymentTerms { get; set; }

        public int  IsWon{ get; set; }
        //public int OurPONo { get; set; }
        public int CreatedBy { get; set; }


    }
}
