using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shoppingstore.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        public string ImageThumbNail { get; set; }
        public bool Instock { get; set; }
        public int stock { get; set; }

        public bool IsPreferredItem { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }

    }
}