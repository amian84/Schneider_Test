# Schneider Tech Test

The test consist in a SOAP backend to store 3 types of entities.

  - Water Meter: id, serial number, brand, model
  - Electricity Meter: id, serial number, brand, model
  - Gateway: id, serial number, brand, model, ip, port

It should be noted that in all entities the field **SERIAL NUMBER** is required and unique for that entity, also in gateway entity the **IP** field is required

# Poject structure

We've for one side, the solution **SchneiderTest**. That solution is implemented using VS2017 Community, and we can see four project inside that solution:

  - **Messages**: A class library project to implment the messages contract for NServiceBus
  - **ORM**: A class library project with integration of ORM EntityFramework 6 with Sqlite database
  - **SBack**: A SOAP webservice to expose soap method to create, list and delete entities
  - **SFrontForm**: A Windows Form project where develop a Form as front-end for the back
  - **TestDBManagerExample**: Example Test Unit with NUnit checking create GW and found GW with serial, faking the DataModel class (Only for show knowlogment proppoused)

And in the other side, we've a project in nodejs + typescript as other front-end (this project don't user nservicebus, send post directly to webservice). The project is called **SFrontWebNode**

## SchneiderTest Solution
### ORM
Its a class library, inside we found diferents class:

  - DataModel.cs: Its a implementation of our DbContext, we've 3 DBset for each entity
  - DBManager.cs: Its a manager to interact with EF6 and Sqlite database
  - Model/Entity.cs: A base model entity with common propoerties
  - Model/ElectricityMeter.cs: A model for Electrecity Meter entity for DB, inherits from Entity
  - Model/WaterMeter.cs: A model for Water Meter entity for DB, inherits from Entity
  - Model/Gateway.cs: A model for Gateway entity for DB, inherits from Entity
  - ResponseMessages/SOAPResponse.cs: Base model of Soap response, that contains code and message
  - ResponseMessages/SoapListElectricityMeter.cs: Soap response model for list of electricity meters entity, that contains list of entities and inherited properties from SOAPResponse
  - ResponseMessages/SoapListGateway.cs: Soap response model for list of gateways entity, that contains list of entities and inherited properties from SOAPResponse
  - ResponseMessages/SoapListWaterMeter.cs: Soap response model for list of water meters entity, that contains list of entities and inherited properties from SOAPResponse

### Messages
That class library contains a definitions of Messages that send via NServiceBus:

 - CreateEntityCommand.cs: Command to create entites, that message contains string with entity type, serial number, brand, model, ip, and port
 - CreateEntityEvent.cs: Event for response of create entity, that message contains string with entity type, code and message

### SBack
Its a web application, implement a SOAP webservice to expose the next operations:

  - CreateElectricityMeter: Method to create a Electricity Meter entity, has serial, brand and model arguments
  - CreateGateway: Method to create a Gateway entity, has serial, brand, model, ip and port arguments
  - CreateWaterMeter: Method to create a Water Meter entity, has serial, brand and model arguments
  - DeleteElectricityMeterBySerial: Method to found a Electricity Meter by serial and delete it. Has serial as argument
  - DeleteGatewayBySerial: Method to found a Gateway by serial and delete it. Has serial as argument
  - DeleteWaterMeterBySerial: Method to found a Water Meter by serial and delete it. Has serial as argument
  - GetAllElectricityMeter: Method to list all Electricity Meters
  - GetAllGateways: Method to list all Gateways
  - GetAllWaterMeter: Method to list all Water Meters
  - GetElectricityMeterBySerial: Method to get a Electricity Meter by serial. Has serial as argument
  - GetGatewayBySerial: Method to get a Gateway by serial. Has serial as argument
  - GetWaterMeterBySerial: Method to get a Water Meter by serial. Has serial as argument

And as porject structure we've the next elements:
  
  - backend.sqlite: Its a sqlite database that copy of bin folder and configure into Web.config for EF6 read from bin folder
  - Web.config: Web.config with EF6 configurarion
  - Service.asmx: A ASMX file with all expose methods
  - CreateEntityReceiver: Class to handle create entity commands from NServiceBus

### SFrontForm
A windows form project with a front-end implmentation for SBack. We've a SBack connected service and a form with a tab control. We've 3 tabs on that tabcontrol, one for each entity. Inside that tab there're a datagridview control to show the entities and 3 buttons:

  - Refresh List: Refresh the datagridview calling to SOPA service
  - Create 'Entity': Show a new form to fill for create a new entity (we can use SOAP Post or NServiceBus)
  - Delete 'Entity': Delete a entity that select into datagridview (That use only SOAP Post method)
 

[![Create Entity](https://i.ibb.co/87S6ymM/createentity.png)](https://prnt.sc/vbw56r)
[![List entities](https://i.ibb.co/ySW6Q7w/list-entity.png)](https://prnt.sc/vbw5lg)
[![Try delete without select](https://i.ibb.co/ryw2sy0/try-delete-without-select.png)](https://prnt.sc/vbw7cz)
[![Ask delete](https://i.ibb.co/cF6ThZY/ask-delete.png)](https://prnt.sc/vbw7m5)

 
### TestDBManagerExample
A sample test projecto to show show knowlogment proppoused. I develop a fake DataModel class, and some functions in DBManager.cs that use a IDataModel and pass the fake for test.
I develop two test case, found GW entity by non existing serial and  other to insert a GW entity with serial and check exists.

Due timing i couldn't do all the test I would like, cause I think about that late and forced me to make more changes to use interfaces to mock that classes for testing purpose

## SFrontWebNode

A NodeJs+Typescript front-end, I use express and bootstrap for server and design. That front-end send post calls to SOAP webservice directly, for that I use the module 'soap'

### Project structure
We've folder src with all code and tools folder for tool to copy assets into dist folder.
Inside src folder we've the next elements:

 - models/ElectricityMeter.ts: Typescript class with model for Electricity Meter
 - models/Gateway.ts: Typescript class with model for Gateway
 - models/WaterMeter.ts: Typescript class with model for Water Meter
 - models/SoapResponse.ts: Typescript class with model for SOAP responses
 - views/index.ejs: Template with HTML for Index
 - views/electricitymeters.ejs: Template with HTML for Eelectricity Meter page
 - views/watermeters.ejs: Template with HTML for Water Meter page
 - views/gateways.ejs: Template with HTML for Gateway page
 - index.ts: Typescript class where instance express server and set routes for endpoints
 - SOAPCalls.ts: Typescript class with all SOAP calls

The front-end is very simple, we've a index webpage with 3 buttons, one for each entity. In each entity webpage we've 3 buttons (back, refresh and create) and a table with list all entities and posibility to delete. I attach some pics

[![Index](https://i.ibb.co/NxjmwL1/index.png)](https://ibb.co/MnVGqR8)
[![Create Water Meter](https://i.ibb.co/2schGMb/createWM.png)](https://ibb.co/D8wW0Mq)
[![List Water Meter](https://i.ibb.co/5kwGwDN/indexWM.png)](https://ibb.co/ScG5GTh)
[![List Water Meter](https://i.ibb.co/xzfVGxX/deletewm.png)](https://ibb.co/HGxmY5B)

# Deploy
For deploy the apps for testing, you must need Visual Studio (in my case I use 2007 Community), .NET Framewokr 4.6, Entity Framework 6, Sqlite, NServiceBus, and some nuget packages. Probably you must execute that command from Package-Manager console into VS
`Update-Package -reinstall`
With that you reinstall all nuget depends.

When you've all depends installed you mush run application in debug mode and as startup project **SFrontForm**

Now you're running windows form front-end and the project **SBack** into  IIS Express

For **SFrontWebNode** you need install Nodejs, when you installed, you need run `npm install -g` into SchneiderTest\SFrontWebNode folder, with that you install all dependencies. (In my case, I need install as global directly some modules as 'nodemon', 'rimraf', 'ts-node' and 'sax', simply executing `npm install node_module -g` for each module...)

To run the front-end you need run `npm run dev`

Thanks for all and for the chance!