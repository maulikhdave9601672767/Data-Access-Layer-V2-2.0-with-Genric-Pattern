using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
[Serializable]
   public partial class clsClientContact
    {
        public int ClientContactID { get; set; }

        public string ClientContactIDs { get; set; }

        public int ClientID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectClientContactID { get; set; }

        public string ClientIDs { get; set; }

        public string Id { get; set; }

        public string ContactPersonName { get; set; }

        public string companyname { get; set; }

        
        public string ContactPersonPhone { get; set; }

        public string ContactPersonEmail { get; set; }

        public string ContactPersonFax { get; set; }

        public int CreatedBy { get; set; }
    }
}
