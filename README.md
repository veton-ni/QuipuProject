# Quipu Project

For Developing of the application, we have used Clean Architecture on MVC .net,
 - Domain layer
 - Service layer
 - Infrastructure layer
 - Presentation layer (QuipuWeb)
For Database it is configurate to work with MSSQL database.
We are using Entity Framework for Database.


## Project status 

To run the application, we need to follow the steps. 

Add Connection string to database which is located to appsettings.json, ConfigurationDB.ConnectionStrings. 

By adding connection to database, when it is running for the first time, it will create the Database and all tables necessary for the application. 

## Get Start

On the first page we have the top menu:
    - Home
    - New Client
    - Import XML
    - Export Json Data
On the middle of page, we have data table with all clients. 

#### Edit Client

We can edit the client by clicking a client on the data table or by New Client. 

We have put Fluent validator to validate the date when we send to server. 

For every client we can add new Address or edit existing Address. 

#### Importing XML data

We can import multiple Clients by uploading xml file from "Import XML" page.

Every time when we upload xml file, first we will validate it with XSD file which is located on XmlDTO/xsd/ClientXSD.xsd, after validation we will add all clients to database.

On root folder we have example of xml file "clients.xml".

#### Exporintg Json Data

We can download JSON files for each client by clicking on download profile. 

Or we can download all clients by going to "Export Json Data". In this page we have the option to sort dates with Name and Birthdate, also we can specify Desc or Asc for Name and Birthdate. 
We can combine Name and Birthdate together and sort by both. 

