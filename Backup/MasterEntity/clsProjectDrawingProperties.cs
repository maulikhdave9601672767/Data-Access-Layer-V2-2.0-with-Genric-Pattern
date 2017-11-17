using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectDrawing
    {
        public int ProjectDrawingID { get; set; }

        public int ProjectID { get; set; }
        public string ReceiveDate { get; set; }
        public string DrawingName { get; set; }
        public string DrawingFileName { get; set; }
        public string UploadType { get; set; }
        public int CreatedBy { get; set; }
    }
}
