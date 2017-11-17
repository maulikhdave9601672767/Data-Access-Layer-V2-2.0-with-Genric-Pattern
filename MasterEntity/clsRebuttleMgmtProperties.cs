using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsRebuttleMgmtProperties
    {
        public int ProjectRebuttleMgmtID { get; set; }

        public int ProjectID { get; set; }
        public string RebuttleStatus { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
