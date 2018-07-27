using BIMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace BIMP.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Schedule001MA(int? page)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var db = new MainDbContext();
            var returnData = from s in db.Schedules
                             orderby s.START_DT.Substring(0,10)
                             select s;
            
            
            return View(returnData.ToPagedList(pageNumber,pageSize));
        }


        [HttpGet]
        public ActionResult Schedule001PA()
        {
            string Referrer = Request.UrlReferrer.ToString();
            if(Referrer== "http://localhost:55875/Schedule/Schedule001PA")
            {
                return new System.Web.Mvc.EmptyResult();
            }
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                ViewBag.Message = "false";
            }
            ViewBag.isJob = "Create";

            return View();
        }

        [HttpPost]
        public string BatchSchedule001PA(schedules schedules)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }

            using (var db = new MainDbContext())
            {
                string startTime = Request.Form["start_time"];
                var schedule = db.Schedules.Create();
                schedule.ORDER_NAME = schedules.ORDER_NAME;
                schedule.ORDER_PHONE = schedules.ORDER_PHONE;
                schedule.RGSDT = DateTime.Now.ToString("yyyyMMdd");
                schedule.START_DT = schedules.START_DT + startTime;
                schedule.SCHEDULE_CONTENTS = schedules.SCHEDULE_CONTENTS;
                schedule.SEATER = schedules.SEATER;
                schedule.DRIVER_NAME = schedules.DRIVER_NAME;
                schedule.DIVER_CAR_NUMBER = schedules.DIVER_CAR_NUMBER;
                schedule.CAR_PRICE = schedules.CAR_PRICE;
                schedule.DISPATCH_PRICE = schedules.DISPATCH_PRICE;
                schedule.DEPOSIT = schedules.DEPOSIT;
                schedule.DEPOSIT_DT = schedules.DEPOSIT_DT;
                schedule.BILLING_GU = schedules.BILLING_GU;
                schedule.FULL_AMOUNT_YN = schedules.FULL_AMOUNT_YN;
                schedule.FULL_AMOUNT_DT = schedules.FULL_AMOUNT_DT;
                schedule.DRIVER_AMOUNT_YN = schedules.DRIVER_AMOUNT_YN;
                schedule.DRIVER_AMOUNT_DT = schedules.DRIVER_AMOUNT_DT;
                schedule.REMARK = schedules.REMARK;
                schedule.USER_NO = int.Parse(Session["User_No"].ToString());
                schedule.SCHEDULE_STASUS = "A10";
                db.Schedules.Add(schedule);
                db.SaveChanges();
            }
            return "success";
        }

        public ActionResult Schedule001PB()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Schedule001PB(string schedule_no)
        {
            var db = new MainDbContext();
            return View(db.Schedules.Where(r => r.SCHEDULE_NO.ToString() == schedule_no).ToList());
        }

        public ActionResult Schedule001PC(string schedule_no)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }
            var db = new MainDbContext();
            schedules schedules = db.Schedules.Where(r => r.SCHEDULE_NO.ToString() == schedule_no).Single();
            int timeLength = schedules.START_DT.Length;
            ViewBag.Time = schedules.START_DT.Substring(10, timeLength - 10);
            schedules.START_DT = schedules.START_DT.Substring(0, 10) ;
            return View(schedules);
        }

        [HttpPost]
        public void Schedule001PC(schedules schedules)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
               RedirectToAction("Login", "Auth");
            }
            string startTime = Request.Form["start_time"];
            int schedule_no = int.Parse(Request.Form["schedule_no"]);
            using (var db = new MainDbContext())
            {
                 var originalSchedule = db.Schedules.SingleOrDefault(r => r.SCHEDULE_NO == schedules.SCHEDULE_NO);
                if (originalSchedule != null)
                {
                    try
                    {
                        originalSchedule.ORDER_NAME = schedules.ORDER_NAME;
                        originalSchedule.ORDER_PHONE = schedules.ORDER_PHONE;
                        originalSchedule.RGSDT = DateTime.Now.ToString("yyyyMMdd");
                        originalSchedule.START_DT = schedules.START_DT + startTime;
                        originalSchedule.SCHEDULE_CONTENTS = schedules.SCHEDULE_CONTENTS;
                        originalSchedule.SEATER = schedules.SEATER;
                        originalSchedule.DRIVER_NAME = schedules.DRIVER_NAME;
                        originalSchedule.DIVER_CAR_NUMBER = schedules.DIVER_CAR_NUMBER;
                        originalSchedule.CAR_PRICE = schedules.CAR_PRICE;
                        originalSchedule.DISPATCH_PRICE = schedules.DISPATCH_PRICE;
                        originalSchedule.DEPOSIT = schedules.DEPOSIT;
                        originalSchedule.DEPOSIT_DT = schedules.DEPOSIT_DT;
                        originalSchedule.BILLING_GU = schedules.BILLING_GU;
                        originalSchedule.FULL_AMOUNT_YN = schedules.FULL_AMOUNT_YN;
                        originalSchedule.FULL_AMOUNT_DT = schedules.FULL_AMOUNT_DT;
                        originalSchedule.DRIVER_AMOUNT_YN = schedules.DRIVER_AMOUNT_YN;
                        originalSchedule.DRIVER_AMOUNT_DT = schedules.DRIVER_AMOUNT_DT;
                        originalSchedule.REMARK = schedules.REMARK;
                        originalSchedule.USER_NO = int.Parse(Session["User_No"].ToString());
                        originalSchedule.SCHEDULE_STASUS = "A10";


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
        public ActionResult ScheduleList(object data)
        {
            var db = new MainDbContext();
            return RedirectToAction("Schedule001MA");
        }
    }
}