# school-control-net
This is a basic application made with dot net 6 using better practices but keeping simplicity of a single layer. Even so, this is a miny functional project for a school administration.
Features you can find in this sample project are:
* Entity Framework Code First approach
* Mediat R
* Base controller class / Thin controllers
* OData implementation

# SQL configuration
In order to run this api you need to set the connection string on app.settings.json file to your local machine server.
If you don't have SQL server installed and you have basic experience with Docker, I recommend to pull oficial SQL server image from Docker Hub
* docker pull mcr.microsoft.com/mssql/server
* docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

