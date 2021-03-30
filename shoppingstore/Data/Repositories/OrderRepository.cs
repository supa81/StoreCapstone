﻿using shoppingstore.Data.Interfaces;
using shoppingstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ItemId = shoppingCartItem.Item.ItemId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Item.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }


}


