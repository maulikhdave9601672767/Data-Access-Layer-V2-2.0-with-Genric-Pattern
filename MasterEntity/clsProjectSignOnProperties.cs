﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectSignOn
    {
        public int ProjectSignOnID { get; set; }

        public int ProjectID { get; set; }
        public string ReceiveDate { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentFileName { get; set; }
        public int CreatedBy { get; set; }
    }
}
