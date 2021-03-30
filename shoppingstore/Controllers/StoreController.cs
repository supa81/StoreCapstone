using Microsoft.AspNetCore.Mvc;
using shoppingstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingstore.Controllers
{
    public class StoreController : Controller
    {
        ShoppingStoreEntities storeDB = new ShoppingStoreEntities();
        // GET: Store
        public ActionResult Index()
        {
            //var category = storeDB.Categories.ToList();
            var category = new List<Category>
            {
                 new Category{CategoryName = "All Candles"},
                 new Category{CategoryName = "Mood Candles"},
                 new Category{CategoryName = "Best sellers"}
            };

            return View(category);
        }
        public ActionResult Browse(string category)
        {
            //var categoryModel = storeDB.Categories.Include("Items")
            var categoryModel = new Category { CategoryName = category };
            return View(categoryModel);

        }
        public ActionResult Details(int id)
        {
            var Item = new Item { Name = "Item" + id };
            return View(Item);
        }

    }
}