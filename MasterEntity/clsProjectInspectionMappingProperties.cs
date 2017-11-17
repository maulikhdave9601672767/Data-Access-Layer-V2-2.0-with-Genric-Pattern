using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectInspectionMapping
    {
        public int ProjectInspectionMappingID { get; set; }

        public int ProjectID { get; set; }
        public int InspectionTypeID { get; set; }
        public string GeneratedFileName { get; set; }
        public int GeneratedInspectionID { get; set; }
        public string InspectionTypeName { get; set; }
        public string InspectionValue { get; set; }
        public string PriceTag { get; set; }
        public string PriceValue { get; set; }
        public string CustomUpload { get; set; }
        public int CreatedBy { get; set; }
    }
}
