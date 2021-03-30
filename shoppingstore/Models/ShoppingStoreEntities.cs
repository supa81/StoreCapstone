using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shoppingstore.Models
{
    public class ShoppingStoreEntities
    {


        [Key]
        public int Id { get; set; }
        [NotMapped]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [NotMapped]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [NotMapped]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }




    }
}