using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewDAL;
using NewModel;
using NewCommon;
namespace NewBLL
{
  public  class CommentBLL
    {
        CommentDAL commemtDal = new CommentDAL();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数据记录数</param>
        /// <returns></returns>
        public List<CommentInfo> GetPageEntityList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return commemtDal.GetPageEntityList(start, end);
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = commemtDal.GetRecordCount();
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
            return commemtDal.DeleteEntityModel(id) > 0;
        }

        /// <summary>
        /// 插入评论信息
        /// </summary>
        /// <param name="newCommentInfo"></param>
        /// <returns></returns>
        public bool InsertEntityModel(NewsComments newCommentInfo)
        {
            return commemtDal.InsertEntityModel(newCommentInfo) > 0;
        }

        /// <summary>
        /// 根据id获取评论信息
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public List<CommentViewModel> GetNewCommentList(int newId)
        {
            return commemtDal.GetNewCommentList(newId);
        }
    }
}
