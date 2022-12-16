using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var actName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var rnd = new Random();
            var activ = new Activity(actName, rnd.Next(10, 50));

            //Act
           exerciseController.Add(activ, DateTime.Now , DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(actName, exerciseController.Activities.First().Name);
        }
    }
}