using HotelReservation.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HotelReservation.Services
{
    public class ClientService
    {
        public ClientService()
        {
            Clients = new ObservableCollection<Client>();
        }

        public ObservableCollection<Client> Clients { get; set; }
    }
}
