using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class MockDataStore2 : IDataStore2<Exhibition>
    {
        List<Exhibition> exhibitions;

        public MockDataStore2()
        {
            exhibitions = new List<Exhibition>();
            var mockExhibits = new List<Exhibition>
            {
                new Exhibition { Exhibition_ID = 0, Exhibition_Name = "Piranha Exhibit1", Exhibition_IMG = "image1",
                Exhibition_Description = "Fun Fact 1 about Piranhas 1",
                Exhibition_Video="video1" },
            };

            foreach (var exhibit in mockExhibits)
            {
                exhibitions.Add(exhibit);
            }
        }

        public async Task<bool> AddItemAsync(Exhibition exhibition)
        {
            exhibitions.Add(exhibition);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Exhibition exhibition)
        {
            var oldExhibit = exhibitions.Where((Exhibition arg) => arg.Exhibition_ID == exhibition.Exhibition_ID).FirstOrDefault();
            exhibitions.Remove(oldExhibit);
            exhibitions.Add(exhibition);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldExhibit = exhibitions.Where((Exhibition arg) => arg.Exhibition_ID == id).FirstOrDefault();
            exhibitions.Remove(oldExhibit);

            return await Task.FromResult(true);
        }

        public async Task<Exhibition> GetItemAsync(int id)
        {
            return await Task.FromResult(exhibitions.FirstOrDefault(s => s.Exhibition_ID == id));
        }

        public async Task<IEnumerable<Exhibition>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(exhibitions);
        }
    }
}