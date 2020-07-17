using HotelReservation.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelReservation.Services
{
    public class RoomService
    {
        public RoomService()
        {
            Rooms = new ObservableCollection<Room>();

            Rooms.Add(new Room()
            {
                Id = 1,
                Extras = "One King Size Bed and One Person Bed",
                RoomCapacity = "3",
                RoomLocation = "Floor 15, Section 36",
                RoomNumber = "C23"
            });;

            Rooms.Add(new Room()
            {
                Id = 1,
                Extras = "One King Size Bed",
                RoomCapacity = "3",
                RoomLocation = "Floor 15, Section 36",
                RoomNumber = "C23"
            });

            Rooms.Add(new Room()
            {
                Id = 1,
                Extras = "Two King Size Beds and One Person Bed",
                RoomCapacity = "3",
                RoomLocation = "Floor 15, Section 36",
                RoomNumber = "C23"
            });
           
            Rooms.Add(new Room()
            {
                Id = 1,
                Extras = "Three King Size Bed",
                RoomCapacity = "3",
                RoomLocation = "Floor 15, Section 36",
                RoomNumber = "C23"
            });

        }

        

        public ObservableCollection<Room> Rooms { get; set; }
    }
}
