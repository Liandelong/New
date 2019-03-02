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

        TypeBLL typeBLL = new TypeBLL();
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = newInfoBLL.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<NewInfo> list = newInfoBLL.GetPageEntityList(pageIndex, pageSize);
            ViewData["newInfoList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;

            //获取新闻类型
            List<TypeInfo> NewInfoList = typeBLL.GetEntityList();
            ViewData["TypeInfoList"] = NewInfoList;

            return View();
        }
        public ActionResult ShowDetail()
        {
            int id = int.Parse(Request["id"]);
            NewInfo NewInfo = newInfoBLL.GetModel(id);
            ViewData.Model = NewInfo;

            //获取新闻类型
            List<TypeInfo> NewInfoList = typeBLL.GetEntityList();
            ViewData["TypeInfoList"] = NewInfoList;
            return View();
        }

        public ActionResult AddComment()
        {
            int id = int.Parse(Request["id"]);
            string msg = Request["msg"];
            NewsComments comment = new NewsComments();
            comment.Msg = msg;
            comment.NewId = id;
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
        public ActionResult LoadComment()
        {
            int id = int.Parse(Request["id"]);
            List<CommentViewModel> list = commentBLL.GetNewCommentList(id);
            List<CommentViewModel> newList = new List<CommentViewModel>();
            foreach (var commentInfo in list)
            {
                CommentViewModel viewModel = new CommentViewModel();
                TimeSpan timeSpan = DateTime.Now -Convert.ToDateTime(commentInfo.CreateDateTime);
                viewModel.CreateDateTime = NewCommon.WebCommon.GetTimeSpan(timeSpan);
                viewModel.Msg = commentInfo.Msg;
                newList.Add(viewModel);
            }
            return Json(newList, JsonRequestBehavior.AllowGet);
        }
    }
}