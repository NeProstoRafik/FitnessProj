using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetUserDataTest()
        { // arrange
            var userName = Guid.NewGuid().ToString();
            var birthDay = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            //act
            
            controller.SetUserData(gender, birthDay, weight, height);
            var controller2 =new UserController(userName);
            //assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // arrange
            var userName = Guid.NewGuid().ToString();
            //act
            var controller = new UserController(userName);
            //assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}