using HotelReservation.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HotelReservation.Services
{
    public class ReservationService
    {
        public ReservationService()
        {
            Reservations = new ObservableCollection<Reservation>();
        }
        
        public ObservableCollection<Reservation> Reservations { get; set; }
    }
}
