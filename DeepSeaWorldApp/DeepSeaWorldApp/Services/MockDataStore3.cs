using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepSeaWorldApp.Models;

namespace DeepSeaWorldApp.Services
{
    public class MockDataStore3 : IDataStore3<News>
    {
        List<News> news;

        public MockDataStore3()
        {
            news = new List<News>();
            var mockNews = new List<News>
            {
                new News { Id = Guid.NewGuid().ToString(), Title = "news title 1", Lead="lead 1", Body="body 1" },
                new News { Id = Guid.NewGuid().ToString(), Title = "news title 2", Lead="lead 2", Body="body 2" },
                new News { Id = Guid.NewGuid().ToString(), Title = "news title 3", Lead="lead 3", Body="body 3" },

            };

            foreach (var n in mockNews)
            {
                news.Add(n);
            }
        }

        public async Task<bool> AddItemAsync(News n)
        {
            news.Add(n);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(News n)
        {
            var oldNews = news.Where((News arg) => arg.Id == n.Id).FirstOrDefault();
            news.Remove(oldNews);
            news.Add(n);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldNews = news.Where((News arg) => arg.Id == id).FirstOrDefault();
            news.Remove(oldNews);

            return await Task.FromResult(true);
        }

        public async Task<News> GetItemAsync(string id)
        {
            return await Task.FromResult(news.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<News>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(news);
        }
    }
}