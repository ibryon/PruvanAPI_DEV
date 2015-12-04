using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruvanAPI_13.Models
{
    public class LoginMembership
    {
        public static Guid DefaultAppId;

        public Guid ApplicationId
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public int FailedPasswordAnswerAttemptCount
        {
            get;
            set;
        }

        public DateTime FailedPasswordAnswerAttemptWindowStart
        {
            get;
            set;
        }

        public int FailedPasswordAttemptCount
        {
            get;
            set;
        }

        public DateTime FailedPasswordAttemptWindowStart
        {
            get;
            set;
        }

        public bool IsApproved
        {
            get;
            set;
        }

        public bool IsLockedOut
        {
            get;
            set;
        }

        public DateTime LastLockoutDate
        {
            get;
            set;
        }

        public DateTime LastLoginDate
        {
            get;
            set;
        }

        public DateTime LastPasswordChangedDate
        {
            get;
            set;
        }

        public string LoweredEmail
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string PasswordSalt
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        static LoginMembership()
        {
            LoginMembership.DefaultAppId = Guid.Parse("5F16515C-CA9F-45B2-80CB-190A2D764739");
        }

        public LoginMembership()
        {
        }

        public LoginMembership(LoginUser user, string passwordSalt, string passwordHash)
        {
            this.UserId = user.UserId;
            this.PasswordSalt = passwordSalt;
            this.Password = passwordHash;
            this.Email = user.UserName;
            this.LoweredEmail = user.UserName.ToLower();
            this.ApplicationId = LoginMembership.DefaultAppId;
            this.IsApproved = false;
            this.IsLockedOut = false;
            this.CreateDate = DateTime.UtcNow;
            this.LastLoginDate = this.CreateDate;
            this.LastPasswordChangedDate = SqlDateTime.MinValue.Value;
            this.LastLockoutDate = SqlDateTime.MinValue.Value;
            this.FailedPasswordAttemptWindowStart = SqlDateTime.MinValue.Value;
            this.FailedPasswordAttemptCount = 0;
            this.FailedPasswordAnswerAttemptWindowStart = SqlDateTime.MinValue.Value;
            this.FailedPasswordAnswerAttemptCount = 0;
        }

        public LoginMembership GetMembership(string UserName)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["AppCoreDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("UserName", UserName));
            DataTable m = dm.DataReturnDataTable("spPruvanMembership_Select", parms);
            if (m.Rows.Count > 0)
            {
                LoginUser user = new LoginUser(Guid.Parse(m.Rows[0]["UserId"].ToString()), m.Rows[0]["Email"].ToString());
                return new LoginMembership(user, m.Rows[0]["PasswordSalt"].ToString(), m.Rows[0]["Password"].ToString());
            }
            else return null;
        }
    }
}
