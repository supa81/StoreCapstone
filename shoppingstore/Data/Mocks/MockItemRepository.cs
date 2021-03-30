using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoppingstore.Data.Mocks
{
    public class MockItemRepository : IItemRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Item> Items
        {
            get
            {
                return new List<Item>
                {
                    new Item {
                        Name = "Candle 1",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        Instock = true,
                        stock = 10,
                        ShortDescription = "this is were the candle description will go",
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAGGgJwdg&sig=AOD64_2gyuTor8HrY3AfwQbd15Bdwon6Sw&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQwg96BAgBEFw"
                    },
                    new Item {
                        Name = "Candle 2",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAMGgJwdg&sig=AOD64_1dlf8qFvncZKZ6dmyFCmif4xTaIA&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BAgBEH8"
                    },
                    new Item {
                        Name = "Candle 3",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAHGgJwdg&sig=AOD64_34YeSCDwe3T81P7uT9sw6Bl2h_Qg&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BAgBEHg"
                    },
                   new Item {
                        Name = "Candle 4",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAQGgJwdg&sig=AOD64_2PsGA5koqDoG4zo_3KsOzrtYXCgQ&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BQgBEIkB"

                   }
                }; 
            }
        }
        public IEnumerable<Item> PreferredItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       // IEnumerable<Item> IItemRepository.Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Item GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
