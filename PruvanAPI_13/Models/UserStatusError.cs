using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class UserStatusError
    {
        public UserStatusError() { }
        public UserStatusError(bool Status, WorkOrderError WOError)
        {
            this.status = Status;
            this.error = WOError;
        }
        public bool status { get; set; }
        public WorkOrderError error { get; set; }
    }
}
