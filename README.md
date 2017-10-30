# Reservation system for escape games
This is my Unicorn College semestral project in ASP .NET Core MVC.

The aim of this project is to implement simple reservation system for escape games.
This application allows customers to reserve single Escape Rooms for specific time and date.

### Business and Data Access Layer

Appliacation works with Room and Reservation Entities

#### Room

 Room represents single room which customer can reserve for specific time. Also all rooms are opened everyday. The Room has specific attributes.
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
 The page with booking for the current room



  

Cílem této práce je implementovat prototyp jednoduchého rezervačního systému, který si v některých ohledech zjednodušíme.
 Aplikace umožní rezervovat jednotlivé místnosti na určité časy a zároveň poskytne rozhraní pro jiné aplikace,
 které se budou na vybraná data z této aplikace dotazovat prostřednictvím REST API.
