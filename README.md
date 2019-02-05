# Railway Booking Management System
Version: 1.0.0 
Author: Toby Cook

The function of this application is to manage bookings for trains travelling between Edinburgh (Waverley) and London (Kings Cross). Users can add three types of trains: Sleeper, Express and Stopping. Once a train as been added to the system, bookings can be added to the train.

Features include:
 - Add Sleeper, Express or Stopping train
 - Add bookings to train
 - View list of trains running between two stations
 - View list of trains running on selected day
 
 ## Object-Oriented Design
The system has been implemented with a heavy focus on object orientation. There are three train child classes (Sleeper, Express and Stopping) that inherit most of their properties from the Train parent class. 

- Each train contains a list of Coach objects that are created along with the train. 
- Each Coach contains a list of Booking objects.

## Design Patterns
For this coursework we could implement up to two design patterns. I opted for the Factory and Singleton design patterns.
### Factory Pattern
The first design pattern I implemented was the factory design pattern. This is because I could pass the TrainFactory class a variety of arguments and it would make a decision on what train to create based off of those arguments.
### Singleton Pattern
The second design pattern I implemented was the singleton design pattern on my data layer. The reason for this is because it would only allow one instance of my data storage class to be created.

## Three Tier Architecture
We were required to implement a three-tier architecture for our coursework, splitting it into Business, Data and Presentation layers. The benefit of this approach means that because it is more modular, the application is easier to scale or swap out one part for another. For example, I currently use a WPF form for presentation, but could swap that interface for a web application.
