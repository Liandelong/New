using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewDAL;
using NewModel;
namespace NewBLL
{
   public class UserInfoBLL
    {
        UserInfoDAL userInfoDAL = new UserInfoDAL();

        /// <summary>
        /// 根据用户名和用户密码获取用户对象
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string userName,string userPwd)
        {
            return userInfoDAL.GetUserInfo(userName, userPwd);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public bool UpdateEntityModel(UserInfo typeInfo)
        {
            return userInfoDAL.UpdateEntityModel(typeInfo) > 0;
        }

        /// <summary>
        /// 跟新密码
        /// </summary>
        /// <param name="userPassword"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdatePassWordModel(string userPassword, int id)
        {
            return userInfoDAL.UpdatePassWordModel(userPassword, id) > 0;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool InsertEntityModel(UserInfo userInfo)
        {
            return userInfoDAL.InsertEntityModel(userInfo) > 0;
        }

        /// <summary>
        /// 获取所有游客
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<UserInfo> GetTourist(int start,int end)
        {
            return userInfoDAL.GetTourist(start,end);
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetTouristCount(int pageSize)
        {
            var recordCount= userInfoDAL.GetTouristCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        public bool IsDelete(int id)
        {
            return userInfoDAL.IsDelete(id);
        }
    }
}
