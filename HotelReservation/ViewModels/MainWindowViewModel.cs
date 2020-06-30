using HotelReservation.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelReservation
{

    public class MainWindowViewModel : BindableBase
    {
        private Client client;

        public MainWindowViewModel()
        {
            ClientsData = new ObservableCollection<Client>();

            AddClientCommand = new DelegateCommand(OnAddClientCommand);
            DeleteClientCommand = new DelegateCommand(OnDeleteClientCommand, () => Client != null);
            UpdateClientCommand = new DelegateCommand(OnUpdateClientCommand, () => Client != null);
        }

        public ObservableCollection<Client> ClientsData { get; set; }

        public DelegateCommand AddClientCommand { get; set; }

        public DelegateCommand DeleteClientCommand { get; set; }

        public DelegateCommand UpdateClientCommand { get; set; }

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
    }
}

