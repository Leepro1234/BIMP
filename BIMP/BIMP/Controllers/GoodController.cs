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
    public class GoodController : Controller
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("654374778:AAGxy-Q6JNx7eEbWzZnnU5uW8pVuvQ44_9E");

        // GET: Schedule
        public ActionResult Good001MA(int? page)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var db = new MainDbContext();
            var returnData = from s in db.Goods
                             orderby s.GOODS_NO
                             select s;
            
            
            return View(returnData.ToPagedList(pageNumber,pageSize));
        }


        [HttpGet]
        public ActionResult Good001PA()
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
        public string BatchGoods001PA(Goods good)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }

            using (var db = new MainDbContext())
            {
                var p_Goods = db.Goods.Create();
                p_Goods.GOODS_NM = good.GOODS_NM;
                p_Goods.STYLE = good.GOODS_NM;
                p_Goods.COLOR = (good.COLOR == null) ? "" : good.COLOR;
                p_Goods.SIZE = (good.SIZE == null) ? "" : good.SIZE;
                db.Goods.Add(p_Goods);
                db.SaveChanges();
            }

            ChatId ChatId = new ChatId(295219317);
            myGlobals.Bot.SendTextMessageAsync(ChatId, good.GOODS_NM+ "\n 상품이 추가되었습니다");
            return "success";
        }

        public ActionResult Good001PB()
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Good001PB(string GoodsNo)
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var db = new MainDbContext();
            return View(db.Goods.Where(r => r.GOODS_NO.ToString() == GoodsNo).ToList());
        }

        public ActionResult Good001PC(string GoodsNo)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");

            }
            var db = new MainDbContext();
            Goods goods = db.Goods.Where(r => r.GOODS_NO.ToString() == GoodsNo).Single();
            return View(goods);
        }

        [HttpPost]
        public void Good001PC(Goods goods)
        {
            string userNo = (string)Session["User_No"];

            if (userNo == null)
            {
               RedirectToAction("Login", "Auth");
            }
            int goodsNo = int.Parse(Request.Form["goodsNo"]);
            using (var db = new MainDbContext())
            {
                 var originalSchedule = db.Goods.SingleOrDefault(r => r.GOODS_NO== goods.GOODS_NO);
                if (originalSchedule != null)
                {
                    try
                    {
                        originalSchedule.GOODS_NM = goods.GOODS_NM;
                        originalSchedule.STYLE = goods.GOODS_NM;
                        originalSchedule.COLOR = goods.COLOR;
                        originalSchedule.SIZE = goods.SIZE;
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
        public ActionResult GoodList(object data)
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