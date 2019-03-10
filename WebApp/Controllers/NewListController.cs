using NewBLL;
using NewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class NewListController : Controller
    {
        //
        // GET: /NewList/
        NewInfoBLL newInfoBLL = new NewInfoBLL();
        CommentBLL commentBLL = new CommentBLL();
        UserInfoBLL userInfoBLL = new UserInfoBLL();

        TypeBLL typeBLL = new TypeBLL();
        public ActionResult Index()
        {
            List<NewInfo> list=null;
            int pageSize = 8;
            int pageCount=0;
            if ((Request["TypeId"] != null && Request["TypeId"] != "")|| (Request["newName"] != null && Request["newName"] != ""))
            {
                var result = Request["newName"];
                int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
                if(result != null && result != "")
                {
                    pageCount = newInfoBLL.GetPageCount(pageSize, "%"+Request["newName"].ToString());//%为标志
                    pageIndex = pageIndex < 1 ? 1 : pageIndex;
                    pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
                    list= newInfoBLL.GetPageEntityList(pageIndex, pageSize, "%" + Request["newName"].ToString());
                }
                else
                {
                    pageCount = newInfoBLL.GetPageCount(pageSize, "#" + Request["TypeId"].ToString());//%为标志
                    pageIndex = pageIndex < 1 ? 1 : pageIndex;
                    pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
                    list = newInfoBLL.GetPageEntityList(pageIndex, pageSize, "#" + Request["TypeId"].ToString());
                }
              
                ViewData["hostNews"] = newInfoBLL.GetHostNews();
                ViewData["newInfoList"] = list;
                ViewData["pageIndex"] = pageIndex;
                ViewData["pageCount"] = pageCount;

            }
            else
            {
                int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;                
                pageCount = newInfoBLL.GetPageCount(pageSize);
                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
                list = newInfoBLL.GetPageEntityList(pageIndex, pageSize);
                ViewData["hostNews"] = newInfoBLL.GetHostNews();
                ViewData["newInfoList"] = list;
                ViewData["pageIndex"] = pageIndex;
                ViewData["pageCount"] = pageCount;
         
            }
            //获取新闻类型
            List<TypeInfo> NewInfoList = typeBLL.GetEntityList();
            ViewData["TypeInfoList"] = NewInfoList;
            ViewData["Tourist"] = (UserInfo)Session["Tourist"];
            return View();
        }

        //新闻详细
        public ActionResult ShowDetail()
        {
            int id = int.Parse(Request["id"]);
            NewInfo NewInfo = newInfoBLL.GetModel(id);
            ViewData.Model = NewInfo;

            //获取新闻类型
            List<TypeInfo> NewInfoList = typeBLL.GetEntityList();
            ViewData["TypeInfoList"] = NewInfoList;
            ViewData["hostNews"] = newInfoBLL.GetHostNews();
            ViewData["Tourist"] = (UserInfo)Session["Tourist"];
            return View();
        }

        //添加评论
        public ActionResult AddComment()
        {
            UserInfo usernfo = (UserInfo)Session["Tourist"];
            if (usernfo == null)
            {
                return Content("登录后才能评论！！！");
            }
            int id = int.Parse(Request["id"]);
            string msg = Request["msg"];
            NewsComments comment = new NewsComments();
            comment.Msg = msg;
            comment.NewId = id;
            comment.UserId = usernfo.Id;
            comment.CreateDateTime = DateTime.Now;
            if (commentBLL.InsertEntityModel(comment))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        //加载评论
        public ActionResult LoadComment()
        {
            int id = int.Parse(Request["id"]);
            List<CommentViewModel> list = commentBLL.GetNewCommentList(id);
            List<CommentViewModel> newList = new List<CommentViewModel>();
            if (list != null)
            {
                foreach (var commentInfo in list)
                {
                    CommentViewModel viewModel = new CommentViewModel();
                    TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(commentInfo.CreateDateTime);
                    viewModel.CreateDateTime = NewCommon.WebCommon.GetTimeSpan(timeSpan);
                    viewModel.Msg = commentInfo.Msg;
                    viewModel.UserName = commentInfo.UserName;
                    newList.Add(viewModel);
                }
            }          
            return Json(newList, JsonRequestBehavior.AllowGet);
        }

        //用户登录
        public ActionResult UserLogin()
        {           
            //获取新闻类型
            List<TypeInfo> NewInfoList = typeBLL.GetEntityList();
            ViewData["TypeInfoList"] = NewInfoList;
            ViewData["hostNews"] = newInfoBLL.GetHostNews();
            ViewData["Tourist"] = (UserInfo)Session["Tourist"];
            return View();
        }

        public ActionResult UserRegister()
        {
            //获取新闻类型
            List<TypeInfo> NewInfoList = typeBLL.GetEntityList();
            ViewData["TypeInfoList"] = NewInfoList;
            ViewData["hostNews"] = newInfoBLL.GetHostNews();
            ViewData["Tourist"] = (UserInfo)Session["Tourist"];
            return View();
        }


        public ActionResult UserLoginButton(string userName,string userPwd)
        {
            UserInfo userInfo = userInfoBLL.GetUserInfo(userName, userPwd);
            if (userInfo!=null)
            {
                Session["Tourist"] = null;
                Session["Tourist"] = userInfo;
                return Content("登录成功");
            }
            else
            {
                return Content("登录失败");
            }
        }

        public ActionResult UserRegisterButton(string userName, string userPwd)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = userName;
            userInfo.UserPwd = userPwd;
            userInfo.IsAdmin = 0;
            userInfo.RegTime = DateTime.Now;
            var result= userInfoBLL.InsertEntityModel(userInfo);
            if (result)
            {
                return Content("注册成功");
            }
            else
            {
                return Content("注册失败");
            }
        }

    }
}