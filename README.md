# EarlyBirdTest
There are two packages in the "database" one valid and one invalid. The valid package has the kolliId 999111111111111111 and the invalid package has the kolliId 999222222222222222.

The solution is a designed as a standard 3 layer solution with a database at the bottom, in this case substitued with a list. The database is accessed through a repository class with methods for reading and adding objects. Finally there is a service layer with validation and error handling that also uses the repository to access the database.

I have made unit tests for most of the components in the project but not for end to end testing. Instead I have used a Postman collection I generated from swagger for those tests.

To validate KolliIds and packages I have used the nuget package FluentValidation. With FluentValidation you can create collections of validation rules that is then applied to specific type of object to validate it.

For unit tests I have used NUnit3.

The project is developed .Net 6.