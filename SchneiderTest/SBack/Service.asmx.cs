using Message;
using NServiceBus;
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

        /// <summary>
        /// SOAP method to create Water Meter and publish event
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <param name="brand">brand </param>
        /// <param name="model">model</param>
        /// <returns>SOAPResponse with response</returns>
        [WebMethod]
        public SOAPResponse CreateWaterMeter(string serial, string brand, string model)
        {
            SOAPResponse res = DBManager.Get().CreateEntity(typeof(WaterMeter),serial, brand, model);
            CreateEntityEvent createEvent = new CreateEntityEvent();
            createEvent.Code = res.Code;
            createEvent.Msg = res.Msg;
            createEvent.EntityType = "wm";
            Global._endpointInstance.Publish(createEvent).ConfigureAwait(false).GetAwaiter().GetResult();
            return res;
        }

        /// <summary>
        /// SOAP method to create Electricity Meter and publish event
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <param name="brand">brand </param>
        /// <param name="model">model</param>
        /// <returns>SOAPResponse with response</returns>
        [WebMethod]
        public SOAPResponse CreateElectricityMeter(string serial, string brand, string model)
        {
            SOAPResponse res = DBManager.Get().CreateEntity(typeof(ElectricityMeter), serial, brand, model);
            CreateEntityEvent createEvent = new CreateEntityEvent();
            createEvent.Code = res.Code;
            createEvent.Msg = res.Msg;
            createEvent.EntityType = "em";
            Global._endpointInstance.Publish(createEvent).ConfigureAwait(false).GetAwaiter().GetResult();
            return res;
        }

        /// <summary>
        /// SOAP method to create Gateway and publish event
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <param name="brand">brand </param>
        /// <param name="model">model</param>
        /// <param name="ip">ip</param>
        /// <param name="port">port</param>
        /// <returns>SOAPResponse with response</returns>
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
            SOAPResponse res =  DBManager.Get().CreateEntity(typeof(Gateway), serial, brand, model, ip, portConverted);
            CreateEntityEvent createEvent = new CreateEntityEvent();
            createEvent.Code = res.Code;
            createEvent.Msg = res.Msg;
            createEvent.EntityType = "gw";
            Global._endpointInstance.Publish(createEvent).ConfigureAwait(false).GetAwaiter().GetResult();
            return res;
        }

        /// <summary>
        /// SOAP call to returns all gateways
        /// </summary>
        /// <returns>SoapListGateway response with all entities</returns>
        [WebMethod]
        public SoapListGateway GetAllGateways()
        {
            return DBManager.Get().GetAllGWEntities();
        }

        /// <summary>
        /// SOAP call to returns a gateways with that serial number
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <returns>SoapListGateway response with all entities</returns>
        [WebMethod]
        public SoapListGateway GetGatewayBySerial(string serial)
        {
            return DBManager.Get().GetAllGWEntities(serial);
        }

        /// <summary>
        /// SOAP call to delete a gateway with that serial number
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <returns>SOAPResponse with response</returns>
        [WebMethod]
        public SOAPResponse DeleteGatewayBySerial(string serial)
        {
            return DBManager.Get().DeleteGatewayBySerial(serial);
        }

        /// <summary>
        /// SOAP call to returns all electricities meters
        /// </summary>
        /// <returns>SoapListElectricityMeter response with all entities</returns>
        [WebMethod]
        public SoapListElectricityMeter GetAllElectricityMeter()
        {
            return DBManager.Get().GetAllElectricityEntities();
        }

        /// <summary>
        /// SOAP call to returns all electriciy meter with that serial number
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <returns>SoapListElectricityMeter response with that entities</returns>
        [WebMethod]
        public SoapListElectricityMeter GetElectricityMeterBySerial(string serial)
        {
            return DBManager.Get().GetAllElectricityEntities(serial);
        }

        /// <summary>
        /// SOAP call to delete a electricity meter with that serial number
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <returns>SOAPResponse with response</returns>
        [WebMethod]
        public SOAPResponse DeleteElectricityMeterBySerial(string serial)
        {
            return DBManager.Get().DeleteElectricityMeterBySerial(serial);
        }

        /// <summary>
        /// SOAP call to returns all water meters
        /// </summary>
        /// <returns>SoapListWaterMeter response with all entities</returns>
        [WebMethod]
        public SoapListWaterMeter GetAllWaterMeter()
        {
            return DBManager.Get().GetAllWaterEntities();
        }

        /// <summary>
        /// SOAP call to returns all water meter with that serial number
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <returns>SoapListWaterMeter response with that entities</returns>
        [WebMethod]
        public SoapListWaterMeter GetWaterMeterBySerial(string serial)
        {
            return DBManager.Get().GetAllWaterEntities(serial);
        }

        /// <summary>
        /// SOAP call to delete a water meter with that serial number
        /// </summary>
        /// <param name="serial">serial number</param>
        /// <returns>SOAPResponse with response</returns>
        [WebMethod]
        public SOAPResponse DeleteWaterMeterBySerial(string serial)
        {
            return DBManager.Get().DeleteWaterMeterBySerial(serial);
        }
    }
}
