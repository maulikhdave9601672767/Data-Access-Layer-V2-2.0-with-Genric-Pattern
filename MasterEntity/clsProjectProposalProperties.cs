using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
   public partial  class clsProjectProposal 
    {
        public int ProjectProposalID { get; set; }

        public int ProjectID { get; set; }
        public int EngineerID { get; set; }
        public string EngineerName { get; set; }
        public string ReceiveDate { get; set; }
        public string DocumentName { get; set; }
        public string ProposalFileName { get; set; }
        public string UploadType { get; set; }
        public int CreatedBy { get; set; }
    }
}
