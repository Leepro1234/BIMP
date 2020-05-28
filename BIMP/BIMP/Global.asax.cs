using BIMP.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using BIMP;
using Telegram.Bot;
using System.Web.Http;

namespace BIMP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string _WebApiPrefix = "api";
        private static string _WebApiExecutionPath = String.Format("~/{0}", _WebApiPrefix);
        protected void Application_Start()
        {
            Database.SetInitializer<MainDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        private static bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(_WebApiExecutionPath);
        }

    }

    public class myGlobals
    {
        public static readonly Telegram.Bot.TelegramBotClient Bot = new TelegramBotClient("654374778:AAGxy-Q6JNx7eEbWzZnnU5uW8pVuvQ44_9E");
    }
}
