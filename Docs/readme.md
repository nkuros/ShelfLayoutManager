install MagicOnion using 
dotnet add package Grpc.AspNetCore
dotnet add package MagicOnion.Server

Install automapper
1 make sure nuget is installed https://learn.microsoft.com/en-us/nuget/install-nuget-client-tools?tabs=windows
dotnet add package AutoMapper

Install postgres
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore--version 7.0.11
dotnet tool install -g dotnet-ef --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.11


dotnet ef database update



Application must 


 1. Shelf Layout Management:
 1. Provide CRUD operations for Shelves(Cabinets, Rows, and Lanes).
 2. Store and retrieve Shelf data.
 3. Support operations for moving drinks between different positions.
 4. Ensure data consistency and handle any concurrency issues.
 2. (Bonus)Account Management:
 1. Provide CRUD operations for user accounts.
 2. Ensure that only authorized users can access the backend services
 2. Shelf Layout Modification:
 Allow users to:
 Add a new SKU drink to the shelf.
 1 / 3
System Requirement.md
 2023-11-22
 Move an existing SKU drink to a different position on the shelf.
 Remove an SKU drink from the shelf


  1. Use .Net 6.0 for the backend.
 2. Provide funtion for communication with frontend.
 1. it can be either gRPC or API (like MagicOnion, OpenAPI)..
 3. Follow Clean Architecture principles to structure your backend (Entity, Gateway, Usecase, etc...).
 4. Ensure that the backend is scalable and deployable.
 5. (Bonus)Store data in an appropriate database(MongoDB, Redis, etc...).
 6. (Bonus)Ensure security measures are in place to prevent unauthorized access and data breaches.
 Your leader would also like you to cover the following:
 1. The backend must include Unit Tests and possibly Integration Tests.
 2. Implement interface designs to ensure Dependency Injection and modular