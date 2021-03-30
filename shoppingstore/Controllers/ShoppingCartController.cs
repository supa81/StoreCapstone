using Microsoft.AspNetCore.Mvc;
using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using shoppingstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IItemRepository itemRepository, ShoppingCart shoppingCart)
        {
            _itemRepository = itemRepository;
            _shoppingCart = shoppingCart;

        }
       public ViewResult Index()
       {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var SCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(SCVM); 
       }
        public RedirectToActionResult AddToShoppingCart(int itemId)
        {
            var selectedItem = _itemRepository.Items.FirstOrDefault(p => p.ItemId == itemId);
            if (selectedItem != null)
            {
                _shoppingCart.AddtoCart(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            var selectedItem = _itemRepository.Items.FirstOrDefault(p => p.ItemId == itemId);
            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");


        }
    }
}
