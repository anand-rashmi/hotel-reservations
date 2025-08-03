using System;

namespace HotelReservations
{
    public class Hotel
    {
        private int[,] roomBookings;
        private int totalRooms;
        private const int MaxBookingDays = 366;  // from day 0 to day 365
        private const string ACCEPT = "Accept";
        private const string DECLINE = "Decline";

        public Hotel(int size)
        {
            totalRooms = size;
            roomBookings = new int[totalRooms, MaxBookingDays];
        }

        public string BookRoom(int startDay, int endDay)
        {
            if (startDay < 0 || endDay >= MaxBookingDays || startDay > endDay)
                return DECLINE;

            for (int room = 0; room < totalRooms; room++)
            {
                bool roomAvailable = true;
                for (int day = startDay; day <= endDay; day++)
                {
                    if (roomBookings[room, day] == 1)
                    {
                        roomAvailable = false;
                        break;
                    }
                }

                if (roomAvailable)
                {
                    for (int day = startDay; day <= endDay; day++)
                    {
                        roomBookings[room, day] = 1;
                    }
                    return ACCEPT;
                }
            }

            return DECLINE;
        }
    }
}
