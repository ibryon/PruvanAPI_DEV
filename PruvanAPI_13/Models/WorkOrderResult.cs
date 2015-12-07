using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class WorkOrderResult
    {
        public WorkOrderResult() { }
        public WorkOrderResult(WorkOrder[] wo, string ErrorMsg)
        {
            this.workOrders = wo;
            this.error = ErrorMsg;
        }
        public WorkOrder[] workOrders { get; set; }
        public string error { get; set; }
        public WorkOrderResult GetWorkOrdersFull(WOUser wo_user)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("UserName", wo_user.username));
            DataTable wo = dm.DataReturnDataTable("spPruvanWorkOrder_Select", parms);
            if (wo.Rows.Count > 0)
            {
                WorkOrder[] woFull = new WorkOrder[wo.Rows.Count];
                int rowIndex = 0;
                foreach (DataRow dr in wo.Rows)
                {
                    woFull[rowIndex] = new WorkOrder();
                    woFull[rowIndex].workOrderNumber = dr["WorkorderNo"].ToString();
                    woFull[rowIndex].address1 = dr["Address"].ToString();
                    woFull[rowIndex].city = dr["City"].ToString();
                    woFull[rowIndex].state = dr["State"].ToString();
                    woFull[rowIndex].zip = dr["ZipCode"].ToString();
                    woFull[rowIndex].clientStatus = dr["ClientStatus"].ToString();
                    woFull[rowIndex].wostatusid = int.Parse(dr["WorkOrderStatusId"].ToString());
                    woFull[rowIndex].workorderId = int.Parse(dr["WorkorderId"].ToString());
                    woFull[rowIndex].vendorId = int.Parse(dr["VendorId"].ToString());
                    woFull[rowIndex].description = dr["Description"].ToString();
                    woFull[rowIndex].dueDate = dr["DueOn"].ToString();
                    woFull[rowIndex].clientDueDate = dr["DueOn"].ToString();
                    //add default service(s)
                    List<WOServices> services = new List<WOServices>();
                    //generic WO task
                    services.Add(new WOServices("Task"));
                    //check for WO type and add survey(s) accordingly
                    string woType = dr["WOType"].ToString();
                    if (woType.ToUpper() == "HPIR")
                    {
                        //HPIR
                        services.Add(new WOServices("HPIR_Full", "hpirFull-v3"));
                    }
                    else if (woType.ToUpper() == "INITIAL ROUTINE" || woType.ToUpper() == "ROUTINE")
                    {
                        //Rountine
                        services.Add(new WOServices("Routine_Isnp", "routineInspectionFull-v1"));
                    }
                    else if (woType.ToUpper() == "PROPERTY CONDITION REPORT")
                    {
                        //PROPERTY CONDITION REPORT
                        //services.Add(new WOServices("Prop. Cond. Report", "PorpertyConditionReport-v1"));
                    }
                    else if (woType.ToUpper() == "SHORT PCR")
                    {
                        //SHORT PCR
                        //services.Add(new WOServices("Short PCR", "PCRShort-v1"));
                    }
                    else if (woType.ToUpper() == "QUALITY CONTROL")
                    {
                        //QUALITY CONTROL
                        //services.Add(new WOServices("Quality Control", "QalitltyControl-v1"));
                    }
                    woFull[rowIndex].services = services;

                    rowIndex++;
                }
                return new WorkOrderResult(woFull, "");
            }
            else
            {
                WorkOrder[] woFull = null;
                return new WorkOrderResult(woFull, "");
            }
        }
        public WorkOrderResult GetWorkOrdersIncremental(WOUser wo_user, DateTime timestamp)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("UserName", wo_user.username));
            parms.Add(new SqlParameter("IssuedOn", timestamp));
            DataTable wo = dm.DataReturnDataTable("spPruvanWorkOrder_Select", parms);
            if (wo.Rows.Count > 0)
            {
                WorkOrder[] woFull = new WorkOrder[wo.Rows.Count];
                int rowIndex = 0;
                foreach (DataRow dr in wo.Rows)
                {
                    woFull[rowIndex] = new WorkOrder();
                    woFull[rowIndex].workOrderNumber = dr["WorkorderNo"].ToString();
                    woFull[rowIndex].address1 = dr["Address"].ToString();
                    woFull[rowIndex].city = dr["City"].ToString();
                    woFull[rowIndex].state = dr["State"].ToString();
                    woFull[rowIndex].zip = dr["ZipCode"].ToString();
                    woFull[rowIndex].clientStatus = dr["ClientStatus"].ToString();
                    woFull[rowIndex].wostatusid = int.Parse(dr["WorkOrderStatusId"].ToString());
                    woFull[rowIndex].workorderId = int.Parse(dr["WorkorderId"].ToString());
                    woFull[rowIndex].vendorId = int.Parse(dr["VendorId"].ToString());
                    woFull[rowIndex].description = dr["Description"].ToString();
                    woFull[rowIndex].dueDate = dr["DueOn"].ToString();
                    woFull[rowIndex].clientDueDate = dr["DueOn"].ToString();
                    //add default service
                    List<WOServices> services = new List<WOServices>();
                    //generic WO task
                    services.Add(new WOServices("Task"));
                    //check for WO type and add survey(s) accordingly
                    string woType = dr["WOType"].ToString();
                    if (woType.ToUpper() == "HPIR")
                    {
                        //HPIR
                        services.Add(new WOServices("HPIR_Full", "hpirFull-v3"));
                    }
                    else if (woType.ToUpper() == "INITIAL ROUTINE" || woType.ToUpper() == "ROUTINE")
                    {
                        //Rountine
                        services.Add(new WOServices("Routine_Isnp", "routineInspectionFull-v1"));
                    }
                    else if (woType.ToUpper() == "PROPERTY CONDITION REPORT")
                    {
                        //PROPERTY CONDITION REPORT
                        //services.Add(new WOServices("Prop. Cond. Report", "PorpertyConditionReport-v1"));
                    }
                    else if (woType.ToUpper() == "SHORT PCR")
                    {
                        //SHORT PCR
                        //services.Add(new WOServices("Short PCR", "PCRShort-v1"));
                    }
                    else if (woType.ToUpper() == "QUALITY CONTROL")
                    {
                        //QUALITY CONTROL
                        //services.Add(new WOServices("Quality Control", "QalitltyControl-v1"));
                    }
                    woFull[rowIndex].services = services;

                    rowIndex++;
                }
                return new WorkOrderResult(woFull, "");
            }
            else
            {
                WorkOrder[] woFull = null;
                return new WorkOrderResult(woFull, "");
            }
        }
        public WorkOrderResult GetWorkOrdersByVendor(string id)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("UserName", id));
            DataTable wo = dm.DataReturnDataTable("spPruvanWorkOrder_Select", parms);
            if (wo.Rows.Count > 0)
            {
                WorkOrder[] woFull = new WorkOrder[wo.Rows.Count];
                int rowIndex = 0;
                foreach (DataRow dr in wo.Rows)
                {
                    woFull[rowIndex] = new WorkOrder();
                    woFull[rowIndex].workOrderNumber = dr["WorkorderNo"].ToString();
                    woFull[rowIndex].address1 = dr["Address"].ToString();
                    woFull[rowIndex].city = dr["City"].ToString();
                    woFull[rowIndex].state = dr["State"].ToString();
                    woFull[rowIndex].zip = dr["ZipCode"].ToString();
                    woFull[rowIndex].clientStatus = dr["ClientStatus"].ToString();
                    woFull[rowIndex].wostatusid = int.Parse(dr["WorkOrderStatusId"].ToString());
                    woFull[rowIndex].workorderId = int.Parse(dr["WorkorderId"].ToString());
                    woFull[rowIndex].vendorId = int.Parse(dr["VendorId"].ToString());
                    woFull[rowIndex].description = dr["Description"].ToString();
                    woFull[rowIndex].dueDate = dr["DueOn"].ToString();
                    woFull[rowIndex].clientDueDate = dr["DueOn"].ToString();
                    //add default service
                    List<WOServices> services = new List<WOServices>();
                    //generic WO task
                    services.Add(new WOServices("Task"));
                    //check for WO type and add survey(s) accordingly
                    string woType = dr["WOType"].ToString();
                    if (woType.ToUpper() == "HPIR")
                    {
                        //HPIR
                        services.Add(new WOServices("HPIR_Full", "hpirFull-v3"));
                    }
                    else if (woType.ToUpper() == "INITIAL ROUTINE" || woType.ToUpper() == "ROUTINE")
                    {
                        //Rountine
                        services.Add(new WOServices("Routine_Isnp", "routineInspectionFull-v1"));
                    }
                    else if (woType.ToUpper() == "PROPERTY CONDITION REPORT")
                    {
                        //PROPERTY CONDITION REPORT
                        //services.Add(new WOServices("Prop. Cond. Report", "PorpertyConditionReport-v1"));
                    }
                    else if (woType.ToUpper() == "SHORT PCR")
                    {
                        //SHORT PCR
                        //services.Add(new WOServices("Short PCR", "PCRShort-v1"));
                    }
                    else if (woType.ToUpper() == "QUALITY CONTROL")
                    {
                        //QUALITY CONTROL
                        //services.Add(new WOServices("Quality Control", "QalitltyControl-v1"));
                    }
                    woFull[rowIndex].services = services;

                    rowIndex++;
                }
                return new WorkOrderResult(woFull, "");
            }
            else
            {
                WorkOrder[] woFull = null;
                return new WorkOrderResult(woFull, "");
            }
        }
    }
}
