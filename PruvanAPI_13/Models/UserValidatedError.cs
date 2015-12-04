using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class UserValidatedError
    {
        public UserValidatedError() { }

        public UserValidatedError(string ErrorMsg)
        {
            this.error = ErrorMsg;
        }
        public string error { get; set; }
    }
}
