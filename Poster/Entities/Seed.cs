using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Poster.Entities
{
    internal class Seed
    {
        internal static ObservableCollection<User> listOfUsers = new ObservableCollection<User>();
        internal static ObservableCollection<Item> listOfItems = new ObservableCollection<Item>();
        internal static ObservableCollection<Order> listOfOrders = new ObservableCollection<Order>();
        internal static ObservableCollection<ItemsInOrder> listOfItemsInOrder = new ObservableCollection<ItemsInOrder>();

        public static void SeedAllObjects()
        {
            listOfUsers.Add(new User
            {
                Id = 1,
                Name = "Катя",
                Login = "user",
                Password = "1111",
                 DateOfBirth = Convert.ToDateTime("12.02.2002")
            });

            listOfUsers.Add(new User
            {
                Id = 2,
                Name = "Admin",
                Login = "admin",
                Password = "1111",
                Status = "admin",
                DateOfBirth = Convert.ToDateTime("10.04.1998")
            });

            listOfItems.Add(
                new Item
                {
                    Name = "Кофе",
                    Cost = 1.35,
                    Id = 1,
                });
            listOfItems.Add(
                new Item
                {
                    Name = "Чай",
                    Cost = 1.35,
                    Id = 2,
                });
            listOfItems.Add(
                new Item
                {
                    Name = "Булочка DELETED",
                    Cost = 1.35,
                    Id = 3,
                    IsDeleted = true
                });

            listOfItemsInOrder.Add(new ItemsInOrder
            {
                Item = listOfItems[0],
                OrderID = 0,
                Count = 2,
            });

            listOfItemsInOrder.Add(new ItemsInOrder
            {
                Item = listOfItems[1],
                OrderID = 1,
                Count = 1,
            });

            listOfItemsInOrder.Add(new ItemsInOrder
            {
                Item = listOfItems[2],
                OrderID = 2,
                Count = 2,
            });

            var orderFirst = new Order
            {
                Cost = getCost(1),
                Id = 1,
                Created = DateTime.Now,
                User = listOfUsers.Where(x => x.Id == 1).First(),
            };
            listOfOrders.Add(orderFirst);

            var orderSecond = new Order
            {
                Cost = getCost(2),
                Id = 2,
                Created = DateTime.Now,
                User = listOfUsers.Where(x => x.Id == 1).First(),
            };
            listOfOrders.Add(orderSecond);
        }

        public static List<User> getListOfUser()
        {
            return listOfUsers.Where(x => x.IsDeleted == false).ToList();
        }

        public static List<Item> getListOfItem()
        {
            return listOfItems.Where(x => x.IsDeleted == false).ToList();
        }

        public static List<Order> getListOfOrders()
        {
            return listOfOrders.ToList();
        }

        public static List<ItemsInOrder> getListOfItemsInOrderById(int orderId)
        {
            return listOfItemsInOrder.Where(x => x.OrderID == orderId).ToList();
        }

        public static User getUser(string login)
        {
            return listOfUsers.Where(x => x.Login == login && !x.IsDeleted).FirstOrDefault();
        }
        
        public static User GetUser(int userId)
        {
            return listOfUsers.Where(x => x.Id == userId).FirstOrDefault();
        }
        
        public static Item GetItem(int itemId)
        {
            return listOfItems.Where(x => x.Id == itemId).FirstOrDefault();
        }

        public static void addUser(string name, string login, string password, DateTime dateOfBirth, string phone, string status)
        {
            listOfUsers.Add(new User
            {
                Id = listOfUsers.Count() + 1,
                Name = name,
                Login = login,
                Password = password,
                Phone = phone,
                DateOfBirth = dateOfBirth,
                Status = status == "" ? "user" : status
            }) ;
        }

        public static void addItem(string name, double cost)
        {
            listOfItems.Add(new Item
            {
                Id = listOfItems.Count() + 1,
                Cost = cost,
                Name = name,
            });
        }

        public static void updateItem(int itemId, string cost, string name)
        {
            foreach (var item in listOfItems)
            {
                if (item.Id == itemId)
                {
                    item.Cost = Convert.ToDouble(cost);
                    item.Name = name;
                }
            }
        }

        public static void updateUser(int id, string name, string login, string password, string phone, DateTime dateOfBirth, string status)
        {
            foreach (var user in listOfUsers)
            {
                if (user.Id == id)
                {
                    user.Name = name;
                    user.Login = login;
                    user.Password = password;
                    user.Phone = phone;
                    user.DateOfBirth = dateOfBirth;
                    user.Status = status;
                }
            }
        }

        public static void deleteItem(int itemId)
        {
            foreach (var item in listOfItems)
            {
                if (item.Id == itemId)
                {
                    item.Name += " DELETED";
                    item.IsDeleted = true;
                }
            }
        }
        
        public static void deleteUser(int userId)
        {
            foreach (var user in listOfUsers)
            {
                if(user.Id == userId)
                {
                    user.Name += " DELETED";
                    user.IsDeleted = true;
                }
            }
        }
        
        private static double getCost(int id) => Math.Round(listOfItemsInOrder.Where(x => x.OrderID == id).Sum(x => x.Item.Cost * x.Count), 2);
    }
}
