using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruvanAPI_13.Models
{
    public class UserValidated
    {
        public UserValidated() { }

        public UserValidated(string ErrorMsg, bool IsValid)
        {
            this.error = ErrorMsg;
            this.validated = IsValid;
        }
        public string error { get; set; }
        public bool validated { get; set; }
        public UserValidated getUser(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.IndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            UserValidated uv = JsonConvert.DeserializeObject<UserValidated>(test3);
            return uv;
        }
    }
}
