using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ViewModel
{
    public class ViewControler : INotifyPropertyChanged
    {
        public DishViewModel dishViewModel;
        public ClientViewModel clientViewModel;


        private RestaurantManager restaurantManager;
        private ReportReceiver reportReceiver;
        private ReportSender reportSender;
        private string startReportDate { get; set; }
        private string endReportDate { get; set; }
        private string reportIncome { get; set; }
        private List<string> dishesNames { get; set; }


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


        public ObservableCollection<Dish> Menu { get; set; }
        public ObservableCollection<Dish> Card { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Order> ActiveOrders { get; set; }
        public ObservableCollection<Order> CompletedOrders { get; set; }
        public ObservableCollection<Dish> CurrentOrderDisplayDishes { get; set; }
        public ObservableCollection<Order> ActiveDelivery { get; set; }
        public ObservableCollection<Order> CompletedDeliveries { get; set; }
        public ObservableCollection<Dish> CurrentDeliveryDisplayDishes { get; set; }



        public Dish SelectedDish { get; set; }
        public Client SelectedClient { get; set; }
        public Order SelectedOrder { get; set; }
        public Order SelectedDelivery { get; set; }


        public ICommand addDish { get; }
        public ICommand clearCard { get; }
        public ICommand createDish { get; }
        public ICommand addClient { get; }
        public ICommand createOrder { get; }
        public ICommand completeOrder { get; }
        public ICommand completeDelivery { get; }


        public ViewControler()
        {

            restaurantManager = new RestaurantManager();
            dishViewModel = new DishViewModel(restaurantManager);
            clientViewModel = new ClientViewModel(restaurantManager);
            restaurantManager.AddSampleData();
            dishesNames = new List<string>();
            Menu = new ObservableCollection<Dish>();
            Card = new ObservableCollection<Dish>();
            Clients = new ObservableCollection<Client>();
            ActiveOrders = new ObservableCollection<Order>();
            CompletedOrders = new ObservableCollection<Order>();
            CurrentOrderDisplayDishes = new ObservableCollection<Dish>();
            ActiveDelivery = new ObservableCollection<Order>();
            CompletedDeliveries = new ObservableCollection<Order>();
            CurrentDeliveryDisplayDishes = new ObservableCollection<Dish>();


            reportSender = new ReportSender(restaurantManager, 15000);
            Task.Run(() => reportSender.SendReport());

            reportReceiver = new ReportReceiver(startReportDate, endReportDate, reportIncome);
            reportReceiver.Subscribe(reportSender);

            addDish = new DelegateCommand(addDishToCard);
            clearCard = new DelegateCommand(Clear);
            addClient = new DelegateCommand(AddClient);
            createOrder = new DelegateCommand(CreateOrder);
            completeOrder = new DelegateCommand(CompleteOrder);
            completeDelivery = new DelegateCommand(CompleteDelivery);


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
            foreach (Dish dish in restaurantManager.GetMenu())
            {
                Menu.Add(dish);
            }

            foreach (Client client in restaurantManager.GetAllClients())
            {
                Clients.Add(client);
            }
            foreach (Order order in restaurantManager.GetActiveOrders())
            {
                ActiveOrders.Add(order);
            }
            foreach (Order order in restaurantManager.GetCompletedOrders())
            {
                CompletedOrders.Add(order);
            }
            foreach (Order order in restaurantManager.GetActiveDeliveries())
            {
                ActiveDelivery.Add(order);
            }
            foreach (Order order in restaurantManager.GetCompletedDeliveries())
            {
                CompletedDeliveries.Add(order);
            }
        }
        public void RefreshOrderDishes()
        {
            CurrentOrderDisplayDishes.Clear();
            if (SelectedOrder != null)
            {

                foreach (Dish dish in restaurantManager.GetOrderById(SelectedOrder.Id).Dishes)
                {
                    CurrentOrderDisplayDishes.Add(dish);
                }
            }

        }
        public void RefreshDeliveryDishes()
        {
            CurrentDeliveryDisplayDishes.Clear();
            if (SelectedDelivery != null)
            {

                foreach (Dish dish in restaurantManager.GetDeliveryById(SelectedDelivery.Id).Dishes)
                {
                    CurrentDeliveryDisplayDishes.Add(dish);
                }
            }

        }
        private void addDishToCard()
        {
            Dish tmp = SelectedDish;
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
