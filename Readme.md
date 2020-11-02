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