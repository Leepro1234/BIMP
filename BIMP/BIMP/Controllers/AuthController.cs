using BIMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using BIMP.CustomLibraries;

namespace BIMP.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users model)
        {
            using (var db = new MainDbContext())
            {
                var IdCheck = db.users.FirstOrDefault(u => u.USER_ID == model.USER_ID);
                var getPassword = db.users.Where(u => u.USER_ID == model.USER_ID).Select(u => u.PASSWORD);

                var materializePassword = getPassword.ToList();
                string password = materializePassword[0];
                var decryptedPassword = CustomDecrypt.Decrypt(password);

                var getUserNo = db.users.Where(u => u.USER_ID == model.USER_ID).Select(u => u.USER_NO).ToList();
                string userNo = getUserNo[0].ToString();


                if (model.USER_ID != null && model.PASSWORD == decryptedPassword)
                {
                    Session["id"] = model.USER_ID;
                    Session["User_No"] = userNo;
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,"Daeyong"),
                    new Claim(ClaimTypes.Email,"dlthfyd119@naver.com"),
                    new Claim(ClaimTypes.Country,"Seoul")
                }, "ApplicationCookie");

                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);

                    ViewBag.Result = "Success";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Result = "False";
                    return View(model);
                }
            }
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "auth");

        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(users model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MainDbContext())
                {
                    {
                        var encryptedPassword = CustomEncrypt.Encrypt(model.PASSWORD);
                        var user = db.users.Create();
                        user.USER_NO = model.USER_NO;
                        user.USER_ID = model.USER_ID;
                        user.PASSWORD = encryptedPassword;
                        user.COUNTRY = model.COUNTRY;
                        user.NAME = model.NAME;
                        user.MAIL = model.MAIL;
                        user.USER_STATUS = "A10";
                        db.users.Add(user);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Login", "auth");
                }
            }
            else
            {
                ModelState.AddModelError("", "One or more fields have been");
            }

            return View();
        }
    }
}