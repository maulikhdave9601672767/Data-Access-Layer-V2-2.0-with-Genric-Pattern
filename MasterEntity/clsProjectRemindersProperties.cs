using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsProjectReminders
    {
        public int ProjectReminderID { get; set; }

        public int InvoiceDays { get; set; }

        public int PaymentMadeDays { get; set; }

        public int DocumentMissingDays { get; set; }
        
        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}
