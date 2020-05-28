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
    public class SaleController : Controller
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("654374778:AAGxy-Q6JNx7eEbWzZnnU5uW8pVuvQ44_9E");

        // GET: Schedule
        public ActionResult Sale001MA(int? page)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var db = new MainDbContext();
            var returnData = from s in db.Sales
                             join c in db.Companys on s.COMPANY_NO equals c.COMPANY_NO
                             join d in db.Goods on s.GOODS_NO equals d.GOODS_NO
                             orderby s.SALE_NO
                             select new SalesModel
                             {
                                 SALE_NO = s.SALE_NO,
                                 COMPANY_NO= s.COMPANY_NO,
                                 GOODS_NO= s.GOODS_NO,
                                 COMPANY_NM = c.COMPANY_NM,
                                 GOODS_NM = d.GOODS_NM,
                                 QTY = s.QTY,
                                 PRICE = s.PRICE,
                                 SALEAMT = s.SALEAMT
                             };


            return View(returnData.ToPagedList(pageNumber,pageSize));
        }


        [HttpGet]
        public ActionResult Sale001PA()
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
            var db = new MainDbContext();
            ViewBag.ComapnysSelect = new SelectList(db.Companys, "COMPANY_NO", "COMPANY_NM");
            ViewBag.GoodsSelect = new SelectList(db.Goods, "GOODS_NO", "GOODS_NM");

            ViewBag.isJob = "Create";

            return View();
        }

        [HttpPost]
        public string BatchSales001PA(Sales Sale)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }

            using (var db = new MainDbContext())
            {
                var p_Sales = db.Sales.Create();
                p_Sales.COMPANY_NO = Sale.COMPANY_NO;
                p_Sales.GOODS_NO = Sale.GOODS_NO;
                p_Sales.PRICE = Sale.PRICE;
                p_Sales.QTY = Sale.QTY;
                p_Sales.SALEAMT = (int.Parse(Sale.PRICE)* int.Parse(Sale.QTY)).ToString();
                p_Sales.COLLECTAMT = Sale.COLLECTAMT;
                p_Sales.SALEGU = Sale.SALEGU;
                p_Sales.REGISTER = (string)Session["User_ID"];
                p_Sales.RGSDT = Sale.RGSDT.ToString().Replace("-","");
                p_Sales.UPDUSR = (string)Session["User_ID"];
                p_Sales.UPDDT = DateTime.Now.ToString("yyyyMMdd");
                p_Sales.RTNYN = (Sale.RTNYN=="판매")?"N":"Y";
                db.Sales.Add(p_Sales);
                db.SaveChanges();
            }

            ChatId ChatId = new ChatId(295219317);
            myGlobals.Bot.SendTextMessageAsync(ChatId, Sale.SALE_NO+ "\n 매출이 추가되었습니다");
            return "success";
        }

        public ActionResult Sale001PB()
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Sale001PB(string SalesNo)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var db = new MainDbContext();
            return View(db.Sales.Where(r => r.SALE_NO.ToString() == SalesNo).ToList());
        }

        public ActionResult Sale001PC(string SalesNo)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");

            }
            var db = new MainDbContext();
            Sales Sales = db.Sales.Where(r => r.SALE_NO.ToString() == SalesNo).Single();
            return View(Sales);
        }

        [HttpPost]
        public void Sale001PC(Sales Sales)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
               RedirectToAction("Login", "Auth");
            }
            int SalesNo = int.Parse(Request.Form["SalesNo"]);
            using (var db = new MainDbContext())
            {
                 var originalSchedule = db.Sales.SingleOrDefault(r => r.SALE_NO== Sales.SALE_NO);
                if (originalSchedule != null)
                {
                    try
                    {
                        //originalSchedule.SaleS_NM = Sales.SALE_NO;
                        //originalSchedule.STYLE = Sales.SaleS_NM;
                        //originalSchedule.COLOR = Sales.COLOR;
                        //originalSchedule.SIZE = Sales.SIZE;
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
        public ActionResult SaleList(object data)
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