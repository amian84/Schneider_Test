using ORM.Model;
using ORM.ResponseMessages;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace ORM
{
    public class DBManager
    {
        //Instance of database manager
        private static DBManager _instance;

        /// <summary>
        /// Default cosntructor, we need set sqlite file into DataDirectory for EF6
        /// </summary>
        public DBManager() : base()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string path = (System.IO.Path.GetDirectoryName(executable));
            path = System.IO.Path.Combine(path, "backend.sqlite").Replace("file:\\", "");
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }


        /// <summary>
        /// Static Get method to get the Database Manager as Singleton
        /// </summary>
        /// <returns>
        /// The Database Manager instance
        /// </returns>
        public static DBManager Get()
        {
            if (_instance == null)
                _instance = new DBManager();
            return _instance;
        }


        /// <summary>
        /// Method to create a new gateway object and store into SQLite DB
        /// check if the serial exists before inserting
        /// </summary>
        /// <param name="serial">String with serial number</param>
        /// <param name="brand">String with brand</param>
        /// <param name="model">String with model</param>
        /// <param name="ip">String with ip</param>
        /// <param name="port">Integer with port (nullable)</param>
        /// <param name="response">SoapReturnMessage response</param>
        /// <param name="db">DataModel with db context from EF6</param>
        public void CreateGateway(
            string serial,
            string brand,
            string model,
            string ip,
            int? port,
            SOAPResponse response,
            DataModel db
        )
        {
            
            Gateway result = db.Gateways
                        .Where(gw => gw.SerialNumber == serial)
                        .FirstOrDefault();
            if (result == null)
            {
                result = new Gateway();
                result.SerialNumber = serial;
                result.Brand = brand;
                result.Model = model;
                result.Ip = ip;
                result.Port = port;
                if (port == null)
                {
                    result.Port = 80;
                }
                db.Gateways.Add(result);
                db.SaveChanges();
                response.Code = 200;
                response.Msg = "Ok";
            }
        }

        /// <summary>
        /// Method to delete electricity meter by serial
        /// </summary>
        /// <returns>
        /// SOAPResponse with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number</param>
        public SOAPResponse DeleteElectricityMeterBySerial(string serial)
        {
            SOAPResponse response = new SOAPResponse();
            response.Code = 500;
            response.Msg = "Error, can not found any entity with that serial";
            try
            {
                using (var db = new DataModel())
                {
                    ElectricityMeter result = db.ElectricityMeters
                        .Where(em => em.SerialNumber == serial)
                        .FirstOrDefault();
                    if (result != null)
                    {
                        db.ElectricityMeters.Remove(result);
                        db.SaveChanges();
                        response.Code = 200;
                        response.Msg = "Ok";
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                response.Code = 501;
                response.Msg = "Validation error, please check if you are set all required fields";
            }
            return response;
        }

        /// <summary>
        /// Method to delete gateway by serial
        /// </summary>
        /// <returns>
        /// SOAPResponse with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number</param>
        public SOAPResponse DeleteGatewayBySerial(string serial)
        {
            SOAPResponse response = new SOAPResponse();
            response.Code = 500;
            response.Msg = "Error, can not found any entity with that serial";
            try
            {
                using (var db = new DataModel())
                {
                    Gateway result = db.Gateways
                        .Where(gw => gw.SerialNumber == serial)
                        .FirstOrDefault();
                    if (result != null)
                    {                        
                        db.Gateways.Remove(result);
                        db.SaveChanges();
                        response.Code = 200;
                        response.Msg = "Ok";
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                response.Code = 501;
                response.Msg = "Validation error, please check if you are set all required fields";
            }
            return response;
        }

        /// <summary>
        /// Method to delete water meter by serial
        /// </summary>
        /// <returns>
        /// SOAPResponse with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number</param>
        public SOAPResponse DeleteWaterMeterBySerial(string serial)
        {
            SOAPResponse response = new SOAPResponse();
            response.Code = 500;
            response.Msg = "Error, can not found any entity with that serial";
            try
            {
                using (var db = new DataModel())
                {
                    WaterMeter result = db.WaterMeters
                        .Where(wm => wm.SerialNumber == serial)
                        .FirstOrDefault();
                    if (result != null)
                    {
                        db.WaterMeters.Remove(result);
                        db.SaveChanges();
                        response.Code = 200;
                        response.Msg = "Ok";
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                response.Code = 501;
                response.Msg = "Validation error, please check if you are set all required fields";
            }
            return response;
        }

        /// <summary>
        /// Method to create a new water meter object and store into SQLite DB
        /// check if the serial exists before inserting
        /// </summary>
        /// <param name="serial">String with serial number</param>
        /// <param name="brand">String with brand</param>
        /// <param name="model">String with model</param>
        /// <param name="response">SoapReturnMessage response</param>
        /// <param name="db">DataModel with db context from EF6</param>
        public void CreateWaterMeter(string serial, string brand, string model, SOAPResponse response, DataModel db)
        {            
            WaterMeter result = db.WaterMeters.Where(wm => wm.SerialNumber == serial)
                .FirstOrDefault();
            if (result == null)
            {
                result = new WaterMeter();
                result.SerialNumber = serial;
                result.Brand = brand;
                result.Model = model;
                db.WaterMeters.Add(result);
                db.SaveChanges();
                response.Code = 200;
                response.Msg = "Ok";
            }
        }

        /// <summary>
        /// Method to create any entity, check type of entity and call to his create function
        /// also catch if validation error from EF6 fails to set correct response error
        /// </summary>
        /// <returns>
        /// SoapCreateMessage with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number</param>
        /// <param name="brand">String with brand</param>
        /// <param name="model">String with model</param>
        /// <param name="ip">String with ip, default null</param>
        /// <param name="port">Integer with port, default null</param>
        public SOAPResponse CreateEntity(Type ent, string serial, string brand, string model, string ip = null, int? port = null)
        {
            SOAPResponse response = new SOAPResponse();
            response.Code = 500;
            response.Msg = "Element cannot be inserted, one already exists with the same serial number";
            try
            {
                using (var db = new DataModel())
                {
                    if (ent == typeof(ElectricityMeter))
                    {
                        CreateElectricityMeter(serial, brand, model, response, db);
                    }else if (ent == typeof(WaterMeter))
                    {
                        CreateWaterMeter(serial, brand, model, response, db);
                    }
                    else if (ent == typeof(Gateway))
                    {
                        CreateGateway(serial, brand, model, ip, port, response, db);
                    }
                    else
                    {
                        response.Code = 502;
                        response.Msg = "Error. I can't understood that entity";
                    }

                }
            }
            catch (DbEntityValidationException ex)
            {
                response.Code = 501;
                response.Msg = "Validation error, please check if you are set all required fields";
            }
            return response;
        }

        /// <summary>
        /// Method to create a new electricity meter object and store into SQLite DB
        /// check if the serial exists before inserting
        /// </summary>
        /// <param name="serial">String with serial number</param>
        /// <param name="brand">String with brand</param>
        /// <param name="model">String with model</param>
        /// <param name="response">SoapReturnMessage response</param>
        /// <param name="db">DataModel with db context from EF6</param>
        public void CreateElectricityMeter(string serial, string brand, string model, SOAPResponse response, DataModel db)
        {
            ElectricityMeter result = db.ElectricityMeters.Where(wm => wm.SerialNumber == serial)
                    .FirstOrDefault();
            if (result == null)
            {
                result = new ElectricityMeter();
                result.SerialNumber = serial;
                result.Brand = brand;
                result.Model = model;
                db.ElectricityMeters.Add(result);
                db.SaveChanges();
                response.Code = 200;
                response.Msg = "Ok";

            }
        }

        /// <summary>
        /// Method to get all entities of type electricity meter or filter by serial
        /// </summary>
        /// <returns>
        /// SoapListElectricityMeter with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number to filter by serial</param>
        public SoapListElectricityMeter GetAllElectricityEntities(string serial=null)
        {
            SoapListElectricityMeter response = new SoapListElectricityMeter();
            response.Code = 200;
            response.Entities = new List<ElectricityMeter>();
            try
            {
                using (var db = new DataModel())
                {
                    if (string.IsNullOrEmpty(serial))
                    {
                        response.Entities = db.ElectricityMeters.ToList();
                    }
                    else
                    {
                        response.Entities.Add(db.ElectricityMeters
                                              .Where(em => em.SerialNumber == serial)
                                              .FirstOrDefault());
                    }
                }

            }catch (Exception ex)
            {
                response.Code = 599;
                response.Msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Method to get all entities of type water meter or filter by serial
        /// </summary>
        /// <returns>
        /// SoapListWaterMeter with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number to filter by serial</param>
        public SoapListWaterMeter GetAllWaterEntities(string serial = null)
        {
            SoapListWaterMeter response = new SoapListWaterMeter();
            response.Code = 200;
            response.Entities = new List<WaterMeter>();
            try
            {
                using (var db = new DataModel())
                {
                    if (string.IsNullOrEmpty(serial))
                    {
                        response.Entities = db.WaterMeters.ToList();
                    }
                    else
                    {
                        response.Entities.Add(db.WaterMeters
                                              .Where(wm => wm.SerialNumber == serial)
                                              .FirstOrDefault());
                    }
                    
                }

            }
            catch (Exception ex)
            {
                response.Code = 599;
                response.Msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Method to get all entities of type gateway or filter by serial
        /// </summary>
        /// <returns>
        /// SoapListGateway with response for SOAP request
        /// </returns>
        /// <param name="serial">String with serial number to filter by serial</param>
        public SoapListGateway GetAllGWEntities(string serial = null)
        {
            SoapListGateway response = new SoapListGateway();
            response.Code = 200;
            response.Entities = new List<Gateway>();
            try
            {
                using (var db = new DataModel())
                {
                    if (string.IsNullOrEmpty(serial))
                    {
                        response.Entities = db.Gateways.ToList();
                    }
                    else
                    {
                        response.Entities.Add(db.Gateways
                                              .Where(gw => gw.SerialNumber == serial)
                                              .FirstOrDefault());
                    }
                    
                }

            }
            catch (Exception ex)
            {
                response.Code = 599;
                response.Msg = ex.Message;
            }
            return response;
        }
    }
}
