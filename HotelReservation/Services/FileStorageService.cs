using HotelReservation.Models;
using HotelReservation.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class FileStorageService
    {
        const string ClientFileName = "Clients.json";
        const string ReservationFileName = "Reservations.json";
        const string RoomsFileName = "Rooms.json";

        private HotelRepository hotelRepository;

        public FileStorageService()
        {
            hotelRepository = HotelRepository.Instance;
        }

        public void Open()
        {
            string json;
            if (File.Exists(ClientFileName))
            {
                json = File.ReadAllText(ClientFileName);
                var clients = JsonConvert.DeserializeObject<List<Client>>(json);
                hotelRepository.ClientService.Clients.Clear();
                hotelRepository.ClientService.Clients.AddRange(clients);
            }

            if (File.Exists(RoomsFileName))
            {
                json = File.ReadAllText(RoomsFileName);
                var rooms = JsonConvert.DeserializeObject<List<Room>>(json);
                hotelRepository.RoomService.Rooms.Clear();
                hotelRepository.RoomService.Rooms.AddRange(rooms);
            }

            if (File.Exists(ReservationFileName))
            {
                json = File.ReadAllText(ReservationFileName);
                var reservations = JsonConvert.DeserializeObject<List<Reservation>>(json);
                hotelRepository.ReservationService.Reservations.Clear();
                hotelRepository.ReservationService.Reservations.AddRange(reservations);

                foreach (Reservation reservation in reservations)
                {
                    reservation.Room = hotelRepository.RoomService.Rooms.FirstOrDefault(x => x.Id == reservation.RoomId);
                    reservation.Client = hotelRepository.ClientService.Clients.FirstOrDefault(x => x.Id == reservation.ClientId);
                }
            }
        }

        public void Save()
        {
            if (File.Exists(ClientFileName))
            {
                File.Delete(ClientFileName);
            }

            if (File.Exists(RoomsFileName))
            {
                File.Delete(RoomsFileName);
            }

            if (File.Exists(ReservationFileName))
            {
                File.Delete(ReservationFileName);
            }

            string json = JsonConvert.SerializeObject(hotelRepository.ClientService.Clients);
            if (!string.IsNullOrWhiteSpace(json) && json != "[]")
            {
                File.WriteAllText(ClientFileName, json);
            }

            json = JsonConvert.SerializeObject(hotelRepository.RoomService.Rooms);
            if (!string.IsNullOrWhiteSpace(json) && json != "[]")
            {
                File.WriteAllText(RoomsFileName, json);
            }

            json = JsonConvert.SerializeObject(hotelRepository.ReservationService.Reservations);
            if (!string.IsNullOrWhiteSpace(json) && json != "[]")
            {
                File.WriteAllText(ReservationFileName, json);
            }
        }
    }
}
