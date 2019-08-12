using System;
using System.Configuration;
using BChat.Data.EntityFramework;
using BChat.Data.Model;
using BChat.Data.Repositories;
using NUnit.Framework;

namespace BChatServer.NUnitTest
{
    public class UnitTests
    {
        private string _connectionString;

        [SetUp]
        public void Setup()
        {
            _connectionString = "server=localhost; Database=BChat; Integrated Security=True";
            using (var dbContext = new BasicContext(_connectionString))
            {
                dbContext.Database.EnsureCreated();
            }
            Repository.ConnectionString = _connectionString;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GetMessages_ReturnData()
        {
            var list = Repository.GetMessages();
            Assert.GreaterOrEqual(list.Count,0);
        }


        [Test]
        public void AddMessages_IsCorrect()
        {
            var initList = Repository.GetMessages();
            var message = new Message()
            {
                Timestamp = DateTime.Now,
                Content = "Message Content",
                User = "test@test.com1"
            };

            var result = Repository.AddMessage(message);
            Assert.AreEqual(true, result.Status);

            var endList = Repository.GetMessages();
            Assert.AreEqual(initList.Count + 1, endList.Count);
        }

    }
}