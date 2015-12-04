using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruvanAPI_13.Models
{
    public class UserValidate
    {
        public string username { get; set; }
        public string password { get; set; }
        public string pushkey { get; set; }
        public UserValidate getUser(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.IndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            UserValidate uv = JsonConvert.DeserializeObject<UserValidate>(test3);
            return uv;
        }
        public int AddAPIKeyToDB(UserValidate uv)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["AppCoreDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("username", uv.username));
            parms.Add(new SqlParameter("PruvanKey", uv.pushkey));
            return dm.ExecuteNonQuery("spPruvanApiKey_Update", parms);
        }
        public bool IsUserValid(UserValidate uv)
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
        public bool IsUserValid2(UserValidate uv)
        {
            //does not use default ASP.NET Identity Framework, uses VDS logic
            bool returnBool = false;
            LoginMembership utcNow = new LoginMembership().GetMembership(uv.username);
            if (utcNow != null)
            {
                if (LoginHelper.Hash(utcNow.PasswordSalt, uv.password) == utcNow.Password)
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }
    }
}