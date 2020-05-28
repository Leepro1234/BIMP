using BIMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BIMP.Controllers
{
    public class CompanyController : Controller
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("654374778:AAGxy-Q6JNx7eEbWzZnnU5uW8pVuvQ44_9E");

        // GET: Schedule
        public ActionResult Company001MA(int? page)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var db = new MainDbContext();
            var returnData = from s in db.Companys
                             orderby s.COMPANY_NO
                             select s;
            
            
            return View(returnData.ToPagedList(pageNumber,pageSize));
        }


        [HttpGet]
        public ActionResult Company001PA()
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            string Referrer = Request.UrlReferrer.ToString();
            if(Referrer== "http://localhost:55875/Schedule/Schedule001PA")
            {
                return new System.Web.Mvc.EmptyResult();
            }
   
            ViewBag.isJob = "Create";

            return View();
        }

        [HttpPost]
        public string BatchCompany001PA(Companys companys)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }

            using (var db = new MainDbContext())
            {
                var p_companys = db.Companys.Create();
                p_companys.COMPANY_NM = companys.COMPANY_NM;
                p_companys.COMPANY_PHONE = companys.COMPANY_PHONE;
                p_companys.COMPANY_STATUS = "Y";
                db.Companys.Add(p_companys);
                db.SaveChanges();
            }

            ChatId ChatId = new ChatId(295219317);
            myGlobals.Bot.SendTextMessageAsync(ChatId, companys.COMPANY_NM + "업체가 추가되었습니다");
            return "success";
        }

        public ActionResult Company001PB()
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Company001PB(string companyNo)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var db = new MainDbContext();
            return View(db.Companys.Where(r => r.COMPANY_NO.ToString() == companyNo).ToList());
        }

        public ActionResult Company001PC(string companyNo)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }
            var db = new MainDbContext();
            Companys companys= db.Companys.Where(r => r.COMPANY_NO.ToString() == companyNo).Single();
            return View(companys);
        }

        [HttpPost]
        public void Company001PC(Companys company)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
               RedirectToAction("Login", "Auth");
            }
            int companyNo = int.Parse(Request.Form["companyNo"]);
            using (var db = new MainDbContext())
            {
                 var originalSchedule = db.Companys.SingleOrDefault(r => r.COMPANY_NO == company.COMPANY_NO);
                if (originalSchedule != null)
                {
                    try
                    {
                        originalSchedule.COMPANY_NM = company.COMPANY_NM;
                        originalSchedule.COMPANY_PHONE = company.COMPANY_PHONE;
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;

                    }
                }
                ViewBag.isJob = "Success";
            }
        }


        [HttpPost]
        public ActionResult CompanyList(object data)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var db = new MainDbContext();
            return RedirectToAction("Company001MA");
        }
    }
}