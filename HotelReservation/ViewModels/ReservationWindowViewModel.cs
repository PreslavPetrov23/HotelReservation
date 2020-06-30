using HotelReservation.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class ReservationWindowViewModel : BindableBase
    {
        public ReservationWindowViewModel()
        {
            this.Reservation = new Reservation();
        }
        public Reservation Reservation { get; set; }

        private Client selectedClient;

        public Client SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; }
        }
    }
}
