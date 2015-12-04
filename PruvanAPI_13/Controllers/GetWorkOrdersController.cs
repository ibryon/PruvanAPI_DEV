using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruvanAPI_13.Models;

namespace PruvanAPI_13.Controllers
{
    public class GetWorkOrdersController : ApiController
    {
        private ServiceLog sl = new ServiceLog();

        [HttpGet]
        public WorkOrderResult Get()
        {
            WorkOrder[] woList = new WorkOrder().GetSampleDate();
            WorkOrderResult wor = new WorkOrderResult(woList, "");
            return wor;
        }

        [HttpGet]
        public WorkOrderResult Get(string id)
        {
            WorkOrderResult wor = new WorkOrderResult().GetWorkOrdersByVendor(id);
            return wor;
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            string payload = Request.Content.ReadAsStringAsync().Result;
            WOUser uv = new WOUser().getUser(payload);
            bool isValid = uv.IsUserValid2(uv);

            sl.WriteToLog(new string[] { "------------ LOG ENTRY (GET WORK ORDERS)------------", "Username: " + uv.username, "Password: " + uv.password, "TimeStamp: " + uv.timestamp, "" });

            if (isValid == true)
            {
                try
                {
                    sl.WriteToLog(new string[] { "User: " + uv.username + "  Is Valid" });
                    DateTime dt;
                    if (DateTime.TryParse(uv.timestamp, out dt))
                    {
                        //incremental
                        WorkOrderResult wor = new WorkOrderResult().GetWorkOrdersIncremental(uv, dt);
                        var response = Request.CreateResponse<WorkOrderResult>(System.Net.HttpStatusCode.OK, wor);
                        sl.WriteToLog(new string[] { "Incremental Request Processed ", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                        return response;

                    }
                    else
                    {
                        //full load
                        WorkOrderResult wor = new WorkOrderResult().GetWorkOrdersFull(uv);
                        var response = Request.CreateResponse<WorkOrderResult>(System.Net.HttpStatusCode.OK, wor);
                        sl.WriteToLog(new string[] { "FULL Request Processed ", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    UserValidatedError vu = new UserValidatedError(ex.Message);
                    var response = Request.CreateResponse<UserValidatedError>(System.Net.HttpStatusCode.NotAcceptable, vu);
                    sl.WriteToLog(new string[] { "Error: " + ex.Message, "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    return response;
                }
            }
            else
            {
                UserValidatedError vu = new UserValidatedError("invalid username or password");
                var response = Request.CreateResponse<UserValidatedError>(System.Net.HttpStatusCode.Unauthorized, vu);
                sl.WriteToLog(new string[] { "invalid username or password", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                return response;
            }
        }
    }
}
