using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsEngineer
    {

        public int EngineerID { get; set; }
        public int ProjectID { get; set; }
        public string EngineerCost { get; set; }
        public string EngineerIDs { get; set; }
        public string EngineerName { get; set; }

        public string EngineerContact1 { get; set; }

        public string EngineerContact2 { get; set; }

        public string EngineerContact3 { get; set; }

        public string EngineerEmail { get; set; }

        public string Password { get; set; }

        public string EngineerAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Website { get; set; }

        public bool Allow { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }

}
