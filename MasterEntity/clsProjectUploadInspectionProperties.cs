using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectUploadInspection
    {
        public int ProjectInspectionID { get; set; }

        public int ProjectID { get; set; }
        public string InspectionDate { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentFileName { get; set; }
        public int CreatedBy { get; set; }
    }
}
