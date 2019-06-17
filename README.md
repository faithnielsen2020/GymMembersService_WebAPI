### A Restful API project developed using ASP.Net WebAPI. It implements CRUD operations.
**For this project:**
* The Database (DB), tables and data were created using SQL with MSSQL Server -the scripts for doing this is contained in the file: **Data.txt**
* A Data Access Layer was created using a Classlibrary project and EntityFramework (EF) Database first approach - the files related
**Members.cs** and **Center.cs** are used by EF for generating entities from the DB. **Model folder** -> **GymMembers.cs**, this class is used for building the objects before delivering them to the requester. 
* The restful API for reading and writing to the database was created using an ASP.Net WebAPI project - this can be found in
  **Controller -> GymMembersController.cs** .
  

* To return all the records in the DB (GET)
  Example: <http://localhost:[portNumber]/api/members/>
  
* To return only one record from the DB (GET)
  Example:<http://localhost:[portNumber]/api/members/5>
  
* To update an existing record with the ID (PUT)
  Example: <http://localhost:[portNumber]/api/members/5>
  
* To delete a record with the ID 5 (POST)
  Example:<http://localhost:[portNumber]/api/members/5>
  
* To create a new object and save it in the DB (POST)
  Example:<http://localhost:[portNumber]/api/members/>  

* The services can be called using Postman or a Web Browser.
