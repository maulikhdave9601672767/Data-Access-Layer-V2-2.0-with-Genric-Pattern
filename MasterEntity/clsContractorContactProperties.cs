using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
  [Serializable]
   public partial class clsContractorContact
    {
        public int ContractorContactID { get; set; }

        public string ContractorContactIDs { get; set; }

        public int ContractorID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectContractorContactID { get; set; }

        public string ContractorIDs { get; set; }
        public string Id { get; set; }

        public string contractorname { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonPhone { get; set; }

        public string ContactPersonEmail { get; set; }

        public string ContactPersonFax { get; set; }

        public int CreatedBy { get; set; }
    }
}
