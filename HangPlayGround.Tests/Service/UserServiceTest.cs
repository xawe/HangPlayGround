using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HangPlayGround.Tests.Service
{
    public class UserServiceTest
    {

        private HangPlayGround.Service.IUserServices userServices;

        public UserServiceTest()
        {
            userServices = new HangPlayGround.Service.UserService();
        }

        [Fact]
        public void LoadUsersTest()
        {
            var result = userServices.GetUserList();
            Assert.True(result.Any());
        }
    }
}
