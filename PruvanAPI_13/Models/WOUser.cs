using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PruvanAPI_13.Models
{
    public class WOUser
    {
        public WOUser() { }
        public WOUser(string UserName, string Password, string Token, string TimeStamp)
        {
            this.username = UserName;
            this.password = Password;
            this.token = Token;
            this.timestamp = TimeStamp;
        }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string timestamp { get; set; }
        public WOUser getUser(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.IndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            WOUser uv = JsonConvert.DeserializeObject<WOUser>(test3);
            return uv;
        }
        public bool IsUserValid(WOUser uv)
        {
            bool returnBool = false;
            if (uv != null)
            {
                if (uv.username.ToLower() == "ibryon" || uv.username.ToLower() == "rgarcia" || uv.username.ToLower() == "figlesias" || uv.username.ToLower() == "inti27@gmail.com")
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }
        public bool IsUserValid2(WOUser uv)
        {
            //does not use default ASP.NET Identity Framework, uses VDS logic
            bool returnBool = false;
            LoginMembership utcNow = new LoginMembership().GetMembership(uv.username);

            if (utcNow == null)
            {
                returnBool = false;
            }
            else if (LoginHelper.Hash(utcNow.PasswordSalt, uv.token) == utcNow.Password)
            {
                returnBool = true;
            }
            return returnBool;
        }

    }
}