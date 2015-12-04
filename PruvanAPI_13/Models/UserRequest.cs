using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PruvanAPI_13.Models
{
    public class UserRequest
    {
        public UserRequest() { }
        public UserRequest(string UserName, string Password, string Token, string PushKey)
        {
            this.username = UserName;
            this.password = Password;
            this.token = Token;
            this.pushkey = PushKey;
        }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string pushkey { get; set; }
        public UserRequest getUser(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.IndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            UserRequest uv = JsonConvert.DeserializeObject<UserRequest>(test3);
            return uv;
        }

    }
}