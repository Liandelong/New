using NewBLL;
using NewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        UserInfoBLL userInfoBLL = new UserInfoBLL();
        // GET: Users
        public ActionResult Index()
        {
            UserInfo userInfo = (UserInfo)Session["User"];
            ViewData.Model = userInfo;
            return View();
        }

        //添加新闻类型
        [ValidateInput(false)]
        public ActionResult UpdateUser(UserInfo userInfo)
        {
            if (userInfoBLL.UpdateEntityModel(userInfo))
            {
                Session["User"] =null;
                Session["User"] = userInfo;
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");
            }
        }

        public ActionResult ModifyUserPwd()
        {
            UserInfo userInfo = (UserInfo)Session["User"];
            ViewData.Model = userInfo;
            return View();
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="firstPassword"></param>
        /// <param name="secondPassword"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ModifyPassWord(string password,string firstPassword, string secondPassword,int id)
        {
            UserInfo userInfo = (UserInfo)Session["User"];
            if(userInfo.UserPwd== password)
            {
                if (firstPassword == secondPassword)
                {
                    if (userInfoBLL.UpdatePassWordModel(firstPassword,id))
                    {
                        return Content("修改成功");
                    }
                    else
                    {
                        return Content("修改失败");
                    }                   
                }
                else
                {
                    return Content("两次密码不一样，请重新输入!");
                }
            }
            else
            {
                return Content("旧密码输入错误！");
            }      
        }
    }
}