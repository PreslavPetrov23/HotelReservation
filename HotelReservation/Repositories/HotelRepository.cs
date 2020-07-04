using HotelReservation.Models;
using HotelReservation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Repositories
{
    public class HotelRepository
    {
        private static HotelRepository hotelRepository;

        public static HotelRepository Intance
        {
            get
            {
                if (hotelRepository == null)
                {
                    hotelRepository = new HotelRepository();
                }

                return hotelRepository;
            }
        }

        private HotelRepository()
        {
            ClientService = new ClientService();
            ReservationService = new ReservationService();
            RoomService = new RoomService();
        }

        public ClientService ClientService { get; set; }

        public ReservationService ReservationService { get; set; }

        public RoomService RoomService { get; set; }
    }
}
