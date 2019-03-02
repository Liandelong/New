using NewBLL;
using NewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class NewTypesController : Controller
    {
        // GET: NewTypes
        //评论分页显示
        TypeBLL typeBLL = new TypeBLL();
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = typeBLL.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<TypeInfo> list = typeBLL.GetPageEntityList(pageIndex, pageSize);
            ViewData["pageList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNewType()
        {
            int id = int.Parse(Request["id"]);
            bool b = typeBLL.DeleteEntityModel(id);
            if (b)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        /// <summary>
        /// 浏览信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNewTypeInfoModel()
        {
            int id = int.Parse(Request["id"]);
            TypeInfo typeInfo = typeBLL.GetModel(id);
            return Json(typeInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加新闻类型
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddInfo()
        {
            return View();
        }

        //添加新闻类型
        [ValidateInput(false)]
        public ActionResult AddNewTypeInfo(TypeInfo typeInfo)
        {
            if (typeBLL.InsertEntityModel(typeInfo))
            {
                return Json(typeInfo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content("no:添加失败");
            }
        }

        #region 展示要修改的数据
        public ActionResult ShowEdit()
        {
            int id = int.Parse(Request["id"]);
            TypeInfo typeInfo = typeBLL.GetModel(id);          
            ViewData.Model = typeInfo;
            return View();
        }

        #endregion

        #region 完成信息修改
        [ValidateInput(false)]
        public ActionResult EditNewInfo(TypeInfo typeInfo)
        {
            if (typeBLL.UpdateEntityModel(typeInfo))
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