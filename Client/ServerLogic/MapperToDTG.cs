﻿using Dane;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic
{
    public static class MapperToDTG
    {
        public static AddressDTG AddressDTG(Address adress)
        {
            return new AddressDTG()
            {
                Street = adress.Street,
                Number = adress.Number,
                PostalCode = adress.PostalCode
            };

        }

        public static ClientDTG ClientDTG(Client client)
        {
            return new ClientDTG()
            {
                Id = client.Id,
                Name = client.Name,
                PhoneNumber = client.PhoneNumber,
                Adress = AddressDTG(client.Adress)
            };

        }
        public static List<ClientDTG> ClientDTGs(List<Client> clients)
        {
            List<ClientDTG> newClients = new List<ClientDTG>();

            foreach(Client client in clients)
            {
                newClients.Add(ClientDTG(client));
            }
            return newClients;
        }

        public static ProductDTG ProductDTG(Product product)
        {
            return new ProductDTG()
            {
                Id = product.Id,
                Name = product.Name
            };

        }

        public static IngredientDTG IngredientDTG(Ingredient ingredient)
        {
            return new IngredientDTG()
            {
                Product = ProductDTG(ingredient.Product),
                Quantity = ingredient.Quantity
            };
        }

        public static List<IngredientDTG> IngredientDTGs(List<Ingredient> ingredients)
        {
            List<IngredientDTG> newIngredients = new List<IngredientDTG>();
            if (ingredients != null)
            {
                foreach (Ingredient ingr in ingredients)
                {
                    newIngredients.Add(IngredientDTG(ingr));
                }
            }
            return newIngredients;
        }

        public static DishDTG DishDTG(Dish dish)
        {
            return new DishDTG()
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Ingredients = IngredientDTGs(dish.Ingredients)  , 
                Price = dish.Price
            };
        }
        public static List<DishDTG> DishDTGs (List<Dish> dishes)
        {
            List<DishDTG> newDishes = new List<DishDTG>();
            if (dishes != null)
            {
                foreach (Dish dish in dishes)
                {
                    newDishes.Add(DishDTG(dish));
                }
            }
            return newDishes;
        }
        public static OrderDTG OrderDTG(Order order)
        {
            return new OrderDTG()
            {
                Id = order.Id,
                Client = ClientDTG(order.Client),
                OrderDate = order.OrderDate,
                Dishes = DishDTGs(order.Dishes),
                CompleteOrderDate = order.CompleteOrderDate,
                Delivery = order.Delivery,
                DeliveryAdress = AddressDTG(order.DeliveryAdress),
                DeliveryEndTime = order.DeliveryEndTime,
                TotalPrice = order.TotalPrice
            };
        }
        public static List<OrderDTG> OrderDTGs(List<Order> orders)
        {
            List<OrderDTG> newOrders = new List<OrderDTG>();
            foreach (Order order in orders)
            {
                newOrders.Add(OrderDTG(order));
            }
            return newOrders;
        }
        public static MenuDTG MenuDTG(Menu menu)
        {
            return new MenuDTG()
            {
                Id = menu.Id,
                Name = menu.Name,
                Dishes = DishDTGs(menu.Dishes)

            };

        }

    }
}