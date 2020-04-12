using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InStockNearMe.Models;

namespace InStockNearMe.Services
{
    public class MockDataStore : IDataStore<CartItem>
    {
        readonly List<CartItem> items;

        public MockDataStore()
        {
            items = new List<CartItem>()
            {
               // new CartItem { Id = Guid.NewGuid().ToString(), Text = "First item", Quantity="Item Quantity." },
               // new CartItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Quantity="Item Quantity." },
               // new CartItem { Id = Guid.NewGuid().ToString(), Text = "Third item", Quantity="Item Quantity." },
               // new CartItem { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Quantity="Item Quantity." },
               // new CartItem { Id = Guid.NewGuid().ToString(), Text = "Fifth item",Quantity="Item Quantity." },
               // new CartItem { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Quantity="Item Quantity." }
            };
        }

        public async Task<bool> AddItemAsync(CartItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CartItem item)
        {
            var oldItem = items.Where((CartItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((CartItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CartItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CartItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}