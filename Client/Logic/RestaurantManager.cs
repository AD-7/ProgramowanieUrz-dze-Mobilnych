
using Dane;
using Logic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class RestaurantManager
    {
        public API api;

        private int currentOrderIndex;

        public RestaurantManager(int portNumber)
        {
            currentOrderIndex = 0;
            Task.WaitAll(Task.Run(() => ConnectAsync(portNumber)));

        }

        public RestaurantManager(API api)
        {
            currentOrderIndex = 0;
            this.api = api;
        }

        public ReportSender getReportSender()
        {
            return api.GetReportSender();
        }

        private async System.Threading.Tasks.Task ConnectAsync(int portNumber)
        {
            Uri _uri = new Uri($@"ws://localhost:{portNumber}/");
            WebSocketConnection socketConnection = await WebSocketClient.Connect(_uri, LogToConsole);
            socketConnection.onMessage = LogToConsole;
            this.api = new API(socketConnection);
            this.api.GetReportSender();
        }

        private void LogToConsole(string obj)
        {
            Console.WriteLine(obj);
        }

        public void AddSampleData()
        {
            this.CreateDish("testDish", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 15.50);
            this.CreateDish("testDish1", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 12.50);
            this.CreateDish("testDish2", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 8.50);
            this.CreateDish("testDish3", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 5.50);
            this.CreateClient("Imie Nazwisko", "606060606", "", "", "");
        }


        public void CreateClient(string name, string phoneNumber, string street, string number, string postalCode)
        {
            if (api != null)
            {
                Address address = new Address(street, number, postalCode);
                api.CreateClient(name, phoneNumber, address);
            }

        }

        public void CreateDish(string name, string description, List<IngredientDTG> ingredients, CategoryDTG category, double price)
        {
            if (api != null)
            {
                List<Ingredient> ingredientss = new List<Ingredient>();
                if (ingredients != null)
                {
                    foreach (IngredientDTG dtg in ingredients)
                    {
                        ingredientss.Add(new Ingredient(new Product(dtg.Product.Id, dtg.Product.Name), dtg.Quantity));
                    }
                }

                api.AddDishToMenu(name, description, ingredientss, (int)category, price);
            }


        }

        /*public void CreateOrder(ClientDTG client, DateTime orderDate, List<DishDTG> dishes, bool delivery, AddressDTG deliveryAddress, DateTime deliveryEndTime)
        {
           
            Client tmp = new Client(client.Id, client.Name, client.PhoneNumber, new Address(client.Adress.Street, client.Adress.Number, client.Adress.PostalCode));
            if (delivery)
            {
                deliveryManager.CreateOrder(currentOrderIndex, tmp, orderDate, dishes, delivery, new Address(deliveryAddress.Street,deliveryAddress.Number,deliveryAddress.PostalCode), deliveryEndTime);
            }
            else
            {
                orderManager.CreateOrder(currentOrderIndex, tmp, orderDate, dishes, delivery, new Address(deliveryAddress.Street, deliveryAddress.Number, deliveryAddress.PostalCode), deliveryEndTime);
            }
            currentOrderIndex++;

        }*/

        public void CreateOrder(string clientName, DateTime orderDate, bool delivery, List<string> dishesNames, string street, string number, string postalCode, DateTime deliveryEndTime)
        {
            if (api != null)
            {
                // Client client = api.GetClientByName(clientName);
                Address deliveryAddress = new Address(street, number, postalCode);
                List<Dish> dishes = new List<Dish>();
                string dishesstr = "";
                foreach (string dishName in dishesNames)
                {
                    //   dishes.Add(api.GetDishByName(dishName));
                    dishesstr += dishName + ",";
                }
                dishesstr = dishesstr.TrimEnd(',');
                //if (delivery)
                //{
                //    api.CreateOrder(currentOrderIndex, client, orderDate, dishes, delivery, deliveryAddress, deliveryEndTime);
                //}
                //else
                //{
                api.CreateOrder(currentOrderIndex, clientName, orderDate, dishesstr, delivery, deliveryAddress, deliveryEndTime);

                //}
            }
        }

        public void CompleteOrder(int Id)
        {
            if (api != null)
                api.CompleteOrder(Id);
        }

        public void CompleteDelivery(int Id)
        {
            if (api != null)
                api.CompleteDelivery(Id);
        }

        public List<DishDTG> GetMenu()
        {
            if (api != null)
            {
                return api.GetMenu();
            }

            return new List<DishDTG>();
        }

        public List<OrderDTG> GetActiveOrders()
        {
            if (api != null)
                return api.GetActiveOrders();
            return new List<OrderDTG>();
        }

        public List<OrderDTG> GetActiveDeliveries()
        {
            if (api != null)
                return api.GetActiveDeliveries();
            return new List<OrderDTG>();
        }
        public List<OrderDTG> GetCompletedDeliveries()
        {
            if (api != null)
                return api.GetCompletedDeliveries();
            return new List<OrderDTG>();
        }
        public List<OrderDTG> GetCompletedOrders()
        {
            if (api != null)
                return api.GetCompletedOrders();
            return new List<OrderDTG>();
        }
       

        public DishDTG GetDishById(int Id)
        {
            if (api != null)
                return MapperToDTG.DishDTG(api.GetDishById(Id));
            return new DishDTG();
        }
        public List<ClientDTG> GetAllClients()
        {
            if (api != null)
                return api.GetAllClients();
            return new List<ClientDTG>();
        }
        public OrderDTG GetOrderById(int Id)
        {
            if (api != null)
                return api.GetActiveOrderById(Id);
            return new OrderDTG();

        }
        public OrderDTG GetDeliveryById(int Id)
        {
            if (api != null)
                return api.GetDeliveryById(Id);
            return new OrderDTG();
        }

        public IncomeReport GenerateIncomeReport(DateTime from, DateTime to)
        {
            /* lock (criticalSection)
             {
                 double income = 0.0;
                 foreach (Order order in orderManager.CompletedOrders)
                 {
                     if (order.CompleteOrderDate > from && order.CompleteOrderDate < to)
                     {
                         income += order.TotalPrice;
                     }
                 }

                 foreach (Order order in deliveryManager.DeliveryCompleted)
                 {
                     if (order.CompleteOrderDate > from && order.CompleteOrderDate < to)
                     {
                         income += order.TotalPrice;
                     }
                 }
                 return new IncomeReport(income, from, to);
             }*/
            return new IncomeReport(0, System.DateTime.Now, System.DateTime.Now);
        }



    }
}
