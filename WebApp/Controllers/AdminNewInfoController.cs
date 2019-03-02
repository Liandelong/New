using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewBLL;
using NewModel;
namespace WebApp.Controllers
{
    public class AdminNewInfoController : Controller
    {
        //新闻分页显示
        NewInfoBLL newInfoBLL = new NewInfoBLL();
        // GET: AdminNewInfo
        public ActionResult Index()
        {         
            if (Request["value"] != null && Request["value"] != "")
            {
                var result = Request["value"];
                int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
                int pageSize = 5;
                int pageCount = newInfoBLL.GetPageCount(pageSize, Request["value"].ToString());
                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
                List<NewInfo> list = newInfoBLL.GetPageEntityList(pageIndex, pageSize, Request["value"].ToString());
                ViewData["pageList"] = list;
                ViewData["pageIndex"] = pageIndex;
                ViewData["pageCount"] = pageCount;             
            }
            else
            {
                
                int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
                int pageSize = 5;
                int pageCount = newInfoBLL.GetPageCount(pageSize);
                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
                List<NewInfo> list = newInfoBLL.GetPageEntityList(pageIndex, pageSize);
                ViewData["pageList"] = list;
                ViewData["pageIndex"] = pageIndex;
                ViewData["pageCount"] = pageCount;
            }  
            
            return View();
        }

        //评论分页显示
        CommentBLL commentBLL = new CommentBLL();
        public ActionResult Comment()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = commentBLL.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<CommentInfo> list = commentBLL.GetPageEntityList(pageIndex, pageSize);
            ViewData["pageList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }

        /// <summary>
        /// 管理员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Admin()
        {
            ViewBag.model = Session["User"];
            return View();
        }

        /// <summary>
        /// 浏览信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNewInfoModel()
        {
            int id = int.Parse(Request["id"]);
           NewInfo newInfo= newInfoBLL.GetModel(id);
            return Json(newInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            bool b = newInfoBLL.DeleteEntityModel(id);
            if (b)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        TypeBLL typeBLL = new TypeBLL();
        #region 显示添加信息
        public ActionResult ShowAddInfo()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var list1 = typeBLL.GetEntityList();
            foreach (var item in list1)
            {
                list.Add(
                    new SelectListItem()
                    {
                        Text = item.Type,
                        Value=item.Id.ToString()
                    });
            }
            ViewBag.TypeList = list;
            return View();
        }

        //添加新闻信息
        [ValidateInput(false)]
        public ActionResult AddNewInfo(NewInfo newInfo)
        {
            //注意Upload：目录是编辑器的目录要加上，还要添加LitJson，然后生成一下
            newInfo.SubDateTime = DateTime.Now;
            newInfo.Type = null;
            //newInfo.Msg = Request["Msg"];
            if (newInfoBLL.InsertEntityModel(newInfo))
            {
                return Json(newInfo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content("no:添加失败");
            }
        }
        #endregion

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCommon()
        {
            int id = int.Parse(Request["id"]);
            bool b = commentBLL.DeleteEntityModel(id);
            if (b)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        #region 展示要修改的数据
        public ActionResult ShowEdit()
        {
            
            int id = int.Parse(Request["id"]);
            NewInfo newInfo = newInfoBLL.GetModel(id);
            List<SelectListItem> list = new List<SelectListItem>();
            var list1 = typeBLL.GetEntityList();
            foreach (var item in list1)
            {
                if (item.Id == newInfo.TypeId)
                {
                    list.Add(
                   new SelectListItem()
                   {
                       Selected=true,
                       Text = item.Type,
                       Value = item.Id.ToString()
                   });
                }
                else
                {
                    list.Add(
                    new SelectListItem()
                    {
                        Text = item.Type,
                        Value = item.Id.ToString()
                    });
                }
                
            }
            ViewBag.TypeList = list;
            ViewData.Model = newInfo;
            return View();
        }

        #endregion

        #region 完成信息修改
        [ValidateInput(false)]
        public ActionResult EditNewInfo(NewInfo newInfo)
        {
            newInfo.Type = null;
            if (newInfoBLL.UpdateEntityModel(newInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");

            }
        }
        #endregion
    }
}