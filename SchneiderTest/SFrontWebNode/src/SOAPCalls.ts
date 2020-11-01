import * as soap from "soap";
import { isParameter } from "typescript";
import { ElectricityMeter } from "./models/ElectricityMeter";
import { Gateway } from "./models/Gateway";
import { SoapResponse } from "./models/SoapResponse";
import { WaterMeter } from "./models/WaterMeter";
export class SOAPCalls {
    private static instance: SOAPCalls;
    /**
     * The static method that controls the access to the singleton instance.
     *
     * This implementation let you subclass the Singleton class while keeping
     * just one instance of each subclass around.
     */
    public static getInstance(): SOAPCalls {
        if (!SOAPCalls.instance) {
            SOAPCalls.instance = new SOAPCalls();
        }

        return SOAPCalls.instance;
    }
    private soapUrl = "http://localhost:59430/Service.asmx?WSDL";
    private constructor() { }

    public GetAllWaterMeters(): Promise<WaterMeter[]> {
        const  wmeters :WaterMeter[]=[];
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    await client.GetAllWaterMeter(null, (err1:any, result:any)=>{
                        if (!err1){
                            for (let i=0 ; i<result.GetAllWaterMeterResult.Entities.WaterMeter.length; i++ ) {
                                const wm = result.GetAllWaterMeterResult.Entities.WaterMeter[i];
                                const wmToSave: WaterMeter = new WaterMeter();
                                wmToSave.SerialNumber = wm.SerialNumber;
                                wmToSave.Brand = wm.Brand;
                                wmToSave.Model = wm.Model;
                                wmToSave.Id = wm.Id;
                                wmeters.push(wmToSave);
                            }
                            resolve(wmeters);
                        }
                    });
                }

            });

        });
    }

    public GetAllGateways(): Promise<Gateway[]> {
        const  gws :Gateway[]=[];
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    await client.GetAllGateways(null, (err1:any, result:any)=>{
                        if (!err1){
                            for (let i=0 ; i<result.GetAllGatewaysResult.Entities.Gateway.length; i++ ) {
                                const gw = result.GetAllGatewaysResult.Entities.Gateway[i];
                                const gwToSave: Gateway = new Gateway();
                                gwToSave.SerialNumber = gw.SerialNumber;
                                gwToSave.Brand = gw.Brand;
                                gwToSave.Model = gw.Model;
                                gwToSave.Id = gw.Id;
                                gwToSave.Ip = gw.Ip;
                                gwToSave.Port = gw.Port;
                                gws.push(gwToSave);
                            }
                            resolve(gws);
                        }
                    });
                }

            });

        });
    }

    public GetAllElectricityMeters(): Promise<ElectricityMeter[]> {
        const  emeters :ElectricityMeter[]=[];
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    await client.GetAllElectricityMeter(null, (err1:any, result:any)=>{
                        if (!err1){
                            for (let i=0 ; i<result.GetAllElectricityMeterResult.Entities.ElectricityMeter.length; i++ ) {
                                const em = result.GetAllElectricityMeterResult.Entities.ElectricityMeter[i];
                                const emToSave: ElectricityMeter = new ElectricityMeter();
                                emToSave.SerialNumber = em.SerialNumber;
                                emToSave.Brand = em.Brand;
                                emToSave.Model = em.Model;
                                emToSave.Id = em.Id;
                                emeters.push(emToSave);
                            }
                            resolve(emeters);
                        }
                    });
                }

            });

        });
    }

    public CreateWaterMeter(sn:string, brand:string, model:string): Promise<SoapResponse> {
        const  responseReturn :SoapResponse= new SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    const args = {
                        serial: sn,
                        brand,
                        model,
                    };
                    await client.CreateWaterMeter(args, (err1:any, result:any)=>{
                        if (!err1){
                            responseReturn.Code = result.CreateWaterMeterResult.Code;
                            responseReturn.Msg = result.CreateWaterMeterResult.Msg;

                        }else{
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }

            });

        });
    }

    public CreateElectricityMeter(sn:string, brand:string, model:string): Promise<SoapResponse> {
        const  responseReturn :SoapResponse= new SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    const args = {
                        serial: sn,
                        brand,
                        model,
                    };
                    await client.CreateElectricityMeter(args, (err1:any, result:any)=>{
                        if (!err1){
                            responseReturn.Code = result.CreateElectricityMeterResult.Code;
                            responseReturn.Msg = result.CreateElectricityMeterResult.Msg;

                        }else{
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }

            });

        });
    }

    public CreateGateway(sn:string, brand:string, model:string, ip:string, port:string): Promise<SoapResponse> {
        const  responseReturn :SoapResponse= new SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    const args = {
                        serial: sn,
                        brand,
                        model,
                        ip,
                        port
                    };
                    await client.CreateGateway(args, (err1:any, result:any)=>{
                        if (!err1){
                            responseReturn.Code = result.CreateGatewayResult.Code;
                            responseReturn.Msg = result.CreateGatewayResult.Msg;

                        }else{
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }

            });

        });
    }

    public DelWaterMeterBySerial(sn:string): Promise<SoapResponse> {
        const  responseReturn :SoapResponse= new SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    const args = {
                        serial: sn
                    };
                    await client.DeleteWaterMeterBySerial(args, (err1:any, result:any)=>{
                        if (!err1){
                            responseReturn.Code = result.DeleteWaterMeterBySerialResult.Code;
                            responseReturn.Msg = result.DeleteWaterMeterBySerialResult.Msg;

                        }else{
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }

            });

        });
    }

    public DelElectricityMeterBySerial(sn:string): Promise<SoapResponse> {
        const  responseReturn :SoapResponse= new SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    const args = {
                        serial: sn
                    };
                    await client.DeleteElectricityMeterBySerial(args, (err1:any, result:any)=>{
                        if (!err1){
                            responseReturn.Code = result.DeleteElectricityMeterBySerialResult.Code;
                            responseReturn.Msg = result.DeleteElectricityMeterBySerialResult.Msg;

                        }else{
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }

            });

        });
    }

    public DelGatewayBySerial(sn:string): Promise<SoapResponse> {
        const  responseReturn :SoapResponse= new SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve)=>{
            soap.createClient(this.soapUrl,async (err, client) => {
                if (!err){
                    const args = {
                        serial: sn
                    };
                    await client.DeleteGatewayBySerial(args, (err1:any, result:any)=>{
                        if (!err1){
                            responseReturn.Code = result.DeleteGatewayBySerialResult.Code;
                            responseReturn.Msg = result.DeleteGatewayBySerialResult.Msg;

                        }else{
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }

            });

        });
    }
}