using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Time = "10:30", Name="Meet a Reptile", Location="Shark Classroom"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "11:00", Name="Daily Morning Feed", Location="Various"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "11:30", Name="Seal Feed", Location= "Seal Harbour"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "12:00", Name="Rockpool Encounter", Location="Rockpool Main Hall"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "12:30", Name="Seahorse Talk", Location="Rockpool Main Hall"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "13:00", Name="Ocean Feed", Location="Underwater Tunnel"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "13:30", Name="Rain Forest Talk", Location="The Swamp"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "14:00", Name="Creepy Crawly Encounter", Location="Shark Classroom"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "14:30", Name="Daily Afternoon Feed", Location="Various"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "15:00", Name="Seal Feed", Location="Seal Harbour"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "15:30", Name="Meet a Reptile", Location="Shark Classroom"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "16:00", Name="Underwater Safari", Location="Underwater Tunnel"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "16:30", Name="Rockpool Encounter", Location="Rockpool Main Hall"},
                new Item { Id = Guid.NewGuid().ToString(), Time = "17:00", Name="Creepy Crawly Encounter", Location="Shark Classroom"},
                               
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }

        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

       public static Item getItemByTime(string time)
        {
            Item item = new Item { Id = Guid.NewGuid().ToString(), Time = "10:30", Name = "Meet a Reptile", Location = "Shark Classroom" };
            return item;
        }
    }
}