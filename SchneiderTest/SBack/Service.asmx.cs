using ORM;
using ORM.Model;
using ORM.ResponseMessages;
using System.Web.Services;

namespace SBack
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://amian.es/schneiderbackend")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : WebService
    {

        [WebMethod]
        public SOAPResponse CreateWaterMeter(string serial, string brand, string model)
        {
            return DBManager.Get().CreateEntity(typeof(WaterMeter),serial, brand, model);
        }

        [WebMethod]
        public SOAPResponse CreateElectricityMeter(string serial, string brand, string model)
        {
            return DBManager.Get().CreateEntity(typeof(ElectricityMeter), serial, brand, model);
        }

        [WebMethod]
        public SOAPResponse CreateGateway(string serial, string brand, string model, string ip, string port)
        {
            int? portConverted = null;
            if (!string.IsNullOrEmpty(port))
            {
                int portInt;
                int.TryParse(port, out portInt);
                portConverted = portInt;
            }
            return DBManager.Get().CreateEntity(typeof(Gateway), serial, brand, model, ip, portConverted);
        }

        [WebMethod]
        public SoapListGateway GetAllGateways()
        {
            return DBManager.Get().GetAllGWEntities();
        }

        [WebMethod]
        public SoapListGateway GetGatewayBySerial(string serial)
        {
            return DBManager.Get().GetAllGWEntities(serial);
        }
        [WebMethod]
        public SOAPResponse DeleteGatewayBySerial(string serial)
        {
            return DBManager.Get().DeleteGatewayBySerial(serial);
        }

        [WebMethod]
        public SoapListElectricityMeter GetAllElectricityMeter()
        {
            return DBManager.Get().GetAllElectricityEntities();
        }

        [WebMethod]
        public SoapListElectricityMeter GetElectricityMeterBySerial(string serial)
        {
            return DBManager.Get().GetAllElectricityEntities(serial);
        }
        [WebMethod]
        public SOAPResponse DeleteElectricityMeterBySerial(string serial)
        {
            return DBManager.Get().DeleteElectricityMeterBySerial(serial);
        }


        [WebMethod]
        public SoapListWaterMeter GetAllWaterMeter()
        {
            return DBManager.Get().GetAllWaterEntities();
        }

        [WebMethod]
        public SoapListWaterMeter GetWaterMeterBySerial(string serial)
        {
            return DBManager.Get().GetAllWaterEntities(serial);
        }
        [WebMethod]
        public SOAPResponse DeleteWaterMeterBySerial(string serial)
        {
            return DBManager.Get().DeleteWaterMeterBySerial(serial);
        }
    }
}
