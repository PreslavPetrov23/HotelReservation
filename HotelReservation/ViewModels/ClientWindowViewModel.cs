using HotelReservation.Models;
using Prism.Mvvm;

namespace HotelReservation
{
    public class ClientWindowViewModel : BindableBase
    {
        private Client client;
        public ClientWindowViewModel()
        {
            this.Client = new Client();
        }

        public Client Client
        {
            get { return client; }
            set { SetProperty(ref client, value); }
        }
    }
}
