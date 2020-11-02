using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM;
using ORM.ResponseMessages;

namespace FakeORMTest
{
    [TestClass]
    public class UnitTest1
    {
        private DataModel _context;

        [TestInitialize]
        public void Initialize()
        {
            var connection = DbConnectionFactory.CreateTransient();
            _context = new DataModel(connection);
        }

        [TestMethod]
        public void GetGateway_WithoutId_Returns599()
        {
            DBManager dbManager = DBManager.Get();
            const string serial = "999999";
            SoapListGateway response = dbManager.GetAllGWEntitiesForTest(_context, serial);
            Assert.Equals(response.Code, 599);
        }
    }
}
