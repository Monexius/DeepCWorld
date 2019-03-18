using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.Services
{
    public class MockDataStore2 : IDataStore2<Exhibit>
    {
        List<Exhibit> exhibits;

        public MockDataStore2()
        {
            exhibits = new List<Exhibit>();
            var mockExhibits = new List<Exhibit>
            {
                new Exhibit { Id = Guid.NewGuid().ToString(), Name = "Piranha Exhibit1", Image1 = "image1",
                Image2 = "image2", Image3 = "image3", Text1 = "Fun Fact 1 about Piranhas 1",
                Text2 = "Fun Fact 2 about Piranhas 2", Text3 = "Fun Fact 3 about Piranhas 3" },
                new Exhibit { Id = Guid.NewGuid().ToString(), Name = "Piranha Exhibit2", Image1 = "image1",
                Image2 = "image2", Image3 = "image3", Text1 = "Fun Fact 1 about Piranhas 1",
                Text2 = "Fun Fact 2 about Piranhas 2", Text3 = "Fun Fact 3 about Piranhas 3" },
                new Exhibit { Id = Guid.NewGuid().ToString(), Name = "Piranha Exhibit3", Image1 = "image1",
                Image2 = "image2", Image3 = "image3", Text1 = "Fun Fact 1 about Piranhas 1",
                Text2 = "Fun Fact 2 about Piranhas 2", Text3 = "Fun Fact 3 about Piranhas 3" },
            };

            foreach (var exhibit in mockExhibits)
            {
                exhibits.Add(exhibit);
            }
        }

        public async Task<bool> AddItemAsync(Exhibit exhibit)
        {
            exhibits.Add(exhibit);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Exhibit exhibit)
        {
            var oldExhibit = exhibits.Where((Exhibit arg) => arg.Id == exhibit.Id).FirstOrDefault();
            exhibits.Remove(oldExhibit);
            exhibits.Add(exhibit);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldExhibit = exhibits.Where((Exhibit arg) => arg.Id == id).FirstOrDefault();
            exhibits.Remove(oldExhibit);

            return await Task.FromResult(true);
        }

        public async Task<Exhibit> GetItemAsync(string id)
        {
            return await Task.FromResult(exhibits.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Exhibit>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(exhibits);
        }
    }
}