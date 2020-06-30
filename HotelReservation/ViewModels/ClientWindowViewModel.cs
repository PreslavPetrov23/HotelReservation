using HotelReservation.Models;
using Prism.Mvvm;

namespace HotelReservation
{
    public class ClientWindowViewModel : BindableBase
    {
        public ClientWindowViewModel()
        {
            this.Client = new Client();
        }

        private Client client;

        public Client Client
        {
            get { return client; }
            set { SetProperty(ref client, value); }
        }
    }
}
