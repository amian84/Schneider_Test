using NUnit.Framework;
using ORM;
using ORM.Model;
using ORM.ResponseMessages;
using TestDBManagerExample;

namespace Tests
{
    public class Tests
    {
        public IDataModel dm;

        [SetUp]
        public void Setup()
        {
            dm = new FakeDB();
        }

        [Test]
        public void CheckNonExistSerialForGW()
        {
            string serial = "9999";
            DBManager dbManager = DBManager.Get();
            SoapListGateway res = dbManager.GetAllGWEntitiesForTest(dm, serial);
            Assert.AreEqual(res.Code, 599);
        }

        [Test]
        public void CheckExistSerialForGW()
        {
            string serial = "9999";
            string brand = "brand";
            string model = "model";
            string ip = "1.1.1.1";
            int port = 99;
            
            DBManager dbManager = DBManager.Get();
            SOAPResponse res = new SOAPResponse();
            dbManager.CreateGatewayForTest(dm, serial, brand, model, ip, port, res);
            SoapListGateway resGet = dbManager.GetAllGWEntitiesForTest(dm, serial);
            bool exist = resGet.Entities.Count > 0;
            Assert.IsFalse(exist);
            Gateway gw = resGet.Entities[0];
            Assert.AreEqual(gw.SerialNumber, serial);
            Assert.AreEqual(gw.Brand, brand);
            Assert.AreEqual(gw.Model, model);
            Assert.AreEqual(gw.Ip, ip);
            Assert.AreEqual(gw.Port, port);
        }
    }
}