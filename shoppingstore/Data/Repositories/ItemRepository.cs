using Microsoft.EntityFrameworkCore;
using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        public ItemRepository(ApplicationDbContext appDbContext)
        {
            ApplicationDbContext = appDbContext;

        }
        //public IEnumerable<Item> Items => (IEnumerable<Item>)_appDbContext.ShoppingStoreEntities.Include(c => c.Categories);
        //public IEnumerable<Item> PreferredItems => (IEnumerable<Item>)_appDbContext.ShoppingStoreEntities.Where(p => p.Item.).Include(c => c.Categories);
        public IEnumerable<Item> Items => ApplicationDbContext.Items.Include(c => c.Category); 

        public IEnumerable<Item> PreferredItems =>ApplicationDbContext.Items.Where(p => p.IsPreferredItem).Include(c => c.Category);
        public Item GetItemById(int itemId) => ApplicationDbContext.Items.FirstOrDefault(p => p.ItemId == itemId);
        
            
        
    }

   
}
