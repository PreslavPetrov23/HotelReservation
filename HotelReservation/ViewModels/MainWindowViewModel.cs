using HotelReservation.Models;
using HotelReservation.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Windows;

namespace HotelReservation
{

    public class MainWindowViewModel : BindableBase
    {
        private Client client;
        private Reservation reservation;
        private Invoice invoice;
        private Room room;
        private HotelRepository hotelRepository;
        private const string NameSearchType = "Name";
        private const string PhoneSearchType = "Phone";
        private const string PNSearchType = "Personal Number";
        private const string EmailSearchType = "Email";

        private string searchText;

        public MainWindowViewModel()
        {
            AddClientCommand = new DelegateCommand(OnAddClientCommand);
            DeleteClientCommand = new DelegateCommand(OnDeleteClientCommand, () => Client != null);
            UpdateClientCommand = new DelegateCommand(OnUpdateClientCommand, () => Client != null);

            AddReservationCommand = new DelegateCommand(OnAddReservationCommand);
            DeleteReservationCommand = new DelegateCommand(OnDeleteReservationCommand, () => Reservation != null);
            UpdateReservationCommand = new DelegateCommand(OnUpdateReservationCommand, () => Reservation != null);

            AddRoomCommand = new DelegateCommand(OnAddRoomCommand);
            DeleteRoomCommand = new DelegateCommand(OnDeleteRoomCommand, () => Room != null);
            UpdateRoomCommand = new DelegateCommand(OnUpdateRoomCommand, () => Room != null);

            AddInvoiceCommand = new DelegateCommand(OnAddInvoiceCommand);
            DeleteInvoiceCommand = new DelegateCommand(OnDeleteInvoiceCommand, () => Invoice != null);
            UpdateInvoiceCommand = new DelegateCommand(OnUpdateInvoiceCommand, () => Invoice != null); 

            SearchCommand = new DelegateCommand(OnSearchCommand, () => !string.IsNullOrWhiteSpace(SearchText));

            SearchTypeList = new List<string>();
            SearchTypeList.Add(NameSearchType);
            SearchTypeList.Add(PhoneSearchType);
            SearchTypeList.Add(PNSearchType);
            SearchTypeList.Add(EmailSearchType);

            hotelRepository = HotelRepository.Instance;
        }

        public ObservableCollection<Client> ClientsData
        {
            get
            {
                return hotelRepository.ClientService.Clients;
            }
        }

        public ObservableCollection<Reservation> ReservationData
        {
            get
            {
                return hotelRepository.ReservationService.Reservations;
            }
        }

        public ObservableCollection<Room> RoomsData
        {
            get
            {
                return hotelRepository.RoomService.Rooms;
            }
        }

        public ObservableCollection<Invoice> Invoices
        {
            get 
            {
                return hotelRepository.InvoiceService.Invoices;
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetProperty(ref searchText, value);
                SearchCommand.RaiseCanExecuteChanged();
            }

        }

        public List<string> SearchTypeList { get; set; }

        public DelegateCommand AddClientCommand { get; set; }

        public DelegateCommand DeleteClientCommand { get; set; }

        public DelegateCommand UpdateClientCommand { get; set; }

        public DelegateCommand AddReservationCommand { get; set; }

        public DelegateCommand DeleteReservationCommand { get; set; }

        public DelegateCommand UpdateReservationCommand { get; set; }

        public DelegateCommand AddRoomCommand { get; set; }

        public DelegateCommand DeleteRoomCommand { get; set; }

        public DelegateCommand UpdateRoomCommand { get; set; }

        public DelegateCommand SearchCommand { get; set; }

        public DelegateCommand AddInvoiceCommand { get; set; }

        public DelegateCommand DeleteInvoiceCommand { get; set; }

        public DelegateCommand UpdateInvoiceCommand { get; set; }

        public string SearchType { get; set; }

        public Client Client
        {
            get
            {
                return client;
            }

            set
            {
                SetProperty(ref client, value);
                DeleteClientCommand.RaiseCanExecuteChanged();
                UpdateClientCommand.RaiseCanExecuteChanged();
            }
        }

        public Reservation Reservation
        {
            get { return reservation; }
            set
            {
                SetProperty(ref reservation, value);
                DeleteReservationCommand.RaiseCanExecuteChanged();
                UpdateReservationCommand.RaiseCanExecuteChanged();
            }
        }

        public Room Room
        {
            get
            {
                return room;
            }

            set
            {
                SetProperty(ref room, value);
                DeleteRoomCommand.RaiseCanExecuteChanged();
                UpdateRoomCommand.RaiseCanExecuteChanged();
            }
        }

        public Invoice Invoice
        {
            get
            {
                return invoice;
            }

            set
            {
                SetProperty(ref invoice, value);
                DeleteInvoiceCommand.RaiseCanExecuteChanged();
                UpdateInvoiceCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnAddClientCommand()
        {

            ClientWindow window = new ClientWindow();

            bool? result = window.ShowDialog();

            if (result == true)
            {
                Client client = (window.DataContext as ClientWindowViewModel).Client;

                if (client != null)
                {
                    int maxId = 0;
                    if (ClientsData.Count != 0)
                    {
                        maxId = ClientsData.Select(x => x.Id).Max();
                    }
                    client.Id = maxId + 1;
                    ClientsData.Add(client);
                }
            }
        }

        private void OnDeleteClientCommand()
        {
            if (ClientsData.Contains(this.Client))
            {
                ClientsData.Remove(this.Client);
                this.Client = null;
            }
        }

        private void OnUpdateClientCommand()
        {
            if (ClientsData.Contains(this.Client))
            {
                ClientWindow window = new ClientWindow();

                Client currentClient = new Client();

                currentClient.Copy(Client);

                (window.DataContext as ClientWindowViewModel).Client = currentClient;

                bool? result = window.ShowDialog();

                if (result == true)
                {
                    client.Copy(currentClient);
                }
            }
        }

        private void OnAddRoomCommand()
        {
            RoomWindow window = new RoomWindow();

            bool? result = window.ShowDialog();

            if (result == true)
            {
                Room room = (window.DataContext as RoomWindowViewModel).SelectedRoom;

                if (room != null)
                {
                    int maxId = 0;
                    if (RoomsData.Count != 0)
                    {
                        maxId = RoomsData.Select(x => x.Id).Max();
                    }
                    room.Id = maxId + 1;
                    RoomsData.Add(room);
                }
            }
        }

        private void OnDeleteRoomCommand()
        {
            if (RoomsData.Contains(this.Room))
            {
                RoomsData.Remove(this.Room);
                this.Room = null;
            }
        }

        private void OnUpdateRoomCommand()
        {
            if (RoomsData.Contains(this.Room))
            {
                RoomWindow window = new RoomWindow();

                Room currentRoom = new Room();

                currentRoom.Copy(Room);

                (window.DataContext as RoomWindowViewModel).SelectedRoom = currentRoom;

                bool? result = window.ShowDialog();

                if (result == true)
                {
                    room.Copy(currentRoom);
                }
            }
        }

        private void OnAddReservationCommand()
        {
            ReservationWindow window = new ReservationWindow();

            bool? result = window.ShowDialog();

            if (result == true)
            {
                Reservation reservation = (window.DataContext as ReservationWindowViewModel).Reservation;

                if (reservation != null)
                {
                    int maxId = 0;
                    if (ReservationData.Count != 0)
                    {
                        maxId = ReservationData.Select(x => x.Id).Max();
                    }
                    reservation.Id = maxId + 1;
                    ReservationData.Add(reservation);
                }
            }
        }

        private void OnDeleteReservationCommand()
        {
            if (ReservationData.Contains(this.Reservation))
            {
                ReservationData.Remove(this.Reservation);
                this.Reservation = null;
            }
        }

        private void OnUpdateReservationCommand()
        {
            if (ReservationData.Contains(this.Reservation))
            {
                ReservationWindow window = new ReservationWindow();

                Reservation currentReservation = new Reservation();

                currentReservation.Copy(Reservation);

                (window.DataContext as ReservationWindowViewModel).Reservation = currentReservation;

                bool? result = window.ShowDialog();

                if (result == true)
                {
                    reservation.Copy(currentReservation);
                }
            }
        }

        private void OnSearchCommand()
        {
            Client foundClient = null;
            string messageText = null;
            switch (SearchType)
            {
                case NameSearchType:
                    foundClient = ClientsData.FirstOrDefault(x => x.FullName.Equals(SearchText.Trim()));
                    messageText = foundClient?.FullName;
                    break;

                case PhoneSearchType:
                    foundClient = ClientsData.SingleOrDefault(x => x.Phone.Equals(SearchText.Trim()));
                    messageText = foundClient?.Phone;
                    break;

                case PNSearchType:
                    foundClient = ClientsData.SingleOrDefault(x => x.PersonalNumber.Equals(SearchText.Trim()));
                    messageText = foundClient?.PersonalNumber;
                    break;

                case EmailSearchType:
                    foundClient = ClientsData.SingleOrDefault(x => x.Email.Equals(SearchText.Trim()));
                    messageText = foundClient?.Email;
                    break;
            }

            if (foundClient != null)
            {
                MessageBox.Show($"The list contains person with {SearchType.ToLower()}: {messageText} / On row: {ClientsData.IndexOf(foundClient) + 1}");
            }
            else
            {
                MessageBox.Show($"Not valid {SearchType.ToLower()}!");
            }
        }

        private void OnAddInvoiceCommand()
        {
            InvoiceWindow window = new InvoiceWindow();

            bool? result = window.ShowDialog();

            if (result == true)
            {
                Invoice invoice = (window.DataContext as InvoiceWindowViewModel).Invoice;

                if (invoice != null)
                {
                    int maxId = 0;
                    if (Invoices.Count != 0)
                    {
                        maxId = Invoices.Select(x => x.Id).Max();
                    }
                    invoice.Id = maxId + 1;
                    Invoices.Add(invoice);
                }
            }
        }

        private void OnDeleteInvoiceCommand()
        {
        }

        private void OnUpdateInvoiceCommand()
        {
        }
    }
}

