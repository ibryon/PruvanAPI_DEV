using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using PruvanAPI_13.Models;
using PruvanAPI_13.Controllers;

namespace PruvanAPI_13.Controllers
{
    public class ValidateController : ApiController
    {
        private ServiceLog sl = new ServiceLog();

        [HttpGet]
        public UserRequest Get()
        {
            UserRequest rUser = new UserRequest();
            rUser.username = "ibryon";
            rUser.password = "test1234";
            rUser.token = "";
            rUser.pushkey = "";
            return rUser;
        }
        public UserValidate Get(string id, string pw)
        {
            UserValidate uv = new UserValidate();
            uv.username = id;
            uv.password = pw;
            bool isValid = uv.IsUserValid(uv);
            if (isValid == true)
            {
                uv.pushkey = "is valid";
            }
            else
            {
                uv.pushkey = "is not valid";
            }
            return uv;
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            try
            {
                string payload = Request.Content.ReadAsStringAsync().Result;
                UserValidate uv = new UserValidate().getUser(payload);
                sl.WriteToLog(new string[] { "------------ LOG ENTRY (VALIDATE)------------", "Username: " + uv.username, "Password: " + uv.password, "PushKey" + uv.pushkey });
                bool isValid = uv.IsUserValid(uv);
                if (isValid == true)
                {
                    UserValidated vu = new UserValidated("", true);
                    var response = Request.CreateResponse<UserValidated>(System.Net.HttpStatusCode.OK, vu);
                    sl.WriteToLog(new string[] { "User: " + uv.username + "  Is Valid", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    //add api key to user DB
                    uv.AddAPIKeyToDB(uv);
                    return response;
                }
                else
                {
                    UserValidated vu = new UserValidated("invalid username or password : " + uv.username, false);
                    var response = Request.CreateResponse<UserValidated>(System.Net.HttpStatusCode.Unauthorized, vu);
                    sl.WriteToLog(new string[] { "User: " + uv.username + "  Is NOT Valid", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    return response;
                }
            }
            catch (Exception ex)
            {
                UserValidated vu = new UserValidated(ex.Message, false);
                var response = Request.CreateResponse<UserValidated>(System.Net.HttpStatusCode.NotAcceptable, vu);
                sl.WriteToLog(new string[] { "Error: " + ex.Message, "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                return response;
            }
        }

    }
}
