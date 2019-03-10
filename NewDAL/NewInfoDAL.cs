using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModel;
using System.Data;
using System.Data.SqlClient;
namespace NewDAL
{
    public class NewInfoDAL
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="end">终止位置</param>
        /// <returns></returns>
        public List<NewInfo> GetPageEntityList(int start, int end)
        {
            string sql = "select * from (select row_number() over(order by id desc) as num,* from NewsAndType) as N where N.num between @start and @end";
            SqlParameter[] pars = {
                new SqlParameter("@start",DbType.Int32),
                new SqlParameter("@end",DbType.Int32)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<NewInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<NewInfo>();
                NewInfo newInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newInfo = new NewInfo();
                    LoadEntity(row, newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="row">Table行</param>
        /// <param name="newInfo">新闻对象</param>
        private void LoadEntity(DataRow row, NewInfo newInfo)
        {
            newInfo.Author = row["Author"] != DBNull.Value ? row["Author"].ToString() : string.Empty;
            newInfo.Title = row["Title"] != DBNull.Value ? row["Title"].ToString() : string.Empty;
            newInfo.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
            newInfo.ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : string.Empty;
            newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            newInfo.Id = Convert.ToInt32(row["Id"]);
            newInfo.Type = row["Type"].ToString();
            newInfo.TypeId = Convert.ToInt32(row["TypeId"]);
        }

        /// <summary>
        /// 获取新闻总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from News";
            int count = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, CommandType.Text));
            return count;
        }

        /// <summary>
        /// 根据id获取新闻对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewInfo GetEntityModel(int id)
        {
            string sql = "select * from NewsAndType where Id=@Id";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Id", id));
            NewInfo newInfo = null;
            if (da.Rows.Count > 0)
            {
                newInfo = new NewInfo();
                LoadEntity(da.Rows[0], newInfo);
            }
            return newInfo;
        }

        /// <summary>
        /// 根据id删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntityModel(int id)
        {
            string sql = "delete from News where Id=@Id";
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, new SqlParameter("@Id", id));
        }

        /// <summary>
        /// 添加新闻信息
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public int InsertEntityModel(NewInfo newInfo)
        {
            string sql = "insert into News(Title,Msg,Author,SubDateTime,TypeId) values(@Title,@Msg,@Author,@SubDateTime,@TypeId)";
            SqlParameter[] pars = {
                                 new SqlParameter("@Title",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                   new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                   new SqlParameter("@SubDateTime",SqlDbType.DateTime),
                                   new SqlParameter("@TypeId",SqlDbType.Int,100)
                                 };
            pars[0].Value = newInfo.Title==null?"": newInfo.Title;
            pars[1].Value = newInfo.Msg == null ? "" : newInfo.Msg;
            pars[2].Value = newInfo.Author == null ? "" : newInfo.Author;
            pars[3].Value = newInfo.SubDateTime == null ? DateTime.Now : newInfo.SubDateTime;
            pars[4].Value = newInfo.TypeId;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 修改新闻信息
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public int UpdateEntityModel(NewInfo newInfo)
        {
            string sql = "update News set Title=@Title,Msg=@Msg,Author=@Author,SubDateTime=@SubDateTime,TypeId=@TypeId where Id=@Id";
            SqlParameter[] pars = {
                                 new SqlParameter("@Title",SqlDbType.NVarChar,32),
                                  new SqlParameter("@Author",SqlDbType.NVarChar,32),
                                 new SqlParameter("@Msg",SqlDbType.NVarChar),
                                   new SqlParameter("@SubDateTime",SqlDbType.DateTime),
                                   new SqlParameter("@TypeId",SqlDbType.Int),
                                     new SqlParameter("@Id",SqlDbType.Int,4)
                                 };
            pars[0].Value = newInfo.Title;
            pars[1].Value = newInfo.Author;
            pars[2].Value = newInfo.Msg;
            pars[3].Value = newInfo.SubDateTime;
            pars[4].Value = newInfo.TypeId;
            pars[5].Value = newInfo.Id;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 获取搜索数据并分页数据
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="end">终止位置</param>
        /// <returns></returns>
        public List<NewInfo> GetPageEntityList(int start, int end, string newsName)
        {
            string sql;
            if (newsName[0] == '%'|| newsName[0] == '#')
            {
                if (newsName[0] == '%')
                {
                    sql = "select * from (select row_number() over(order by id desc) as num,* from (select * from NewsAndType where Title like '%'+@newsName + '%') as new ) as N where N.num between @start and @end";
                }
                else
                {
                    sql = "select * from NewsAndType where  TypeId=@newsName";
                }
                }
            else
            {
                sql = "select * from (select row_number() over(order by id desc) as num,* from (select * from NewsAndType where Title like '%'+@newsName + '%' or Author like '%'+@newsName + '%' or Type like '%'+@newsName + '%') as new ) as N where N.num between @start and @end";
            }
            SqlParameter[] pars = {
                new SqlParameter("@start",DbType.Int32),
                new SqlParameter("@end",DbType.Int32),
                new SqlParameter("@newsName",SqlDbType.NVarChar)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            pars[2].Value = newsName.Substring(1, newsName.Length - 1);
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<NewInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<NewInfo>();
                NewInfo newInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newInfo = new NewInfo();
                    LoadEntity(row, newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取搜索新闻总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount(string newsName)
        {
            string sql;
            if (newsName[0] == '%'|| newsName[0] == '#')
            {
                if(newsName[0] == '%')
                {
                    sql = "select count(*) from (select row_number() over(order by id desc) as num,* from (select * from NewsAndType where Title like '%'+@newsName + '%') as new ) as N";
                }
                else
                {
                    sql = "select count(*) from NewsAndType where TypeId=@newsName ";
                }
                
            }
            else
            {
                sql = "select count(*) from (select row_number() over(order by id desc) as num,* from (select * from NewsAndType where Title like '%'+@newsName + '%' or Author like '%'+@newsName + '%' or Type like '%'+@newsName + '%') as new ) as N";
            }
            SqlParameter par = new SqlParameter("@newsName", SqlDbType.NVarChar);
            par.Value = newsName.Substring(1, newsName.Length - 1);
            int count = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, CommandType.Text, par));
            return count;
        }

        public List<NewInfo> GetHostNews()
        {
            //获取前五条评论最多的新闻
            string sql = "select * from News where Id in(select top 5 NewId from NewsComments Group by NewId  order by COUNT(NewId) desc)";           
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text);
            List<NewInfo> list = null;
            if (table.Rows.Count >0)
            {
                list = new List<NewInfo>();
                NewInfo newInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newInfo = new NewInfo();
                    LoadHostEntity(row, newInfo);
                    list.Add(newInfo);
                }
            }
            
            return list;
        }

        //实例化热点新闻
        private void LoadHostEntity(DataRow row, NewInfo newInfo)
        {
            newInfo.Author = row["Author"] != DBNull.Value ? row["Author"].ToString() : string.Empty;
            newInfo.Title = row["Title"] != DBNull.Value ? row["Title"].ToString() : string.Empty;
            newInfo.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
            newInfo.ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : string.Empty;
            newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            newInfo.Id = Convert.ToInt32(row["Id"]);
        }
    }
}
