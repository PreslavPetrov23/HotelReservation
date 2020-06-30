using HotelReservation.Models;
using System.Collections.Generic;

namespace HotelReservation.Services
{
    public class ReservationService
    {
        public ReservationService()
        {
            Reservations = new List<Reservation>();
        }
        
        public List<Reservation> Reservations { get; set; }
    }
}
