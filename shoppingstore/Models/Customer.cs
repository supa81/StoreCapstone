﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Models
{
    public class Customer
    {

        [Key]
        [DisplayName("Member Id")]
        public int Id { get; set; }


        [DisplayName("Address")]
        public string Address { get; set; }


        [DisplayName("CategoryName")]
        public string Name { get; set; }


        [DisplayName("ZipCode")]
        public int ZipCode { get; set; }

        [DisplayName("Balance")]
        public decimal Balance { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
       



    }
}
