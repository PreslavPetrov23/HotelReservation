using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Security.Cryptography.X509Certificates;

namespace HotelReservation.Models
{
    public class Reservation : BindableBase
    {
        private int id;
        private DateTime startDate = DateTime.Today;
        private DateTime endDate = DateTime.Today;
        private string comments;
        private int clientId;
        private int roomId;
        private Client client;
        private Room room;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { SetProperty(ref startDate, value); }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { SetProperty(ref endDate, value); }
        }

        public string Comments
        {
            get { return comments; }
            set { SetProperty(ref comments, value); }
        }

        public int ClientId
        {
            get { return clientId; }
            set { SetProperty(ref clientId, value); }
        }

        public int RoomId
        {
            get { return roomId; }
            set { SetProperty(ref roomId, value); }
        }

        [JsonIgnore]
        public Room Room
        {
            get { return room; }
            set { SetProperty(ref room, value); }
        }

        [JsonIgnore]
        public Client Client
        {
            get { return client; }
            set { SetProperty(ref client, value); }
        }

        public void Copy(Reservation copy)
        {
            Id = copy.Id;
            StartDate = copy. StartDate;
            EndDate = copy.EndDate;
            Comments = copy.Comments;
            ClientId = copy.ClientId;
            RoomId = copy.RoomId;
            Room = copy.Room;
            Client = copy.Client;
        }
    }
}
