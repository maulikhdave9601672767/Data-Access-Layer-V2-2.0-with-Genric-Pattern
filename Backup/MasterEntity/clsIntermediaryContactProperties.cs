using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;

namespace BussinessLayer
{[Serializable]
    public partial class clsIntermediaryContact 
    {
        public int IntermediaryContactID { get; set; }

        public string IntermediaryContactIDs { get; set; }

        public int IntermediaryID { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonPhone { get; set; }

        public string ContactPersonEmail { get; set; }

        public string ContactPersonFax { get; set; }

        public string CompanyName { get; set; }

        public int ProjectId { get; set; }

        public int CreatedBy { get; set; }
    }
}
