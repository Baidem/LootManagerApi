using Microsoft.VisualStudio.TestTools.UnitTesting;
using LootManagerApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;

namespace LootManagerApi.Utils.Tests
{
    [TestClass()]
    public class UtilsRoleTests
    {
        [TestMethod()]
        public void CheckOnlyAdminTestIsAdmin()
        {
            var userAuthDto = new UserAuthDto { Role = "Admin" };

            Assert.IsTrue(UtilsRole.CheckOnlyAdmin(userAuthDto));
        }
        [TestMethod()]
        public void CheckOnlyAdminTestIsUser()
        {
            var userAuthDto = new UserAuthDto { Role = "User" };

            var exception = Assert.ThrowsException<Exception>(() => UtilsRole.CheckOnlyAdmin(userAuthDto));
            Assert.AreEqual("This function is only available to users with the administrator role.", exception.Message);
        }
        [TestMethod()]
        public void CheckOnlyAdminTestIsContributor()
        {
            var userAuthDto = new UserAuthDto { Role = "Contributor" };

            var exception = Assert.ThrowsException<Exception>(() => UtilsRole.CheckOnlyAdmin(userAuthDto));
            Assert.AreEqual("This function is only available to users with the administrator role.", exception.Message);
        }
    }
}