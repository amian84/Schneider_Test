import dotenv from "dotenv";
import express from "express";
import path from "path";
import { WaterMeter } from "./models/WaterMeter";
import { SOAPCalls } from "./SOAPCalls";
import * as bodyparser from "body-parser";
import { ElectricityMeter } from "./models/ElectricityMeter";
import { Gateway } from "./models/Gateway";
import { SoapResponse } from "./models/SoapResponse";

// initialize configuration
dotenv.config();

// port is now available to the Node.js runtime
// as if it were an environment variable
const port = process.env.SERVER_PORT;

const app = express();
app.use( bodyparser.json() );       // to support JSON-encoded bodies
app.use(bodyparser.urlencoded({     // to support URL-encoded bodies
  extended: true
}));
// Configure Express to use EJS
app.set( "views", path.join( __dirname, "views" ) );
app.set( "view engine", "ejs" );

// define a route handler for the default home page
app.get( "/", ( req, res ) => {
    // render the index template
    res.render( "index" );
} );


app.get( "/watermeters", async ( req, res ) => {
    const error = req.query.msg;
    const wmeters: WaterMeter[] = await SOAPCalls.getInstance().GetAllWaterMeters();
    res.render( "watermeters", {wmeters, error} );
} );

app.get( "/electricitymeters", async ( req, res ) => {
    const error = req.query.msg;
    const emeters: ElectricityMeter[] = await SOAPCalls.getInstance().GetAllElectricityMeters();
    res.render( "electricitymeters", {emeters, error} );
} );

app.get( "/gateways", async ( req, res ) => {
    const error = req.query.msg;
    const gws: Gateway[] = await SOAPCalls.getInstance().GetAllGateways();
    res.render( "gateways", {gws, error} );
} );

app.post("/refresh", async (req, res)=>{
    const entity = req.body.entity;
    if (entity === "wm"){
        res.redirect('/watermeters');
    }else if (entity === "em"){
        res.redirect('/electricitymeters');
    }else if (entity === "gw"){
        res.redirect('/gateways');
    }else{
        res.redirect('/');
    }
});

app.post("/delete", async (req, res)=>{
    const entity = req.body.entity;
    const sn = req.body.sn;
    if (entity === "wm"){
        const response: SoapResponse = await SOAPCalls.getInstance().DelWaterMeterBySerial(sn);
        if (response.Code === 200){
            res.redirect('/watermeters');
        }else{
            res.redirect('/watermeters?msg=' + response.Msg);
        }
    }else if (entity === "em"){
        const response: SoapResponse = await SOAPCalls.getInstance().DelElectricityMeterBySerial(sn);
        if (response.Code === 200){
            res.redirect('/electricitymeters');
        }else{
            res.redirect('/electricitymeters?msg=' + response.Msg);
        }

    }else if (entity === "gw"){
        const response: SoapResponse = await SOAPCalls.getInstance().DelGatewayBySerial(sn);
        if (response.Code === 200){
            res.redirect('/gateways');
        }else{
            res.redirect('/gateways?msg=' + response.Msg);
        }
    }else{
        res.redirect('/');
    }
});

app.post("/createEntity", async (req, res)=>{
    const serialnumber = req.body.sn;
    const brand = req.body.brand;
    const model = req.body.model;
    const ip = req.body.ip;
    const portgw = req.body.port;
    const entity = req.body.entity;

    if (entity === "wm"){
        const response: SoapResponse = await SOAPCalls.getInstance().CreateWaterMeter(serialnumber, brand, model);
        if (response.Code === 200){
            res.redirect('/watermeters');
        }else{
            res.redirect('/watermeters?msg=' + response.Msg);
        }

    }
    else if (entity === "em"){
        const response: SoapResponse = await SOAPCalls.getInstance().CreateElectricityMeter(serialnumber, brand, model);
        if (response.Code === 200){
            res.redirect('/electricitymeters');
        }else{
            res.redirect('/electricitymeters?msg=' + response.Msg);
        }
    }
    else if (entity === "gw"){
        const response: SoapResponse = await SOAPCalls.getInstance().CreateGateway(serialnumber, brand, model, ip, portgw);
        if (response.Code === 200){
            res.redirect('/gateways');
        }else{
            res.redirect('/gateways?msg=' + response.Msg);
        }
    }
    else{
        res.redirect('/');
    }


});


// start the express server
app.listen( port, () => {
    // tslint:disable-next-line:no-console
    console.log( `server started at http://localhost:${ port }` );
} );