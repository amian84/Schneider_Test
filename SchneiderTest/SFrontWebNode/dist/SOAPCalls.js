"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.SOAPCalls = void 0;
const soap = __importStar(require("soap"));
const ElectricityMeter_1 = require("./models/ElectricityMeter");
const Gateway_1 = require("./models/Gateway");
const SoapResponse_1 = require("./models/SoapResponse");
const WaterMeter_1 = require("./models/WaterMeter");
class SOAPCalls {
    constructor() {
        this.soapUrl = "http://localhost:59430/Service.asmx?WSDL";
    }
    /**
     * The static method that controls the access to the singleton instance.
     *
     * This implementation let you subclass the Singleton class while keeping
     * just one instance of each subclass around.
     */
    static getInstance() {
        if (!SOAPCalls.instance) {
            SOAPCalls.instance = new SOAPCalls();
        }
        return SOAPCalls.instance;
    }
    GetAllWaterMeters() {
        const wmeters = [];
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    yield client.GetAllWaterMeter(null, (err1, result) => {
                        if (!err1) {
                            for (let i = 0; i < result.GetAllWaterMeterResult.Entities.WaterMeter.length; i++) {
                                const wm = result.GetAllWaterMeterResult.Entities.WaterMeter[i];
                                const wmToSave = new WaterMeter_1.WaterMeter();
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
            }));
        });
    }
    GetAllGateways() {
        const gws = [];
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    yield client.GetAllGateways(null, (err1, result) => {
                        if (!err1) {
                            for (let i = 0; i < result.GetAllGatewaysResult.Entities.Gateway.length; i++) {
                                const gw = result.GetAllGatewaysResult.Entities.Gateway[i];
                                const gwToSave = new Gateway_1.Gateway();
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
            }));
        });
    }
    GetAllElectricityMeters() {
        const emeters = [];
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    yield client.GetAllElectricityMeter(null, (err1, result) => {
                        if (!err1) {
                            for (let i = 0; i < result.GetAllElectricityMeterResult.Entities.ElectricityMeter.length; i++) {
                                const em = result.GetAllElectricityMeterResult.Entities.ElectricityMeter[i];
                                const emToSave = new ElectricityMeter_1.ElectricityMeter();
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
            }));
        });
    }
    CreateWaterMeter(sn, brand, model) {
        const responseReturn = new SoapResponse_1.SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    const args = {
                        serial: sn,
                        brand,
                        model,
                    };
                    yield client.CreateWaterMeter(args, (err1, result) => {
                        if (!err1) {
                            responseReturn.Code = result.CreateWaterMeterResult.Code;
                            responseReturn.Msg = result.CreateWaterMeterResult.Msg;
                        }
                        else {
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }
            }));
        });
    }
    CreateElectricityMeter(sn, brand, model) {
        const responseReturn = new SoapResponse_1.SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    const args = {
                        serial: sn,
                        brand,
                        model,
                    };
                    yield client.CreateElectricityMeter(args, (err1, result) => {
                        if (!err1) {
                            responseReturn.Code = result.CreateElectricityMeterResult.Code;
                            responseReturn.Msg = result.CreateElectricityMeterResult.Msg;
                        }
                        else {
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }
            }));
        });
    }
    CreateGateway(sn, brand, model, ip, port) {
        const responseReturn = new SoapResponse_1.SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    const args = {
                        serial: sn,
                        brand,
                        model,
                        ip,
                        port
                    };
                    yield client.CreateGateway(args, (err1, result) => {
                        if (!err1) {
                            responseReturn.Code = result.CreateGatewayResult.Code;
                            responseReturn.Msg = result.CreateGatewayResult.Msg;
                        }
                        else {
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }
            }));
        });
    }
    DelWaterMeterBySerial(sn) {
        const responseReturn = new SoapResponse_1.SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    const args = {
                        serial: sn
                    };
                    yield client.DeleteWaterMeterBySerial(args, (err1, result) => {
                        if (!err1) {
                            responseReturn.Code = result.DeleteWaterMeterBySerialResult.Code;
                            responseReturn.Msg = result.DeleteWaterMeterBySerialResult.Msg;
                        }
                        else {
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }
            }));
        });
    }
    DelElectricityMeterBySerial(sn) {
        const responseReturn = new SoapResponse_1.SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    const args = {
                        serial: sn
                    };
                    yield client.DeleteElectricityMeterBySerial(args, (err1, result) => {
                        if (!err1) {
                            responseReturn.Code = result.DeleteElectricityMeterBySerialResult.Code;
                            responseReturn.Msg = result.DeleteElectricityMeterBySerialResult.Msg;
                        }
                        else {
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }
            }));
        });
    }
    DelGatewayBySerial(sn) {
        const responseReturn = new SoapResponse_1.SoapResponse();
        responseReturn.Code = 200;
        return new Promise((resolve) => {
            soap.createClient(this.soapUrl, (err, client) => __awaiter(this, void 0, void 0, function* () {
                if (!err) {
                    const args = {
                        serial: sn
                    };
                    yield client.DeleteGatewayBySerial(args, (err1, result) => {
                        if (!err1) {
                            responseReturn.Code = result.DeleteGatewayBySerialResult.Code;
                            responseReturn.Msg = result.DeleteGatewayBySerialResult.Msg;
                        }
                        else {
                            responseReturn.Code = 500;
                            responseReturn.Msg = err1.toString();
                        }
                        resolve(responseReturn);
                    });
                }
            }));
        });
    }
}
exports.SOAPCalls = SOAPCalls;
//# sourceMappingURL=SOAPCalls.js.map