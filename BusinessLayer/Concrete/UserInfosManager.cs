using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserInfosManager
    {
        Repository<UserInfo> repository = new Repository<UserInfo>();
        public List<UserInfo> GetAllUserInfos()
        {
            return repository.List().ToList();
        }
        public UserInfo GetUserInfoById(int id)
        {

            return repository.GetById(id);
        }
        public int Update(UserInfo userInfo)
        {
            return repository.Update(userInfo);
        }
        public UserInfo GetUserInfoByUserID(int id) 
        {
            return repository.Find(x=>x.UserId == id);
        }
    }
}
