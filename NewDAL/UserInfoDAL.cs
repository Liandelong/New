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
  public  class UserInfoDAL
    {
        /// <summary>
        /// 根据用户名密码获取用户对象
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string userName,string userPwd)
        {
            string sql = "select * from UserInfo where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] pars =
            {
                new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                new SqlParameter("@UserPwd",SqlDbType.NVarChar,32)
            };
            pars[0].Value = userName;
            pars[1].Value = userPwd;
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text, pars);
            UserInfo userInfo = null;
            if (table.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(table.Rows[0], userInfo);
            }
            return userInfo;
        }

        /// <summary>
        /// 获取所有游客
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetTourist(int start,int end)
        {
            string sql = "select * from (select row_number() over(order by id desc) as num,* from UserInfo where IsAdmin!=1) as N where N.num between @start and @end";
            SqlParameter[] pars = {
                new SqlParameter("@start",DbType.Int32),
                new SqlParameter("@end",DbType.Int32)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text,pars);
            List<UserInfo> list = new List<UserInfo>();
            UserInfo userInfo = null;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow Row in table.Rows)
                {
                    userInfo = new UserInfo();
                    LoadEntity(Row, userInfo);
                    list.Add(userInfo);
                }
                
            }
            return list;
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="dataRow">表行</param>
        /// <param name="userInfo">对象</param>
        private void LoadEntity(DataRow dataRow, UserInfo userInfo)
        {
            userInfo.Id = Convert.ToInt32(dataRow["Id"]);
            userInfo.UserName = dataRow["UserName"]!=DBNull.Value?dataRow["UserName"].ToString():string.Empty;
            userInfo.UserPwd= dataRow["UserPwd"] != DBNull.Value ? dataRow["UserPwd"].ToString() : string.Empty;
            userInfo.UserMail = dataRow["UserMail"] != DBNull.Value ? dataRow["UserMail"].ToString() : string.Empty;
            userInfo.RegTime = Convert.ToDateTime(dataRow["RegTime"]);
            userInfo.IsAdmin = Convert.ToInt32(dataRow["IsAdmin"]);
        }

        //更新用户
        public int UpdateEntityModel(UserInfo userInfo)
        {
            string sql = "update UserInfo set UserName=@UserName where Id=@Id";
            SqlParameter[] pars = {
                                   new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                                     new SqlParameter("@Id",SqlDbType.Int,4)
                                 };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.Id;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        public int UpdatePassWordModel(string userPassword,int id)
        {
            string sql = "update UserInfo set UserPwd=@UserPwd where Id=@Id";
            SqlParameter[] pars = {
                                   new SqlParameter("@UserPwd",SqlDbType.NVarChar,32),
                                     new SqlParameter("@Id",SqlDbType.Int,4)
                                 };
            pars[0].Value = userPassword;
            pars[1].Value = id;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        public int InsertEntityModel(UserInfo userInfo)
        {
            string sql = "insert into UserInfo(UserName, UserPwd, UserMail, RegTime, IsAdmin) values(@UserName,@UserPwd,@UserMail,@RegTime,@IsAdmin)";
            SqlParameter[] pars = {
                                 new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                                 new SqlParameter("@UserPwd",SqlDbType.NVarChar,32),
                                   new SqlParameter("@UserMail",SqlDbType.NVarChar),
                                   new SqlParameter("@RegTime",SqlDbType.DateTime),
                                   new SqlParameter("@IsAdmin",SqlDbType.Int,100)
                                 };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPwd;
            pars[2].Value = "";
            pars[3].Value = userInfo.RegTime;
            pars[4].Value = userInfo.IsAdmin;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        public int GetTouristCount()
        {
            string sql = "select Count(*) from UserInfo where isadmin!=1";
            int count = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, CommandType.Text));
            return count;
        }

        public bool IsDelete(int id)
        {
            string sql = "delete  from UserInfo where id=@id";
            var result= SqlHelper.ExcuteNonQuery(sql, CommandType.Text, new SqlParameter("@Id", id));
            return result > 0;
        }

    }
}
