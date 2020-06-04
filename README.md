# Assessment
## How to run the program

The project is designed following a microservice architecture. To start up all the services at once double click on the StartAllServices.bat file. Alternatively, you will need to run each service separately.

## Project Layout
The project is laid out into 4 different parts. 
**Assessment.TaxCalculator**
This is the core of the project and meets the primary objective of the assessment.  It runs on the following address: http://localhost:5020, 
- To view its swagger file: http://localhost:5020/swagger/index.html
- A factory design pattern is used in the Tax Calculations
- The CQRS pattern is used to separate concerns.

**Assessment.Web**
This is the frontend/user interface of the project. It runs on the following address: [http://localhost:5001/](http://localhost:5001/)

**Assessment.identityserver4**
This is the part of the system responsible for user authentication.

 - To add a new user simply go to :
   [http://localhost:5010/](http://localhost:5010/)
- This project makes use of identityserver4.

**Assessment.gateway**
This is the final part of the project. It runs on the following address: http://localhost:5005

 - This acts as a gateway between our frontend (Assessment.Web)  and the 
core of the system (Assessment.TaxCalculator)
- The main purpose of this system is to make sure only authenticated requests are forwarded to the core of the system.
- This has the benefit of further separating responsibility in that the core service (Assessment.TaxCalculator), should only be worried about calculating the different Tax, without having to worry about whether one is authenticated or not.

