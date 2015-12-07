using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruvanAPI_13.Models
{
    public class WorkOrder
    {
        private ServiceLog sl = new ServiceLog();
        public WorkOrder() { }
        public string workOrderNumber { get; set; }
        public int workorderId { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string status { get; set; }
        public string clientStatus { get; set; }
        public int wostatusid { get; set; }
        public string attribute7 { get; set; }
        public string AppID { get; set; }
        public string PropID { get; set; }
        public int vendorId { get; set; }
        public string description { get; set; }
        public string dueDate { get; set; }
        public string clientDueDate { get; set; }
        public List<WOServices> services { get; set; }
        public bool UpdateWorkOrder(WorkOrder[] wo)
        {
            if(wo.Length>0)
            {
                DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
                foreach (WorkOrder w in wo)
                {
                    List<SqlParameter> parms = new List<SqlParameter>();
                    //update each wo
                    parms.Add(new SqlParameter("WorkorderNo", w.workOrderNumber));
                    parms.Add(new SqlParameter("NewStatus", w.status));
                    sl.WriteToLog(new string[] { w.workOrderNumber + "-Status changed to: " + w.status });
                    dm.ExecuteNonQuery("spPruvanWorkOrder_Update", parms);
                    sl.WriteToLog(new string[] { w.workOrderNumber + "-Status Updated Successfully " });
                }
                return true;
            }
            else { return false; }
        }
        public WorkOrder[] GetSampleDate()
        {
            WorkOrder[] woList = new WorkOrder[3];
            WOServices wos = new WOServices() { serviceName = "Task" };
            List<WOServices> wList = new List<WOServices>();
            wList.Add(wos);
            WorkOrder wo1 = new WorkOrder { workOrderNumber = "0123456789", address1 = "111 NW 1 ST", city = "DORAL", state = "FL", zip = "33166", services = wList };
            WorkOrder wo2 = new WorkOrder { workOrderNumber = "1234567890", address1 = "112 NW 2 ST", city = "DORAL", state = "FL", zip = "33166", services = wList };
            WorkOrder wo3 = new WorkOrder { workOrderNumber = "2345678901", address1 = "113 NW 3 ST", city = "DORAL", state = "FL", zip = "33166", services = wList };
            woList[0] = wo1;
            woList[1] = wo2;
            woList[2] = wo3;
            return woList;
        }
        public WorkOrder GetWorkOrderInfo(string wo_num)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("WorkorderNo", wo_num));
            DataTable dt = dm.DataReturnDataTable("spPruvanWorkOrderInfo_Select", parms);
            if (dt.Rows.Count > 0)
            {
                WorkOrder w = new WorkOrder();
                w.workOrderNumber = dt.Rows[0]["WorkorderNo"].ToString();
                w.AppID = dt.Rows[0]["AcAppId"].ToString();
                w.PropID = dt.Rows[0]["PropertyId"].ToString();
                w.clientStatus = dt.Rows[0]["WorkOrderStatusId"].ToString();
                w.wostatusid = int.Parse(dt.Rows[0]["WorkOrderStatusId"].ToString());
                w.vendorId = int.Parse(dt.Rows[0]["VendorId"].ToString());
                w.workorderId = int.Parse(dt.Rows[0]["WorkorderId"].ToString());

                return w;
            }
            else return null;
        }
        public string GetDocumentRootPath(int AppId)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("AcAppId", AppId));
            DataTable dt = dm.DataReturnDataTable("spCslaDocumentRootPath_Select", parms);
            if (dt.Rows.Count > 0)
            {
                //return dt.Rows[0]["WebPath"].ToString();
                string pPath = dt.Rows[0]["PhysicalPath"].ToString();
                sl.WriteToLog(new string[] { "Document Physical Path: ", pPath });
                return pPath;
            }
            else return null;
        }
        public string GetPropertyDocFolder(int propId)
        {
            string returnPath = String.Format("{0}-{1}", propId < 1000 ? "0" : (Math.Round((Convert.ToDouble(propId) - 500) / 1000) * 1000 + 1).ToString(), (Math.Round((Convert.ToDouble(propId) + 500) / 1000) * 1000).ToString());
            sl.WriteToLog(new string[] { "Document Folder: ", returnPath });
            return returnPath;
        }
    }
}