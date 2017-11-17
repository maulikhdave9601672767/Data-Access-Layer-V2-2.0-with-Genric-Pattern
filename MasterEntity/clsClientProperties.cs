using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsClient
    {
        public int ClientID { get; set; }
        public string ClientIDs { get; set; }

        public string CompanyName { get; set; }

        

        public string Street1 { get; set; }
        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ContactPerson1Name { get; set; }

        public string ContactPerson1Phone { get; set; }

        public string ContactPerson1Email { get; set; }

        public string ContactPerson1Fax { get; set; }

        public string ContactPerson2Name { get; set; }

        public string ContactPerson2Phone { get; set; }

        public string ContactPerson2Email { get; set; }

        public string ContactPerson2Fax { get; set; }

        public string Website { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Fax { get; set; }

        public bool Allow { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }


        public string Names { get; set; }

        public string Faxs { get; set; }

        public string Emails { get; set; }

        public string Phones { get; set; }

    }
}
