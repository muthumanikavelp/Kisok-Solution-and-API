using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;
using nafservice;
using static nafmodel.Kiosk_FAQS_Model;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Kiosk_FAQSController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        Kiosk_FAQS_Service objRoleService = new Kiosk_FAQS_Service();
        public Kiosk_FAQSController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [Authorize]
        [HttpGet("FAQSCatList")]
        public FAQSCategoryContext FAQSCategoryList(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FAQSCategoryContext ObjList = new FAQSCategoryContext();
            try
            {
                ObjList = objRoleService.GetFAQSCatList(org, locn, user, lang, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("FAQSQuestion")]
        public FAQSQuestionContext FAQSQuestion(string org, string locn, string user, string lang, int In_faqscat_Id,string Keyword)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_faqscat_Id);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FAQSQuestionContext ObjList = new FAQSQuestionContext();
            try
            {
                ObjList = objRoleService.GetFAQSQuestions(org, locn, user, lang, In_faqscat_Id, ConString, Keyword);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("FAQSAnswers")]
        public FAQSAnswersContext FAQSAnswers(string org, string locn, string user, string lang, int In_faq_gid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(In_faq_gid);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FAQSAnswersContext ObjList = new FAQSAnswersContext();
            try
            {
                ObjList = objRoleService.GetFAQSAnswers(org, locn, user, lang, In_faq_gid, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpGet("FAQSList")]
        public FAQSListContext FAQSList(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FAQSListContext ObjList = new FAQSListContext();
            try
            {
                ObjList = objRoleService.GetFAQSList(org, locn, user, lang, ConString);


            }
            catch (Exception ex)
            {
                //   logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [Authorize]
        [HttpPost("FAQSsave")]
        public string[] newsoilcardsave(SaveFAQS ObjModel)
        {
            string db = ObjModel.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel);

            try
            {
                response = objRoleService.NewFAQSsave_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return response;
        }

    }
}
