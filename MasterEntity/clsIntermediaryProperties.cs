using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsIntermediary
    {
        public int IntermediaryID { get; set; }

        public string IntermediaryIDs { get; set; }

        public string CompanyName { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Website { get; set; }

        public string Names { get; set; }

        public string Phone { get; set; }

        public string Phones { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Faxs { get; set; }

        public string Emails { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

    }
}
