using Prism.Mvvm;
using System;

namespace HotelReservation.Models
{
    public class Room : BindableBase
    {
        private int id;

        private string roomNumber;

        private string extras;

        private string roomCapacity;

        private string roomLocation;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }


        public string RoomNumber
        {
            get { return roomNumber; }
            set { SetProperty(ref roomNumber, value); }
        }

        public string Extras
        {
            get { return extras; }
            set { SetProperty(ref extras, value); }
        }

        public string RoomCapacity {
            get { return roomCapacity; }
            set { SetProperty(ref roomCapacity, value); }
        }

        public string RoomLocation
        {
            get { return roomLocation; }
            set { SetProperty(ref roomLocation, value); }
        }

        public void Copy(Room copy)
        {
            Id = copy.Id;
            RoomNumber = copy.RoomNumber;
            Extras = copy.Extras;
            RoomCapacity = copy.RoomCapacity;
            RoomLocation = copy.RoomLocation;
        }
    }
}