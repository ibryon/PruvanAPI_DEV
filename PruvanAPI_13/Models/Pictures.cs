using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PruvanAPI_13.Models
{
    public class Pictures
    {
        //PruvanAPI_13.Models
        private ServiceLog sl = new ServiceLog();
        public Pictures() { }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string pictureId { get; set; }
        public string key1 { get; set; }
        public string key2 { get; set; }
        public string key3 { get; set; }
        public string key4 { get; set; }
        public string key5 { get; set; }
        public string attribute1 { get; set; }
        public string attribute2 { get; set; }
        public string attribute3 { get; set; }
        public string attribute4 { get; set; }
        public string attribute5 { get; set; }
        public string attribute6 { get; set; }
        public string fileExt { get; set; }
        public string fileName { get; set; }
        public string fielType { get; set; }
        public string batchId { get; set; }
        public string clientCode { get; set; }
        public string createdBy { get; set; }
        public string createdBySubUser { get; set; }
        public string survey { get; set; }
        public string status { get; set; }
        public string template { get; set; }
        public string uploaderVersion { get; set; }
        public string uuId { get; set; }
        public string workDay { get; set; }
        public string surveyId { get; set; }
        public string notes { get; set; }
        public string authenticated { get; set; }
        public string csrCertifiedLocation { get; set; }
        public string csrCertifiedTime { get; set; }
        public string csrLocationSource { get; set; }
        public string csrPictureCount { get; set; }
        public string csrTimeStampSource { get; set; }
        public string locationDifference { get; set; }
        public string gpsAccuracy { get; set; }
        public string gpsLatitude { get; set; }
        public string gpsLongitude { get; set; }
        public string gpsTimestamp { get; set; }
        public string creationDate { get; set; }
        public string parameters { get; set; }
        public string parentUuid { get; set; }
        public string phoneNumber { get; set; }
        public string deviceId { get; set; }
        public string lastUpdatedBy { get; set; }
        public string evidenceType { get; set; }
        public string fileType { get; set; }
        public string timestamp { get; set; }
        public int propertyId { get; set; }
        public int appId { get; set; }
        public Pictures GetPicture(string pic)
        {
            try
            {
                //for testing only
                //sl.WriteToLog(new string[] { "(Full Package from Pruvan) -- ", pic });

                int StartIndex = pic.IndexOf('{');
                string test2 = pic.Substring(StartIndex);
                int EndIndex = test2.IndexOf('}');
                EndIndex++;
                string test3 = test2.Substring(0, EndIndex);
                return JsonConvert.DeserializeObject<Pictures>(test3);
            }
            catch
            {
                //remove survey
                int surveyStart = pic.IndexOf("\"survey\":{");
                int surveyEnd = pic.IndexOf("[]}]}");
                surveyEnd = surveyEnd + 5 - surveyStart;
                string survey = pic.Substring(surveyStart, surveyEnd);

                //genarate generic JSON
                surveyEnd = pic.IndexOf("[]}]}");
                surveyEnd = surveyEnd + 5;
                int StartIndex = pic.IndexOf('{');
                int EndIndex = pic.LastIndexOf('}');
                string begReg = pic.Substring(StartIndex, surveyStart);
                string endReg = pic.Substring(surveyEnd);
                int EndIndex2 = endReg.IndexOf('}');
                EndIndex2++;
                string endReg2 = endReg.Substring(0, EndIndex2);
                string finalJson = begReg + "\"survey\":\" \"" + endReg2;
                //serialize and return Pictures Object
                Pictures tempPic = JsonConvert.DeserializeObject<Pictures>(finalJson);
                tempPic.survey = survey;
                return tempPic;
            }
        }
        public string SavePicture(Pictures aPic, Guid createdBy)
        {
            try
            {
                WorkOrder wo = new WorkOrder().GetWorkOrderInfo(aPic.key2);
                if (wo != null)
                {
                    DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDEV"].ConnectionString);
                    List<SqlParameter> parms = new List<SqlParameter>();
                    //update each wo
                    parms.Add(new SqlParameter("DocumentTypeId", 32));
                    parms.Add(new SqlParameter("PropertyId", wo.PropID));
                    parms.Add(new SqlParameter("WorkorderId", wo.workorderId));
                    parms.Add(new SqlParameter("ContactId", 1));
                    parms.Add(new SqlParameter("EntityId", 1));
                    parms.Add(new SqlParameter("VendorId", wo.vendorId));
                    parms.Add(new SqlParameter("OriginalFileName", aPic.fileName));
                    parms.Add(new SqlParameter("Extension", ".jpg"));
                    parms.Add(new SqlParameter("MimeType", "image/jpeg"));
                    parms.Add(new SqlParameter("Size", 100));
                    parms.Add(new SqlParameter("Description", ""));
                    parms.Add(new SqlParameter("MetaData", "Latitude: " + aPic.gpsLatitude + " , Longitude: " + aPic.gpsLongitude + " , GPS Time: " + aPic.gpsTimestamp + " , GPS Accuracy: " + aPic.gpsAccuracy));
                    parms.Add(new SqlParameter("IsMain", 'N'));
                    parms.Add(new SqlParameter("IsUploadable", 'Y'));
                    parms.Add(new SqlParameter("UploadedOn", DateTime.Now));
                    parms.Add(new SqlParameter("SortOn", DateTime.Now));
                    parms.Add(new SqlParameter("CreatedBy", createdBy));
                    parms.Add(new SqlParameter("CreatedOn", aPic.creationDate));
                    //dm.ExecuteNonQuery("spCslaDocument_Insert", parms);

                    DataTable dt = dm.DataReturnDataTable("spPruvanDocument_Insert", parms);
                    sl.WriteToLog(new string[] { "New Document Added: " + dt.Rows[0][0].ToString() +  " , FileName: " + aPic.fileName });
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                sl.WriteToLog(new string[] { "Error: " + ex.Message });
                return null;
            }
        }
        public bool IsUserValid(Pictures user)
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
        public bool IsUserValid2(Pictures user)
        {
            //does not use default ASP.NET Identity Framework, uses VDS logic
            bool returnBool = false;
            LoginMembership utcNow = new LoginMembership().GetMembership(user.username);
            if (utcNow != null)
            {
                if (LoginHelper.Hash(utcNow.PasswordSalt, user.password) == utcNow.Password)
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }
        public string GetImagePath(Pictures aPic) 
        {
            sl.WriteToLog(new string[] { "Get Image Path Starting..." });
            string ImagePath = string.Empty;
            WorkOrder wo = new WorkOrder().GetWorkOrderInfo(aPic.key2);
            if (wo != null)
            {

                ImagePath = wo.GetDocumentRootPath(int.Parse(wo.AppID)) + @"Property\" + wo.GetPropertyDocFolder(int.Parse(wo.PropID)) + @"\" + wo.PropID.ToString() + @"\";
                sl.WriteToLog(new string[] { "Image Path:", ImagePath });
                if (!Directory.Exists(ImagePath))
                {
                    try
                    {
                        Directory.CreateDirectory(ImagePath);
                    }
                    catch (Exception ex)
                    {
                        sl.WriteToLog(new string[] { "Error Trying to Create folder: " + ex.Message });
                    }
                }
                return ImagePath;
            }
            else
            {
                sl.WriteToLog(new string[] { "Work Order IS Null: " + aPic.key2 });
                return null;
            }
        }
        public List<SurveyAnswer> GetReturnAnswers(string allAnswers)
        {
            List<SurveyAnswer> answerList = new List<SurveyAnswer>();
            int StartIndex = allAnswers.IndexOf("answers");
            StartIndex += 10;
            string OnlyAnswerResults = allAnswers.Substring(StartIndex);
            string[] splitBy = new string[] { "{\"id\":" };
            string[] splitResults = OnlyAnswerResults.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
            int AnswerCount = splitResults.Length;

            foreach (string s in splitResults)
            {
                try
                {
                    //string temp = s.Substring(0, s.Length - 2);
                    string temp = s;
                    temp = "{\"id\":" + temp;
                    temp = temp.Replace("]", "");
                    temp = temp.Replace("[", "");
                    int AnsOptIndex = temp.IndexOf("answerOptions");
                    AnsOptIndex = AnsOptIndex - 2;
                    temp = temp.Substring(0, AnsOptIndex);
                    temp = temp + "}";
                    try
                    {
                        answerList.Add(JsonConvert.DeserializeObject<SurveyAnswer>(temp));
                    }
                    catch
                    {
                        int IndexAnswerStart = temp.IndexOf("\"answer\":");
                        int IndexAnswerEnd = temp.IndexOf("\"hint\":");
                        IndexAnswerStart = IndexAnswerStart + 9;
                        IndexAnswerEnd = IndexAnswerEnd - IndexAnswerStart;
                        string startJSON = temp.Substring(0, IndexAnswerStart);

                        //split here for JSON string generation
                        //string[] allOptions = 


                        string onlyAnswers = temp.Substring(IndexAnswerStart, IndexAnswerEnd);
                        string finalJson = startJSON + onlyAnswers.Replace(",", string.Empty) + "}";
                        finalJson = finalJson.Replace("\"\"", ",");


                        answerList.Add(JsonConvert.DeserializeObject<SurveyAnswer>(finalJson));
                    }
                }
                catch (Exception ex)
                {
                    sl.WriteToLog(new string[] { "Error converting survey answer: " + s, ex.Message, });
                }
            }
            return answerList;
        }
    }
}