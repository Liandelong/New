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

        public bool UpdatePassWordModel(string userPassword, int id)
        {
            return userInfoDAL.UpdatePassWordModel(userPassword, id) > 0;
        }
    }
}
