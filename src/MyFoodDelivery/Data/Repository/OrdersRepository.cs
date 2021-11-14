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
        private readonly MyFoodDbContent _myFoodDbContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(MyFoodDbContent myFoodDbContent, ShopCart shopCart)
        {
            this._myFoodDbContent = myFoodDbContent;
            this.shopCart = shopCart;  
        }
        public void createOrder(Order order) //добавление заказа в бд
            // и деталий о заказе
        {
            order.OrderTime = DateTime.Now;
            _myFoodDbContent.Orders.Add(order);
            _myFoodDbContent.SaveChanges();
            var items = shopCart.ListShopItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId=el.Product.Id,
                    OrderId=order.Id,
                    Price=el.Product.Price
                };
                _myFoodDbContent.OrderDetails.Add(orderDetail);
            }
            _myFoodDbContent.SaveChanges(); //TODO
        }
    }
}
