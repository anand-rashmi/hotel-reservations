using Xunit;
using HotelReservations;

namespace HotelReservations.Tests
{
    public class HotelTests
    {
        [Fact]
        public void OutsideBookingPeriod_ShouldDecline()
        {
            var hotel = new Hotel(1);
            Assert.Equal("Decline", hotel.BookRoom(-4, 2));
            Assert.Equal("Decline", hotel.BookRoom(200, 400));
        }

        [Fact]
        public void RequestsAccepted_Size3()
        {
            var hotel = new Hotel(3);
            Assert.Equal("Accept", hotel.BookRoom(0, 5));
            Assert.Equal("Accept", hotel.BookRoom(7, 13));
            Assert.Equal("Accept", hotel.BookRoom(3, 9));
            Assert.Equal("Accept", hotel.BookRoom(5, 7));
            Assert.Equal("Accept", hotel.BookRoom(6, 6));
            Assert.Equal("Accept", hotel.BookRoom(0, 4));
        }

        [Fact]
        public void RequestsDeclined_Size3()
        {
            var hotel = new Hotel(3);
            Assert.Equal("Accept", hotel.BookRoom(1, 3));
            Assert.Equal("Accept", hotel.BookRoom(2, 5));
            Assert.Equal("Accept", hotel.BookRoom(1, 9));
            Assert.Equal("Decline", hotel.BookRoom(0, 15));
        }

        [Fact]
        public void RequestsAfterDecline_Size3()
        {
            var hotel = new Hotel(3);
            Assert.Equal("Accept", hotel.BookRoom(1, 3));
            Assert.Equal("Accept", hotel.BookRoom(0, 15));
            Assert.Equal("Accept", hotel.BookRoom(1, 9));
            Assert.Equal("Decline", hotel.BookRoom(2, 5));
            Assert.Equal("Accept", hotel.BookRoom(4, 9));
        }

        [Fact]
        public void Complex_Requests_Size2()
        {
            var hotel = new Hotel(2);
            Assert.Equal("Accept", hotel.BookRoom(1, 3));
            Assert.Equal("Accept", hotel.BookRoom(0, 4));
            Assert.Equal("Decline", hotel.BookRoom(2, 3));
            Assert.Equal("Accept", hotel.BookRoom(5, 5));
            Assert.Equal("Accept", hotel.BookRoom(4, 10));
            Assert.Equal("Accept", hotel.BookRoom(10, 10));
            Assert.Equal("Accept", hotel.BookRoom(6, 7));
            Assert.Equal("Decline", hotel.BookRoom(8, 10));
            Assert.Equal("Accept", hotel.BookRoom(8, 9));
        }
    }
}
