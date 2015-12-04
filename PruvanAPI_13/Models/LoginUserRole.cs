using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class LoginUserRole
    {
        public Guid RoleId
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        public LoginUserRole()
        {
        }
    }
}
