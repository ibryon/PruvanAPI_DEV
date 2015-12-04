using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using PruvanAPI_13.Models;

namespace PruvanAPI_13.Controllers
{
    public class UploadPicturesController : ApiController
    {
        private ServiceLog sl = new ServiceLog();

        [HttpGet]
        public Pictures Get()
        {
            Pictures aPic = new Pictures();
            aPic.username = "ibryon@pkmg.net";
            aPic.password = "test1234";
            aPic.key2 = "5001001";
            aPic.key4 = "Field QC Inspection";
            aPic.attribute1 = "123 Main Street";
            aPic.attribute2 = "123 Main Street";
            aPic.attribute3 = "Doral";
            aPic.attribute4 = "FL";
            aPic.attribute5 = "33126";
            aPic.attribute6 = "USA";
            aPic.creationDate = DateTime.Now.ToShortDateString();
            aPic.fielType = "picture";
            aPic.evidenceType = "Survey";
            return aPic;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            //Get Pictures Object

            string payload = Request.Content.ReadAsStringAsync().Result;
            Pictures pic = new Pictures().GetPicture(payload);

            sl.WriteToLog(new string[] { "------------ LOG ENTRY (UPLOAD PICTURES)------------", "Username: " + pic.username, "Work Order No: " + pic.key2 });
            bool isValid = pic.IsUserValid(pic);
            if (isValid == true)
            {
                LoginMembership utcNow = new LoginMembership().GetMembership(pic.username);
                //check for survey answers
                if (pic.survey != null)
                {
                    sl.WriteToLog(new string[] { "Picture has survey info" });
                    try
                    { 
                        //get all answers
                        List<SurveyAnswer> finalList = pic.GetReturnAnswers(pic.survey);
                        WorkOrder wo = new WorkOrder().GetWorkOrderInfo(pic.key2);
                        
                        if (finalList.Count > 0)
                        {
                            //for testing 
                            //SurveyTest1 h = new SurveyTest1();
                            string tempType = pic.template.Substring(pic.template.IndexOf("::"));
                            tempType = tempType.Substring(2);
                            //for HPIR 
                            if (tempType == "hpirFull-v3")
                            {
                                //add to HPIR obj for saving
                                SurveyHPIR h = new SurveyHPIR();
                                foreach (SurveyAnswer a in finalList)
                                {
                                    var propertyInfo = h.GetType().GetProperty(a.id);
                                    if (propertyInfo != null)
                                    {
                                        try
                                        {   //as string
                                            propertyInfo.SetValue(h, a.answer);
                                        }
                                        catch
                                        {
                                            try
                                            {   //as DateTime
                                                propertyInfo.SetValue(h, DateTime.Parse(a.answer.ToString()));
                                            }
                                            catch
                                            {
                                                try
                                                {   //as int
                                                    propertyInfo.SetValue(h, int.Parse(a.answer.ToString()));
                                                }
                                                catch
                                                {
                                                    try
                                                    {   //as char
                                                        char shortAnswer = 'N';
                                                        if (a.answer.ToString().ToUpper() == "YES" || a.answer.ToString().ToUpper() == "Y") shortAnswer = 'Y';
                                                        propertyInfo.SetValue(h, shortAnswer);
                                                    }
                                                    catch (Exception exx)
                                                    {
                                                        sl.WriteToLog(new string[] { "ID: " + a.id, "ANS: " + a.answer, exx.Message });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                h.SaveHPIR(h, utcNow.UserId, wo.workorderId);
                            }
                            //For Rountine Inspection
                            else if(tempType == "routineInspectionFull-v1")
                            {
                                SurveyRoutine h = new SurveyRoutine();
                                foreach (SurveyAnswer a in finalList)
                                {
                                    var propertyInfo = h.GetType().GetProperty(a.id);
                                    if (propertyInfo != null)
                                    {
                                        try
                                        {   //as string
                                            propertyInfo.SetValue(h, a.answer);
                                        }
                                        catch
                                        {
                                            try
                                            {   //as DateTime
                                                propertyInfo.SetValue(h, DateTime.Parse(a.answer.ToString()));
                                            }
                                            catch
                                            {
                                                try
                                                {   //as int
                                                    propertyInfo.SetValue(h, int.Parse(a.answer.ToString()));
                                                }
                                                catch
                                                {
                                                    try
                                                    {   //as char
                                                        char shortAnswer = 'N';
                                                        if (a.answer.ToString().ToUpper() == "YES" || a.answer.ToString().ToUpper() == "Y") shortAnswer = 'Y';
                                                        propertyInfo.SetValue(h, shortAnswer);
                                                    }
                                                    catch (Exception exx)
                                                    {
                                                        sl.WriteToLog(new string[] { "Error saving answer: " + a.id + " : " + a.answer, exx.Message });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                h.SaveRoutine(h, utcNow.UserId, wo.workorderId);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        sl.WriteToLog(new string[] { "Error processing survey object: ", ex.Message });
                    }
                }
                sl.WriteToLog(new string[] { "Picture has NO survey info" });
                //get image folder path
                string StoragePath = pic.GetImagePath(pic);
                //Save Picture Info
                string ImageName = pic.SavePicture(pic, utcNow.UserId);
                string ImageNameThumb = ImageName + ".large-thumb.jpg";
                ImageName = ImageName + ".jpg";
                sl.WriteToLog(new string[] { "Picture JSON Object is Valid and Saved", "Image Name: " + ImageName });
                //Get Image and save
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new MultipartFormDataStreamProvider(Path.Combine(StoragePath));
                    await Request.Content.ReadAsMultipartAsync(streamProvider);
                    foreach (MultipartFileData fileData in streamProvider.FileData)
                    {
                        if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                        {
                            sl.WriteToLog(new string[] { "Request not properly formatted", "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                            PicturesResponse pr1 = new PicturesResponse(false, "This request is not properly formatted");
                            var response1 = Request.CreateResponse<PicturesResponse>(System.Net.HttpStatusCode.NotAcceptable, pr1);
                            return response1;
                        }
                        File.Move(fileData.LocalFileName, Path.Combine(StoragePath, ImageName));
                        File.Copy(StoragePath + ImageName, StoragePath + ImageNameThumb);
                        pic.fileName = ImageName;
                    }
                    sl.WriteToLog(new string[] { "Image is Valid and Saved", "Image Name: " + pic.fileName, "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    PicturesResponse pr = new PicturesResponse(true, "");
                    var response = Request.CreateResponse<PicturesResponse>(System.Net.HttpStatusCode.OK, pr);
                    return response;
                }
                else
                {
                    sl.WriteToLog(new string[] { "Image not Valid", "Image Name: " + pic.fileName, "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                    PicturesResponse pr = new PicturesResponse(false, "This request is not properly formatted");
                    var response = Request.CreateResponse<PicturesResponse>(System.Net.HttpStatusCode.NotAcceptable, pr);
                    return response;
                }
            }
            else
            {
                sl.WriteToLog(new string[] { "invalid username or password", "User Name: " + pic.username, "------------ LOG ENTRY END (" + DateTime.Now.ToShortTimeString() + ")------------", "" });
                PicturesResponse pr = new PicturesResponse(false, "invalid username or password");
                var response = Request.CreateResponse<PicturesResponse>(System.Net.HttpStatusCode.Unauthorized, pr);
                return response;
            }
        }
    }
}