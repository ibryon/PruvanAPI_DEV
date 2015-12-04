using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PruvanAPI_13.Models
{
    public class LoginUser
    {
        public static Guid DefaultAppId;

        public Guid ApplicationId
        {
            get;
            set;
        }

        public DateTime LastActivityDate
        {
            get;
            set;
        }

        public string LoweredUserName
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        static LoginUser()
        {
            LoginUser.DefaultAppId = Guid.Parse("5F16515C-CA9F-45B2-80CB-190A2D764739");
        }

        public LoginUser()
        {
        }

        public LoginUser(Guid userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.LoweredUserName = this.UserName.ToLower();
            this.LastActivityDate = DateTime.UtcNow;
            this.ApplicationId = LoginUser.DefaultAppId;
        }

        //public LoginUser GetUser(string UserName)
        //{
        //    DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["AppCoreDEV"].ConnectionString);
        //    List<SqlParameter> parms = new List<SqlParameter>();
        //    //parms.Add(new SqlParameter("eMail", UserName));
        //    DataTable wo = dm.DataReturnDataTable("spPruvanWokOrder_Select", parms);
        //}
    }
}