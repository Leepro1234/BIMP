using BIMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BIMP.Controllers
{
    public class HomeController : Controller
    {
        string timeToday = DateTime.Now.ToString("h:mm:ss tt");
        string dateToday = DateTime.Now.ToString("M/dd/yyyy");

        // GET: Home

        public ActionResult Index()
        {
            string userNo = (string)Session["User_No"];
            if (userNo == null)
            {
                RedirectToAction("Login", "Auth");
            }
            // var db = new MainDbContext();
            return View(); //db.Lists.ToList());
        }

        [HttpPost]
        public ActionResult Index(string a)//Lists list)
        {
            //if (ModelState.IsValid)
            //{
            //    using (var db = new MainDbContext())
            //    {
            //        string check_public = Request.Form["check_public"];
            //        string new_item = Request.Form["new_item"];
            //        Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
            //        string userEmail = sessionEmail.Value;
            //        var userNo = db.users.Where(u => u.MAIL == userEmail).Select(u => u.USER_NO).ToList();
            //        var dbList = db.Lists.Create();
            //        dbList.Details = new_item;
            //        dbList.Date_Posted = dateToday;
            //        dbList.Time_Posted = timeToday;
            //        dbList.USER_NO = int.Parse(userNo[0].ToString());

            //        if (check_public != null) { dbList.Public = "YES"; }
            //        else { dbList.Public = "NO"; }
            //        db.Lists.Add(dbList);
            //        db.SaveChanges();
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Incoorect format has been placed!!!");
            //}
            //var listTable = new MainDbContext();

            return View();//listTable.Lists.ToList());
        }
    }
}