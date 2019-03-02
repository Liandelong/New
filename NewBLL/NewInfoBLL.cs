using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModel;
using NewDAL;
namespace NewBLL
{
  public  class NewInfoBLL
    {
        NewInfoDAL newInfoDAL = new NewInfoDAL();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数据记录数</param>
        /// <returns></returns>
        public List<NewInfo> GetPageEntityList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return newInfoDAL.GetPageEntityList(start, end);
        }

        /// <summary>
        /// 获取搜索数据并分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数据记录数</param>
        /// <returns></returns>
        public List<NewInfo> GetPageEntityList(int pageIndex, int pageSize,string newsName)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return newInfoDAL.GetPageEntityList(start, end,newsName);
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = newInfoDAL.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        /// <summary>
        /// 获取搜索新闻的总页数
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize,string newsName)
        {
            int recordCount = newInfoDAL.GetRecordCount(newsName);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        /// <summary>
        /// 根据id获取新闻对象
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public NewInfo GetModel(int id)
        {
            return newInfoDAL.GetEntityModel(id);
        }

        /// <summary>
        /// 根据id删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEntityModel(int id)
        {
            return newInfoDAL.DeleteEntityModel(id) > 0;
        }

        /// <summary>
        /// 添加新闻信息
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public bool InsertEntityModel(NewInfo newInfo)
        {
            return newInfoDAL.InsertEntityModel(newInfo) > 0;
        }

        /// <summary>
        /// 修改新闻信息
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public bool UpdateEntityModel(NewInfo newInfo)
        {
            return newInfoDAL.UpdateEntityModel(newInfo) > 0;
        }
    }
}
