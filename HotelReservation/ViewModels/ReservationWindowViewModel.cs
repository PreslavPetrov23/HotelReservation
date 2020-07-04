using HotelReservation.Models;
using HotelReservation.Repositories;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class ReservationWindowViewModel : BindableBase
    {
        private HotelRepository hotelRepository;
        private Reservation reservation;

        public ReservationWindowViewModel()
        {
            this.Reservation = new Reservation();
            hotelRepository = HotelRepository.Intance;
        }

        public Reservation Reservation
        {
            get { return reservation; }
            set { SetProperty(ref reservation, value); }
        }

        public ObservableCollection<Client> ClientsData
        {
            get
            {
                return hotelRepository.ClientService.Clients;
            }
        }

        public ObservableCollection<Room> RoomsData
        {
            get
            {
                return hotelRepository.RoomService.Rooms;
            }
        }
    }
}
