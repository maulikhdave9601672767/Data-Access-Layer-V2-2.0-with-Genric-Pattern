using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsOurProposal
    {

        public int ProjectOurProposalID { get; set; }

        public int ProjectID { get; set; }
        public string ReceiveDate { get; set; }
        public string DocumentName { get; set; }
        public string OurProposalFileName { get; set; }
        public string UploadType { get; set; }
        public int CreatedBy { get; set; }
    }
}
