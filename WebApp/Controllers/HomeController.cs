using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewModel;
namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UserInfo userInfo = (UserInfo)Session["User"];
            ViewBag.user = userInfo.UserName;
            return View();
        }
    }
}