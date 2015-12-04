using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class WorkOrderError
    {
        public WorkOrderError() { }
        public WorkOrderError(string woNum, string ErrorMsg)
        {
            this.workOrderNumber = woNum;
            this.error = ErrorMsg;
        }
        public string workOrderNumber { get; set; }
        public string error { get; set; }
    }
}
