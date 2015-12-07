using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PruvanAPI_13.Models
{
    public class UserStatus
    {
        public UserStatus() { }
        public UserStatus(string UserName, string Password, string Token, WorkOrder[] wo)
        {
            this.username = UserName;
            this.password = Password;
            this.token = Token;
            this.workOrders = wo;
        }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public WorkOrder[] workOrders { get; set; }
        public UserStatus getUser(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.LastIndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            UserStatus uv = JsonConvert.DeserializeObject<UserStatus>(test3);
            return uv;
        }
        public bool IsUserValid(UserStatus user)
        {
            bool returnBool = false;
            if (user != null)
            {
                if (user.username.ToLower() == "ibryon" || user.username.ToLower() == "rgarcia" || user.username.ToLower() == "figlesias" || user.username.ToLower() == "inti27@gmail.com")
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }

        public bool IsUserValid2(UserStatus user)
        {
            //does not use default ASP.NET Identity Framework, uses VDS logic
            bool returnBool = false;
            LoginMembership utcNow = new LoginMembership().GetMembership(user.username);
            if (utcNow != null)
            {
                if (LoginHelper.Hash(utcNow.PasswordSalt, user.token) == utcNow.Password)
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }
    }
}