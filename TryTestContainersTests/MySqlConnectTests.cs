using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryTestContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MySql;

namespace TryTestContainers.Tests
{
    [TestClass()]
    public class MySqlConnectTests
    {
        MySqlContainer _container = new MySqlBuilder().WithImage("mysql:8.0").Build();

        [TestInitialize]
        public async Task Init()
        {
            await _container.StartAsync();
        }

        [TestCleanup]
        public async Task Clean()
        {
            await _container.DisposeAsync();
        }

        [TestMethod()]
        public void TestTryConnect_Ok()
        {
            // arrange
            var connector = new MySqlConnect();

            // act
            var connected = connector.TryConnect(_container.GetConnectionString());

            // assert
            Assert.IsTrue(connected);
        }
    }
}