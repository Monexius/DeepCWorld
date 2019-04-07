using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using DeepSeaWorldApp.Models;
using System.IO;
using System;

namespace DeepSeaWorldApp.Services
{
    public class FAQDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FAQDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FAQ>().Wait();

            var faqs = new List<FAQ>();
            var mockFAQ = new List<FAQ>
                {
                    new FAQ {Question="Question1", Answer="Answer1" },
                    new FAQ {Question="Question2", Answer="Answer2" },
                    new FAQ {Question="Question3", Answer="Answer3" },
                };

            foreach (var e in mockFAQ)
            {

                SaveFAQAsync(e);
            }
        }

        public Task<List<FAQ>> GetFAQsAsync()
        {
            return _database.Table<FAQ>().ToListAsync();
        }

        public Task<FAQ> GetFAQAsync(int id)
        {
            return _database.Table<FAQ>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFAQAsync(FAQ faq)
        {
            if (faq.ID != 0)
            {
                return _database.UpdateAsync(faq);
            }
            else
            {
                return _database.InsertAsync(faq);
            }
        }

        public Task<int> DeleteFAQAsync(FAQ faq)
        {
            return _database.DeleteAsync(faq);
        }
    }
}
