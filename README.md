# Clean Architeture

## **Principles**

### **Separation of concerns**

Don’t let your plumbing code pollute your software. Avoid mixing different code reponsibilites in the same (method | class | project). The most common thought about that principle is about the big three: Data Acess, Business Rules/Domain Model and User Interface (Controllers)

### **Single Responsibility**

Avoid tightly coupling your tools. This principle works in tandem with Separation of Concerns. Classes should focus on a single responsibility—a single reason to change.

### Don’t Repeat Yourself

Repetition is the root of all software evil. To follow this principle, we should take the following steps:

- Refactor repetitive code into functions
- Group functions into cohesive classes
- Organize classes into folders and namespaces by:
  - Responsibility
  - Level of abstraction
- Further organize class folders into projects

### Dependecy Inversion

Would you solder a lamp directly to the electrical wiring in a wall? Both high-level classes and implementation-detail classes should depend on abstractions (interfaces).

Classes should follow the Explicit Dependencies Principle:

- Request all dependencies through their constructor
- Make your types honest, not misleading

Corollary: Abstractions/interfaces must be defined somewhere acessible by:

- Low level implementation services
- High level business services
- User interface entry points

### Make the right thing easy and the wrong thing hard

- Ui classes shouldn’t depend directly on infrastructure classes
  - How can we structure our solution to help enforce this
- Business/domain classes shouldn’t depend on infrastructure classes
  - How can our solution design help?
- Repetition of (query logic, validation logic, policies, error handling, anything ) is a problem
  - What patterns can we apply to make avoiding repetition easier than copy/pasting?

## N-Tier Architecture

The most common organization application logic into layers.

![image3](https://github.com/user-attachments/assets/ae9c4e7a-b56c-436b-b327-9bf65e4ae2b6)

These layers are frequently abbreviated as UI, BLL, and DAL. Using this architecture, users make requests through the UI layer, which interacts with the BLL layer. The BLL, in turn, can call the DAL for data access requests. The UI layer should not interact directly with the DAL, nor should it interact with persistence directly through other means. Likewise, the business logic layer (BLL) should only interact with persistence by going through the data access layer (DAL).

One disadvantage of this traditional layered approach is that compile-time dependencies run from top to bottom. In other words, the UI depends on the BLL, which depends on the DAL. This means that the BLL, which is usually the layer containing the application's most important business logic, is dependent on the data access implementation details (and often on the existence of a database). Testing business logic in such an architecture tends to be difficult because it requires a test database.

## Clean Architeture

Clean architecture puts the business logic and application model at the center of the application. Instead of having business logic depend on data access or other infrastructure concerns, this
dependency is inverted: infrastructure and implementation details depend on the Application Core. This functionality is achieved by defining abstractions, or interfaces, in the Application Core, which are then implemented by types defined in the Infrastructure layer.

![image1](https://github.com/user-attachments/assets/83994045-6b18-44b3-b299-58ecfe681d78)

![image](https://github.com/user-attachments/assets/29f40158-b72b-4d32-8008-7a3f8d48dac3)

### Organizing Code in Clean Architeture

In a Clean Architecture solution, ![image1](https://github.com/user-attachments/assets/8f43a9e5-be4a-4f7a-8b31-2cb4747aba61)
each project has clear responsibilities. As such, certain types belong
in each project and you’ll freq![image3](![image](https://github.com/user-attachments/assets/5aa61ed5-5a16-4498-ae1f-a04a57069dbb)
https://github.com/user-attachments/assets/f012a8de-7a96-4d44-aea3-1ff57cc15c26)
uently find folders corresponding to these types in the appropriate
project

### Advantages

- Framework indepedent
- Database indepedent
- UI indepedent
- Testable

### Application Core

The Application Core holds the business model, which includes entities, services and interfaces. These interfaces include abstractions for operations that will be performed using Infrastructure, such as data acess, file system acess, network calls, etc. Sometimes services or interfaces defined at this layer will need to work with non-entity type that have no dependencies on UI or Infrastructure. These can be defined as simple Data Transfer Objects (DTOs).

### **Application Core Types**

- Entities (business model classes that are persisted)
- Aggregates (group of entities)
- Interfaces
- Domain Services
- Specifications
- Custom Exceptions and Guard Clauses
- Domains Events and Handlers

### Infrastructure

The Infrastructure project typically includes data access implementations. In a typical [ASP.NET](http://asp.net/) Core web application, these implementations include the Entity Framework (EF) DbContext, any EF Core Migration objects that have been defined, and data access implementation classes. The most common way to abstract data access implementation code is through the use of the Repository design pattern.

In addition to data access implementations, the Infrastructure project should contain implementations of services that must interact with infrastructure concerns. These services should implement interfaces defined in the Application Core, and so Infrastructure should have a reference to the Application Core project.

### Infrastructure Types

- EF Core (DbContext, Migrations)
- Data acess implementations types (Repositories)
- Infrastructure-specific services (for example, FileLogger or SmtpNotifier)

### UI Layer

The user interface layer in [ASP.NET](http://ASP.NET) Core application is the entry point for the application. This project should reference the Application Core project, and its types should interact with infrastructure strictly through interfaces defined in Application Core. No direct instantiation or static calls to the Infrastructure layer types should be allowed in the UI layer.

### UI Layer types

- Controllers
- Custom Filters
- Custom Middleware
- Views
- ViewsModels
- Startup or Program

### Some Clean Architeture Rules

- The application core contains the domain model.
- All projects depend on the core project.
- Inner projects define interfaces.
- Outer projects implement these interfaces.
- Avoid direct dependencies on the infrastructure project.

### Shared Kernel

Is a special type of Bounded Context that contains code and data shared across multiple bounded contexts within the same domain. It acts as a central repository for ubiquitous language elements, domain logic, and data structures that are common to all or a subset of the bounded contexts.

### What Goes in Shared Kernel:

- Base Entity
- Base Domain Event
- Base Specification
- Common Exceptions
- Common interfaces
- Commom Auth
- Common DI
- Common Logging Commom Guard Clauses
