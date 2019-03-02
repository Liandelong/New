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
   public class TypeDAL
    {
        /// <summary>
        /// 查询所有新闻类型
        /// </summary>
        /// <returns></returns>
        public List<TypeInfo> GetEntityList()
        {
            string sql = "select * from NewsType";                   
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text);
            List<TypeInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<TypeInfo>();
                TypeInfo newInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newInfo = new TypeInfo();
                    LoadEntity(row, newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 初始化新闻类型
        /// </summary>
        /// <param name="row"></param>
        /// <param name="newInfo"></param>
        private void LoadEntity(DataRow row, TypeInfo newInfo)
        {
            newInfo.Id = Convert.ToInt32(row["Id"]);
            newInfo.Type = row["Type"].ToString();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="end">终止位置</param>
        /// <returns></returns>
        public List<TypeInfo> GetPageNewTypeList(int start, int end)
        {
            string sql = "select * from (select row_number() over(order by id desc) as num,* from NewsType) as N where N.num between @start and @end";
            SqlParameter[] pars = {
                new SqlParameter("@start",DbType.Int32),
                new SqlParameter("@end",DbType.Int32)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TypeInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<TypeInfo>();
                TypeInfo typeInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    typeInfo = new TypeInfo();
                    LoadEntity(row, typeInfo);
                    list.Add(typeInfo);
                }
            }
            return list;
        }


        /// <summary>
        /// 获取新闻类型总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from NewsType";
            int count = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, CommandType.Text));
            return count;
        }

        /// <summary>
        /// 根据id删除新闻类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntityModel(int id)
        {
            string sql = "delete from NewsType where Id=@Id";
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, new SqlParameter("@Id", id));
        }

        /// <summary>
        /// 根据id获取类型对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeInfo GetEntityModel(int id)
        {
            string sql = "select * from NewsType where Id=@Id";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@Id", id));
            TypeInfo typeInfo = null;
            if (da.Rows.Count > 0)
            {
                typeInfo = new TypeInfo();
                LoadEntity(da.Rows[0], typeInfo);
            }
            return typeInfo;
        }

        /// <summary>
        /// 添加新闻类型
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public int InsertEntityModel(TypeInfo typeInfo)
        {
            string sql = "insert into NewsType(Type) values(@Type)";
            SqlParameter[] pars = {                                
                                   new SqlParameter("@Type",SqlDbType.NVarChar,100)
                                 };
            pars[0].Value = typeInfo.Type;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 修改新闻信息
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public int UpdateEntityModel(TypeInfo typeInfo)
        {
            string sql = "update NewsType set Type=@Type where Id=@Id";
            SqlParameter[] pars = {                                 
                                   new SqlParameter("@Type",SqlDbType.NVarChar,8),
                                     new SqlParameter("@Id",SqlDbType.Int,4)
                                 };
            pars[0].Value = typeInfo.Type;
            pars[1].Value = typeInfo.Id;
            return SqlHelper.ExcuteNonQuery(sql, CommandType.Text, pars);
        }

    }
}
