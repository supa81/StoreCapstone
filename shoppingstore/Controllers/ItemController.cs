using Microsoft.AspNetCore.Mvc;
using shoppingstore.Data.Repositories;
using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using shoppingstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {

            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;

        }
        public ViewResult List(string category)
        {
            IEnumerable<Item> items;
            string currentCategory = string.Empty;
            
            if (string.IsNullOrEmpty(category))
            {
                items = _itemRepository.Items.OrderBy(p => p.ItemId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Issa Vibe", _category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _itemRepository.Items.Where(p => p.Category.CategoryName.Equals("Issa Vibe"));

                }
                else 
                
                    items = _itemRepository.Items.Where(p => p.Category.CategoryName.Equals("Bougie Candles"));
                    currentCategory = _category;
                //items = _itemRepository.Items.Where(p => p.Category.CategoryName == category)
                //  .OrderBy(p => p.ItemId);
                //currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }
            var itemListViewModel = new ItemListViewModel
            {
                Items = items
                CurrentCategory = currentCategory
            }; 

            return View(new ItemListViewModel
            {
                Items = items,
                CurrentCategory = currentCategory
            });
        }
    }
}
