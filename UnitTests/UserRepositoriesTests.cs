using NUnit.Framework;
using System;
using Web.Core.Sport.Organize.Repositories;
using Web.Core.Sport.Organize.Services;

namespace UnitTests
{
    public class UserRepositoriesTests
    {
        UserRepositories userRepositories;
        GlobalService globalService; 

        [SetUp]
        public void Setup()
        {
            globalService = new GlobalService();
            userRepositories = new UserRepositories(globalService);
        }
        [Test]
        public void GetUser_Work()
        {
            //Arrange
            var id = 1;
            var token = " xxxxx";

            //Act
            var data = userRepositories.GetUser(id,token);

            //Assert
            Assert.That(data, Is.EqualTo(null));
        }
    }
}
