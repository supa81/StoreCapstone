using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Models.Interfaces
{
   public interface IItemRepository
    {
        IEnumerable<Item> Items {get;}
        IEnumerable<Item> PreferredItems {get;}

        Item GetItemById(int itemId);

    }
    
    
}
