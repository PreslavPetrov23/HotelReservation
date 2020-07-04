using HotelReservation.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class RoomWindowViewModel : BindableBase
    {
        private Room selectedRoom;

        public RoomWindowViewModel()
        {
            this.SelectedRoom = new Room();
        }

        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set { SetProperty(ref selectedRoom, value);}
        }
    }
}
