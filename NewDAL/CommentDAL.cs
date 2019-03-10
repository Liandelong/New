using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModel;
using NewCommon;
using System.Data.SqlClient;
using System.Data;

namespace NewDAL
{
    public class CommentDAL
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="end">终止位置</param>
        /// <returns></returns>
        public List<CommentInfo> GetPageEntityList(int start, int end)
        {
            string sql = "select * from (select row_number() over(order by id) as num,* from Comments) as N where N.num between @start and @end";
            SqlParameter[] pars = {
                new SqlParameter("@start",DbType.Int32),
                new SqlParameter("@end",DbType.Int32)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<CommentInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<CommentInfo>();
                CommentInfo commentInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    commentInfo = new CommentInfo();
                    LoadEntity(row, commentInfo);
                    list.Add(commentInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="row">Table行</param>
        /// <param name="newInfo">新闻对象</param>
        private void LoadEntity(DataRow row, CommentInfo commentInfo)
        {
            commentInfo.Author = row["Author"] != DBNull.Value ? row["Author"].ToString() : string.Empty;
            commentInfo.Title = row["Title"] != DBNull.Value ? row["Title"].ToString() : string.Empty;
            commentInfo.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
            commentInfo.Id = Convert.ToInt32(row["Id"]);
            commentInfo.CreateDateTime = Convert.ToDateTime(row["CreateDateTime"]);
            commentInfo.UserName = row["UserName"].ToString();

        }

        /// <summary>
        /// 获取新闻评论总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from Comments";
            int count = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, CommandType.Text));
            return count;
        }

        /// <summary>
        /// 根据id删除评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntityModel(int id)
        {
            string sql = "delete from NewsComments where Id=@Id";
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, new SqlParameter("@Id", id));
        }

        /// <summary>
        /// 插入评论信息
        /// </summary>
        /// <param name="newCommentInfo"></param>
        /// <returns></returns>
        public int InsertEntityModel(NewsComments newCommentInfo)
        {
            string sql = "insert into NewsComments(NewId,UserId,Msg,CreateDateTime) values(@NewId,@UserId,@Msg,@CreateDateTime)";
            SqlParameter[] pars = {
                                 new SqlParameter("@NewId",SqlDbType.Int,4),
                                 new SqlParameter("@UserId",SqlDbType.Int,4),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                 new SqlParameter("@CreateDateTime",SqlDbType.DateTime)
                                 };
            pars[0].Value = newCommentInfo.NewId;
            pars[1].Value = newCommentInfo.UserId;
            pars[2].Value = newCommentInfo.Msg;
            pars[3].Value = newCommentInfo.CreateDateTime;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据id获取评论列表
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public List<CommentViewModel> GetNewCommentList(int newId)
        {
            string sql = "select * from NewsComments where NewId=@NewId";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@NewId", newId));
            List<CommentViewModel> CommentList = null;
            if (da.Rows.Count > 0)
            {
                CommentList = new List<CommentViewModel>();
                CommentViewModel Comment = null;
                foreach (DataRow row in da.Rows)
                {
                    string sqlString = "select * from UserInfo where  Id=@UserId";
                    DataTable table = SqlHelper.GetTable(sqlString, CommandType.Text, new SqlParameter("@UserId",Convert.ToInt32(row["UserId"])));
                    Comment = new CommentViewModel();
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow Userrow in table.Rows)
                        {
                            Comment.UserName = Userrow["UserName"].ToString();
                           break;
                        }
                    }                   
                    Comment.Msg = row["Msg"]==DBNull.Value?null: row["Msg"].ToString();
                    Comment.CreateDateTime= row["CreateDateTime"] == DBNull.Value ? null : row["CreateDateTime"].ToString();
                    CommentList.Add(Comment);
                }
            }
            return CommentList;
        }
    }
}
