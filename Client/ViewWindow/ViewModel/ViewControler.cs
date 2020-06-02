using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ViewModel
{
    public class ViewControler : INotifyPropertyChanged
    {
        public DishViewModel dishViewModel;
        public ClientViewModel clientViewModel;


        private RestaurantManager restaurantManager;
        private ReportReceiver reportReceiver;
        private string startReportDate { get; set; }
        private string endReportDate { get; set; }
        private string reportIncome { get; set; }
        private List<string> dishesNames { get; set; }
        private string _advertText;

        private bool _delivery;
        public bool Delivery
        {
            get { return _delivery; }
            set
            {
                if (_delivery != value)
                {
                    _delivery = value;
                    PropertyChangedHandler("Delivery");
                }
            }
        }
        public string AdvertText
        {
            get { return restaurantManager.api.AdvertText; }
            set
            {
               if(_advertText != value)
                {
                    _advertText = value;
                    PropertyChangedHandler("AdvertText");
                }
                  
                
            }
        }


        public ObservableCollection<DishModel> Menu { get; set; }
        public ObservableCollection<DishModel> Card { get; set; }
        public ObservableCollection<ClientModel> Clients { get; set; }
        public ObservableCollection<OrderModel> ActiveOrders { get; set; }
        public ObservableCollection<OrderModel> CompletedOrders { get; set; }
        public ObservableCollection<DishModel> CurrentOrderDisplayDishes { get; set; }
        public ObservableCollection<OrderModel> ActiveDelivery { get; set; }
        public ObservableCollection<OrderModel> CompletedDeliveries { get; set; }
        public ObservableCollection<DishModel> CurrentDeliveryDisplayDishes { get; set; }



        public DishModel SelectedDish { get; set; }
        public ClientModel SelectedClient { get; set; }
        public OrderModel SelectedOrder { get; set; }
        public OrderModel SelectedDelivery { get; set; }


        public ICommand addDish { get; }
        public ICommand clearCard { get; }
        public ICommand createDish { get; }
        public ICommand addClient { get; }
        public ICommand createOrder { get; }
        public ICommand completeOrder { get; }
        public ICommand completeDelivery { get; }

        private DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1.0)
        };

        public ViewControler()
        {

            restaurantManager = new RestaurantManager(51359);
            
            dishViewModel = new DishViewModel(restaurantManager);
            clientViewModel = new ClientViewModel(restaurantManager);
            //restaurantManager.AddSampleData();
            dishesNames = new List<string>();
            Menu = new ObservableCollection<DishModel>();
            Card = new ObservableCollection<DishModel>();
            Clients = new ObservableCollection<ClientModel>();
            ActiveOrders = new ObservableCollection<OrderModel>();
            CompletedOrders = new ObservableCollection<OrderModel>();
            CurrentOrderDisplayDishes = new ObservableCollection<DishModel>();
            ActiveDelivery = new ObservableCollection<OrderModel>();
            CompletedDeliveries = new ObservableCollection<OrderModel>();
            CurrentDeliveryDisplayDishes = new ObservableCollection<DishModel>();


           

            reportReceiver = new ReportReceiver();
            reportReceiver.Subscribe(restaurantManager.getReportSender());

            addDish = new DelegateCommand(addDishToCard);
            clearCard = new DelegateCommand(Clear);
            addClient = new DelegateCommand(AddClient);
            createOrder = new DelegateCommand(CreateOrder);
            completeOrder = new DelegateCommand(CompleteOrder);
            completeDelivery = new DelegateCommand(CompleteDelivery);
            timer.Tick += (o, e) =>
            {
                AdvertText = restaurantManager.api.AdvertText;
            };
            timer.Start();


            RefreshView();
        }

        public void RefreshView()
        {
            Menu.Clear();
            Clients.Clear();
            ActiveOrders.Clear();
            CompletedOrders.Clear();
            ActiveDelivery.Clear();
            CompletedDeliveries.Clear();
            foreach (DishDTG dish in restaurantManager.GetMenu())
            {
                Menu.Add(new DishModel(dish));
            }

            foreach (ClientDTG client in restaurantManager.GetAllClients())
            {
                Clients.Add(new ClientModel(client));
            }
            foreach (OrderDTG order in restaurantManager.GetActiveOrders())
            {
                ActiveOrders.Add(new OrderModel(order));
            }
            foreach (OrderDTG order in restaurantManager.GetCompletedOrders())
            {
                CompletedOrders.Add(new OrderModel(order));
            }
            foreach (OrderDTG order in restaurantManager.GetActiveDeliveries())
            {
                ActiveDelivery.Add(new OrderModel(order));
            }
            foreach (OrderDTG order in restaurantManager.GetCompletedDeliveries())
            {
                CompletedDeliveries.Add(new OrderModel(order));
            }
        }
        public void RefreshOrderDishes()
        {
            CurrentOrderDisplayDishes.Clear();
            if (SelectedOrder != null)
            {

                foreach (DishDTG dish in restaurantManager.GetOrderById(SelectedOrder.Id).Dishes)
                {
                    CurrentOrderDisplayDishes.Add(new DishModel(dish));
                }
            }

        }
        public void RefreshDeliveryDishes()
        {
            CurrentDeliveryDisplayDishes.Clear();
            if (SelectedDelivery != null)
            {

                foreach (DishDTG dish in restaurantManager.GetDeliveryById(SelectedDelivery.Id).Dishes)
                {
                    CurrentDeliveryDisplayDishes.Add(new DishModel(dish));
                }
            }

        }
        private void addDishToCard()
        {
            DishModel tmp = SelectedDish;
            dishesNames.Add(tmp.Name);
            Card.Add(tmp);

        }

        private void Clear()
        {
            Card.Clear();
            dishesNames.Clear();
        }

        private void AddClient()
        {

        }
        private void CreateOrder()
        {
            if(SelectedClient != null)
            {
                restaurantManager.CreateOrder(SelectedClient.Name, DateTime.Now, Delivery, dishesNames, "", "", "", DateTime.Now.AddHours(1));                
                Clear();
                Delivery = false;
                RefreshView();
            }
           

        }
        private void CompleteOrder()
        {
            if(SelectedOrder != null)
            {
                restaurantManager.CompleteOrder(SelectedOrder.Id);
                RefreshView();
            }
            
        }
        private void CompleteDelivery()
        {
            if(SelectedDelivery != null)
            {
                restaurantManager.CompleteDelivery(SelectedDelivery.Id);
                RefreshView();
            }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }
}
