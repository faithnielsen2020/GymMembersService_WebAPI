### A Restful API project developed using ASP.Net WebAPI. It implements CRUD operations.
**For this project:**
* The Database (DB), tables and data were created using SQL with MSSQL Server -the scripts for doing this is contained in the file: **Data.txt**
* A Data Access Layer was created using a Classlibrary project and EntityFramework (EF) Database first approach - the files related
**Members.cs** and **Center.cs** are used by EF for generating entities from the DB. **Model folder** -> **GymMembers.cs**, this class is used for building the objects before delivering them to the requester. 
* The restful API for reading and writing to the database was created using an ASP.Net WebAPI project - this can be found in
  **Controller -> GymMembersController.cs** .

* The services can be called via Postman or a web Browser.

POST: http://localhost:53410/api/members/  --will create a new object with the given parameters and save it in the DB (create in the body, be aware that values must be privided for all the attributes that are defined as NOT NULL in the DB, otherwise it will throw an exception).
GET: http://localhost:53410/api/members/ --will return all the records from the DB
GET: http://localhost:53410/api/members/24  -- will return only 1 record with ID 24 from the DB (if ID does not exist, it will return a custom message)
PUT: http://localhost:53410/api/members/24  --will update an existing record with ID 24 (Use body in Postman => body->raw ->JSON(application/json). If the ID does not exist, it will return a custom message, otherwise the record with ID 24 will be updated).
POST: http://localhost:53410/api/members/24  --will delete a record with ID 24 (if ID does not exist, it will return a custom error message).
