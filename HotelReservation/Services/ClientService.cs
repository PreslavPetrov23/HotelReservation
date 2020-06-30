using HotelReservation.Models;
using System.Collections.Generic;

namespace HotelReservation.Services
{
    class ClientService
    {
        public ClientService() 
        {
            Clients = new List<Client>();
        }

        public List<Client> Clients { get; set; }
    }
}
