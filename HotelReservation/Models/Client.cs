using Prism.Mvvm;
using System.Reflection;

namespace HotelReservation.Models
{
    public class Client : BindableBase
    {
        private int id;
        private string fullName;
        private string phone;
        private string email;
        private string personalNumber;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }

        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string PersonalNumber
        {
            get { return personalNumber; }
            set { SetProperty(ref personalNumber, value); }
        }

        public void Copy(Client copy)
        {
            Id = copy.Id;
            FullName = copy.FullName;
            Phone = copy.Phone;
            Email = copy.Email;
            PersonalNumber = copy.PersonalNumber;
        }
    }
}
