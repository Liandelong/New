using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModel;
using NewDAL;
namespace NewBLL
{
   public class TypeBLL
    {
        /// <summary>
        /// 获取所有新闻类型
        /// </summary>
        TypeDAL typeDAL = new TypeDAL();
        public List<TypeInfo> GetEntityList()
        {
            return typeDAL.GetEntityList();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数据记录数</param>
        /// <returns></returns>
        public List<TypeInfo> GetPageEntityList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return typeDAL.GetPageNewTypeList(start, end);
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = typeDAL.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        /// <summary>
        /// 根据id删除评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEntityModel(int id)
        {
            return typeDAL.DeleteEntityModel(id) > 0;
        }


        /// <summary>
        /// 根据id获取新闻对象
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public TypeInfo GetModel(int id)
        {
            return typeDAL.GetEntityModel(id);
        }

        /// <summary>
        /// 添加新闻类型
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public bool InsertEntityModel(TypeInfo typeInfo)
        {
            return typeDAL.InsertEntityModel(typeInfo) > 0;
        }

        /// <summary>
        /// 修改新闻类型
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public bool UpdateEntityModel(TypeInfo typeInfo)
        {
            return typeDAL.UpdateEntityModel(typeInfo) > 0;
        }
    }
}
