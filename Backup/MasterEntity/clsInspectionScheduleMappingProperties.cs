using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer 
{
    public partial class clsInspectionScheduleMapping
    {
        public int ProjectInspectionID { get; set; }
        public string ProjectInspectionIDs { get; set; }
        public int ProjectID { get; set; }
        public string InspectionName { get; set; }
        public string InspectionDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string InspectionResultDoc { get; set; } 
    }
}
