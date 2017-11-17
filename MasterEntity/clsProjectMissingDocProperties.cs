using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectMissingDoc
    {
        public int MissingDocID { get; set; }
        public int OurPONo { get; set; }
        public string MissingDocIDs { get; set; }

        public int ProjectID { get; set; }
        public string MissingDocName { get; set; }
        public string DueDate { get; set; } 
        public string EngineerEmail { get; set; }
        public string IsMissing { get; set; }
        public string IsSendClient { get; set; }
        public bool IsSendToClient { get; set; }
        public bool IsReceived { get; set; }
        public int CreatedBy { get; set; }
    }
}
