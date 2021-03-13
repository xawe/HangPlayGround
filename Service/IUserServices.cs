using HangPlayGround.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangPlayGround.Service
{
    public interface IUserServices
    {
        public IList<UserModel> GetUserList();

        public UserModel GetUserById(int id);
    }
}
