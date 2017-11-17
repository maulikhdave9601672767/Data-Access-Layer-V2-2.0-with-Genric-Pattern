using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public partial class clsLogin
    {
        public int loginId { get; set; }
        public string loginIds { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string UType { get; set; }
        public int CreatedBy { get; set; }
    }
}
