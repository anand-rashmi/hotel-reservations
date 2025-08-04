# Hotel Reservations Assignment

Problem statement attached in problem-statement.pdf file

---

## Project Structure
- The class implementation is in HotelReservations project
- The test cases are in HotelReservations.Tests project

## Requirement
- .NET 9

## How to build and run tests
```bash
dotnet build HotelReservations.sln
dotnet test HotelReservations.sln
```

## Solution Approach
- Used a 2D array named `roomBookings[room, day]` to maintain a binary flag for a room availability on a specific day.
- Checking the complete availability of a room against the booking days.
- Only days in range 0–364 are valid. If booking end date falls before the start date then the booking is declined.

## Assumption based on problem statement notes
- No change of room i.e. the same room needs to be assigned for the complete stay period
- Direct acceptance of booking i.e. we do not wait for later requests to maximize the utilization of our rooms

## Contradiction in test cases observed
The problem statement notes mention that `If a booking request arrives and we can accept it, we accept it directly. We do not wait for later requests (e.g. to maximize the utilization of our rooms)`. In such case the test case number 5 with room size 2 will fail in below scenario - 
```bash
hotel.Book(1, 3);    // Room 1 booked for days 1, 2, 3
hotel.Book(0, 4);    // Room 2 booked for days 0, 1, 2, 3, 4
hotel.Book(2, 3);    // Declined since both rooms are booked already
hotel.Book(5, 5);    // Room 1 is booked 
```
Now, for `hotel.Book(4, 10)` test is expecting to accept this booking but the sytem will decline since both rooms are unavailable. This is working fine since it is mentioned in the problem statement that we do not need to wait for the future booking to maximise the utilization. It would have accepted the booking if `hotel.Book(5,5)` had been assigned previously to Room 2, but it contradicts with the requirement notes.

Please let me know in case I need to modify the code assuming we have to check for future utilization.


