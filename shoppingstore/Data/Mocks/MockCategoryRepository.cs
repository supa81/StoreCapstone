using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Issa Vibe", Description = "All Candles For Every Mood " },

                    new Category { CategoryName = "Bougie Candles", Description = "Smell The Good Stuff" }
                };
            }
        }
    }
}
