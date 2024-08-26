Train reservation demo project

Train reservation demo project is a sample C# project to allow a user to reserve a seat on a train. The functionalities include:

Lists all trains displaying destination and departure time.
Enables a train to selected and a window or aisle seat to be booked.
In the event a desired seat is not available, offers the option to book another available seat.
If no seats are available, offers the option of picking a different train.
Solutions:

The project was built using VS2022 and .Net core 8. UI was built using WPF.
Database backend is SQLite.
Data layer is separated from the UI. Data retrieval is using Dapper.
Business layer is skipped for simplicity.
On initial load, user will see a dropdown contains a list of train, departure time, and destination.
After selecting one from the dropdown, user will see the list of seats available.
User can select a seat. Unavailable seats are grayed out and not selectable.
Clear button removes the selection.
Assign button, book the seat and then it becomes unavailable.
