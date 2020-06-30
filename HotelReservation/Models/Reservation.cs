using System;

namespace HotelReservation.Models
{
    public class Reservation 
    {
        public int Id { get; set; }

        public  DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comments { get; set; }

        public int ClientId { get; set; }

        public int RoomId { get; set; }
    }
}
