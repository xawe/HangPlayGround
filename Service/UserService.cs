using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangPlayGround.Model;

namespace HangPlayGround.Service
{
    public class UserService : IUserServices
    {
        private IList<UserModel> _users;


        public UserModel GetUserById(int id)
        {
            if (_users == null)
            {
                _users = LoadUsers();
            }

            return _users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IList<UserModel> GetUserList()
        {
            if (_users == null)
            {
                _users = LoadUsers();
            }

            return _users;
        }

        private IList<UserModel> LoadUsers()
        {
            var users = new List<UserModel>();
            users.Add(new UserModel { Active = true, Id = 1, Name = "User One" });
            users.Add(new UserModel { Active = true, Id = 2, Name = "User Two" });
            users.Add(new UserModel { Active = false, Id = 3, Name = "User Three" });
            users.Add(new UserModel { Active = true, Id = 4, Name = "User Four" });

            return users;
        }
    }
}
