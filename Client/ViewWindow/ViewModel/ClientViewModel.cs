using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ClientViewModel : INotifyPropertyChanged
    {

        RestaurantManager restaurantManager;
        private string _clientName;
        private string _clientStreet;
        private string _clientNumber;
        private string _clientPostal;
        private string _clientPhone;

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                if (_clientName != value)
                {
                    _clientName = value;
                    PropertyChangedHandler("ClientName");
                }
            }
        }

        public string ClientStreet
        {
            get { return _clientStreet; }
            set
            {
                if (_clientStreet != value)
                {
                    _clientStreet = value;
                    PropertyChangedHandler("ClientStreet");
                }
            }
        }
        public string ClientNumber
        {
            get { return _clientNumber; }
            set
            {
                if (_clientNumber != value)
                {
                    _clientNumber = value;
                    PropertyChangedHandler("ClientNumber");
                }
            }
        }
        public string ClientPostal
        {
            get { return _clientPhone; }
            set
            {
                if (_clientPhone != value)
                {
                    _clientPhone = value;
                    PropertyChangedHandler("ClientPostal");
                }
            }
        }

        public string ClientPhone
        {
            get { return _clientPostal; }
            set
            {
                if (_clientPostal != value)
                {
                    _clientPostal = value;
                    PropertyChangedHandler("ClientPhone");
                }
            }
        }
        public ICommand addClient { get; }

        public ClientViewModel(RestaurantManager restaurantManager)
        {
            this.restaurantManager = restaurantManager;

            addClient = new DelegateCommand(AddClient);
            ClientName = "Imię Nazwisko";
        }

        private void AddClient()
        {
            Task.Run(() => restaurantManager.CreateClient(ClientName,ClientPhone,ClientStreet,ClientNumber,ClientPostal));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }
}
