Library Management System
The Library Management System is a web application designed to manage books, patrons, and borrowing records in a library. It provides APIs to perform various operations such as adding, updating, and deleting books and patrons, as well as borrowing books.

Project Structure
The project consists of the following components:

Controllers: Contains the API endpoints for managing books, patrons, and borrowing records.

AccountController: Manages user registration and authentication.
BookController: Manages operations related to books such as retrieval, addition, update, and deletion.
BorrowingBookController: Manages the borrowing process for books.
PatronController: Manages operations related to patrons such as retrieval, addition, update, and deletion.
DTO (Data Transfer Objects): Contains classes representing data transferred between the client and server.

LoginUserDTO: Data transfer object for user login.
RegisterUserDTO: Data transfer object for user registration.
Models: Contains entity classes representing domain objects.

ApplicationUser: Represents a user in the system.
Book: Represents a book in the library.
BorrowingRecord: Represents a borrowing record of a book by a patron.
Patron: Represents a patron or library member.
Repository: Contains interfaces and implementations for data access.

IBook: Interface for book-related operations.
IBorrow: Interface for borrowing-related operations.
IPatron: Interface for patron-related operations.
BookRepository: Implementation of book repository.
BorrowRepository: Implementation of borrowing repository.
PatronRepository: Implementation of patron repository.
Tests: Contains unit tests for controllers and repository classes.

Technologies Used
ASP.NET Core: Provides a framework for building web APIs.
Entity Framework Core: Used for data access and database operations.
Identity Framework: Provides user authentication and authorization functionalities.
JWT (JSON Web Tokens): Used for securing API endpoints and authentication.
Moq and Xunit: Libraries used for unit testing.
Setup and Usage
Clone the repository to your local machine.
Open the solution in Visual Studio or any preferred IDE.
Restore the NuGet packages and build the solution.
Update the database connection string in the appsettings.json file.
Run the application.
API Endpoints
Account

POST /api/account/register: Register a new user.
POST /api/account/login: Login and generate JWT token.
Books

GET /api/books: Retrieve a list of all books.
GET /api/books/{id}: Retrieve details of a specific book by ID.
POST /api/books: Add a new book to the library.
PUT /api/books/{id}: Update an existing book's information.
DELETE /api/books/{id}: Remove a book from the library.
Borrowing

POST /api/borrowingbook/{bookId}/patron/{patronId}: Borrow a book.
Patrons

GET /api/patrons: Retrieve a list of all patrons.
GET /api/patrons/{id}: Retrieve details of a specific patron by ID.
POST /api/patrons: Add a new patron to the system.
PUT /api/patrons/{id}: Update an existing patron's information.
DELETE /api/patrons/{id}: Remove a patron from the system.
Testing
The project includes unit tests for controllers and repository classes. These tests ensure that the API endpoints and data access operations function correctly under various scenarios.

Conclusion
The Library Management System provides a robust solution for managing library resources and facilitating borrowing activities. With its well-defined API endpoints and data access layer, it offers flexibility and scalability to meet the needs of libraries of different sizes.

