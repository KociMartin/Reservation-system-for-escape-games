# Reservation system for escape games
This is my Unicorn College semestral project in ASP .NET Core MVC.

The aim of this project is to implement simple reservation system for escape games.
This application allows customers to reserve single Escape Rooms on specific time and date.

### Business and Data Access Layer

Application works with Room and Reservation Entities

#### Room

 Room represents single room, which customer can reserve for specific time. Also all rooms are opened everyday. The Room has specific attributes.
  *  Name
  *  Description
  *  Opening Hours 
  *  Reservations
  
  #### Reservation
  
  Reservation represents single reservation for one specific Room on specific time and date.
  Duration of single reservation lasts only one hour and starts only in full hour (:00). This application does not allow to manage customers.
  The customer just fill in form and creates reservation. 
  Reservation has specific attributes which are mandatory excluded description.
  *  Room (which is beeing reserved)
  *  Date and time of Reservation
  *  Customer's First Name
  *  Customer's Last Name
  *  Customer's Email
  *  Customer's Phone number
  *  Description
  
  All attributes have their specific constraints which are implemented in validations. 
  Perzistention is implemented with use of Entity Framework Core with Code First access.
  Application uses Dependancy Injection and IoC Container
  
 ### Presentation Layer 
 
 Application has a simple transparent design with use of HTML, CSS and Javascript(jQuery).
 
 Index page shows list of all Rooms, where each Room displays its name, description with tooltip and link to booking of the current Room.
 
 
![Alt text](../master/Images/Escape%20Games%201.png)


 The page with booking for the current room has in its upper part name of the chosen Room and Room description. Then there is a datepicker and back button. Customer picks desired hour in the right part which colors. When it is done Next button appears and customer can continue to the next step.
 
![Alt text](../master/Images/Escape%20Games%202.png) 


Here customer fills his credentials and Create Reservation which will be saved to database.

![Alt text](../master/Images/Escape%20Games%203.png) 

### REST API

Application contains REST API. API has two methods. 

First one will accept GET request with parameter - date in format yyyy.mm.dd And it returns list of all Rooms and information about free times for Reservations on current date and opening hours of specific Rooms.

Second one returns same informations but only for specific Room, which ID will be handed as a parameter 

Both methods return JSON.

URL of REST API: 

1)http://localhost/api/ReservationAPI/GetRoom/ID
                 
2)http://localhost/api/ReservationAPI/GetRooms/yyyy.mm.dd

#### TODO

*  API - Glitch. API methods does not show reservations correctly. Algorithm seems fine. Problem is probably in Data Access layer.
 

