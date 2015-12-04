using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using PruvanAPI_13.Models;

namespace PruvanAPI_13.Controllers
{
    public class StatusController : ApiController
    {
        private ServiceLog sl = new ServiceLog();

        [HttpGet]
        public UserStatus Get()
        {
            WorkOrder[] woList = new WorkOrder().GetSampleDate();
            UserStatus us = new UserStatus("ibryon@pkmg.net", "Test1234", "", woList);
            return us;
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            string payload = Request.Content.ReadAsStringAsync().Result;
            try
            {
                UserStatus uv = new UserStatus().getUser(payload);
                sl.WriteToLog(new string[] { "------------ LOG ENTRY (STATUS UPDATE)------------", "Username: " + uv.username, "Password: " + uv.password, "WO Count: " + uv.workOrders.Length.ToString() });
                bool isValid = uv.IsUserValid(uv);
                if (isValid == true)
                {
                    sl.WriteToLog(new string[] { "User: " + uv.username + "  Is Valid" });
                    //update wo
                    bool isUpdated = new WorkOrder().UpdateWorkOrder(uv.workOrders);

                    //return ok
                    UserStatusError vu = new UserStatusError(true, null);
                    var response = Request.CreateResponse<UserStatusError>(System.Net.HttpStatusCode.OK, vu);
                    sl.WriteToLog(new string[] { "Workorders Updated Successfully", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    return response;
                }
                else
                {
                    UserStatusError vu = new UserStatusError(false, new WorkOrderError(uv.username, "invalid username or password "));
                    var response = Request.CreateResponse<UserStatusError>(System.Net.HttpStatusCode.Unauthorized, vu);
                    sl.WriteToLog(new string[] { "User: " + uv.username + "  Is NOT Valid", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    return response;
                }
            }
            catch (Exception ex)
            {
                UserStatusError vu = new UserStatusError(false, new WorkOrderError(ex.Message, ex.Source));
                var response = Request.CreateResponse<UserStatusError>(System.Net.HttpStatusCode.NotAcceptable, vu);
                sl.WriteToLog(new string[] { "Error: " + ex.Message, "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                return response;
            }
        }
    }
}
