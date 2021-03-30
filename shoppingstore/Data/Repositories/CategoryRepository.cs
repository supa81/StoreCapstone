﻿using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _appDbContext;
        public CategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories;

    }
}
