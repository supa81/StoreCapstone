using shoppingstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.ViewModels
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Items { get; set; }

        public string CurrentCategory { get; set; }

    }
}
