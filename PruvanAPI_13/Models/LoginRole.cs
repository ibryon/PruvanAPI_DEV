using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class LoginRole
    {
        public Guid ApplicationId
        {
            get;
            set;
        }

        public Guid RoleId
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public LoginRole()
        {
        }
    }
}
