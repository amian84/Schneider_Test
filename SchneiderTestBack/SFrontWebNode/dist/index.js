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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const dotenv_1 = __importDefault(require("dotenv"));
const express_1 = __importDefault(require("express"));
const path_1 = __importDefault(require("path"));
const SOAPCalls_1 = require("./SOAPCalls");
const bodyparser = __importStar(require("body-parser"));
// initialize configuration
dotenv_1.default.config();
// port is now available to the Node.js runtime
// as if it were an environment variable
const port = process.env.SERVER_PORT;
const app = express_1.default();
app.use(bodyparser.json()); // to support JSON-encoded bodies
app.use(bodyparser.urlencoded({
    extended: true
}));
// Configure Express to use EJS
app.set("views", path_1.default.join(__dirname, "views"));
app.set("view engine", "ejs");
// define a route handler for the default home page
app.get("/", (req, res) => {
    // render the index template
    res.render("index");
});
app.get("/watermeters", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const error = req.query.msg;
    const wmeters = yield SOAPCalls_1.SOAPCalls.getInstance().GetAllWaterMeters();
    res.render("watermeters", { wmeters, error });
}));
app.get("/electricitymeters", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const error = req.query.msg;
    const emeters = yield SOAPCalls_1.SOAPCalls.getInstance().GetAllElectricityMeters();
    res.render("electricitymeters", { emeters, error });
}));
app.get("/gateways", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const error = req.query.msg;
    const gws = yield SOAPCalls_1.SOAPCalls.getInstance().GetAllGateways();
    res.render("gateways", { gws, error });
}));
app.post("/refresh", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const entity = req.body.entity;
    if (entity === "wm") {
        res.redirect('/watermeters');
    }
    else if (entity === "em") {
        res.redirect('/electricitymeters');
    }
    else if (entity === "gw") {
        res.redirect('/gateways');
    }
    else {
        res.redirect('/');
    }
}));
app.post("/delete", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const entity = req.body.entity;
    const sn = req.body.sn;
    if (entity === "wm") {
        const response = yield SOAPCalls_1.SOAPCalls.getInstance().DelWaterMeterBySerial(sn);
        if (response.Code === 200) {
            res.redirect('/watermeters');
        }
        else {
            res.redirect('/watermeters?msg=' + response.Msg);
        }
    }
    else if (entity === "em") {
        const response = yield SOAPCalls_1.SOAPCalls.getInstance().DelElectricityMeterBySerial(sn);
        if (response.Code === 200) {
            res.redirect('/electricitymeters');
        }
        else {
            res.redirect('/electricitymeters?msg=' + response.Msg);
        }
    }
    else if (entity === "gw") {
        const response = yield SOAPCalls_1.SOAPCalls.getInstance().DelGatewayBySerial(sn);
        if (response.Code === 200) {
            res.redirect('/gateways');
        }
        else {
            res.redirect('/gateways?msg=' + response.Msg);
        }
    }
    else {
        res.redirect('/');
    }
}));
app.post("/createEntity", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const serialnumber = req.body.sn;
    const brand = req.body.brand;
    const model = req.body.model;
    const ip = req.body.ip;
    const portgw = req.body.port;
    const entity = req.body.entity;
    if (entity === "wm") {
        const response = yield SOAPCalls_1.SOAPCalls.getInstance().CreateWaterMeter(serialnumber, brand, model);
        if (response.Code === 200) {
            res.redirect('/watermeters');
        }
        else {
            res.redirect('/watermeters?msg=' + response.Msg);
        }
    }
    else if (entity === "em") {
        const response = yield SOAPCalls_1.SOAPCalls.getInstance().CreateElectricityMeter(serialnumber, brand, model);
        if (response.Code === 200) {
            res.redirect('/electricitymeters');
        }
        else {
            res.redirect('/electricitymeters?msg=' + response.Msg);
        }
    }
    else if (entity === "gw") {
        const response = yield SOAPCalls_1.SOAPCalls.getInstance().CreateGateway(serialnumber, brand, model, ip, portgw);
        if (response.Code === 200) {
            res.redirect('/gateways');
        }
        else {
            res.redirect('/gateways?msg=' + response.Msg);
        }
    }
    else {
        res.redirect('/');
    }
}));
// start the express server
app.listen(port, () => {
    // tslint:disable-next-line:no-console
    console.log(`server started at http://localhost:${port}`);
});
//# sourceMappingURL=index.js.map