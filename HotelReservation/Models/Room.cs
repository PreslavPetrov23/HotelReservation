namespace HotelReservation.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public string Extras { get; set; }

        //NumericUpDown
        public int RoomCapacity{ get; set; }

        public string RoomLocation { get; set; }
    }
}
