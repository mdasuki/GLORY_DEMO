# GLORY_DEMO
Train reservation demo project

NOTE: The source code is in master branch

Train reservation demo project is a sample C# project to allow a user to reserve a seat on a train.
The functionalities include:
1. Lists all trains displaying destination and departure time.
2. Enables a train to selected and a window or aisle seat to be booked.
3. In the event a desired seat is not available, offers the option to book another available seat.
4. If no seats are available, offers the option of picking a different train.

Solutions:
1. The project was built using VS2022 and .Net core 8. UI was built using WPF.
2. Database backend is SQLite.
3. Data layer is separated from the UI.  Data retrieval is using Dapper.
4. Business layer is skipped for simplicity.
5. On initial load, user will see a dropdown contains a list of train, departure time, and destination.
6. After selecting one from the dropdown, user will see the list of seats available.
7. User can select a seat.  Unavailable seats are grayed out and not selectable.  
8. Clear button removes the selection.  
9. Assign button, book the seat and then it becomes unavailable. 
