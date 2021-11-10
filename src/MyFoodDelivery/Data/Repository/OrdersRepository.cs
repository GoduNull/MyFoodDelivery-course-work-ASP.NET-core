using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly DbContent dbContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(DbContent dbContent, ShopCart shopCart)
        {
            this.dbContent = dbContent;
            this.shopCart = shopCart;  
        }
        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            dbContent.Order.Add(order);
            var items = shopCart.ListShopItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID=el.Car.Id,
                    OrderId=order.Id,
                    Price=el.Car.Price
                };
                dbContent.OrderDetail.Add(orderDetail);
            }
            dbContent.SaveChangesAsync();
        }
    }
}
