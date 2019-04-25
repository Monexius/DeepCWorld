using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class FAQDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FAQDatabase(string dbPath)
        {

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FAQ>().Wait();
            LoadData();
        }
        public void LoadData()
        {
            if (_database.Table<FAQ>().CountAsync().Result == 0)
            {
                // only insert the data if it doesn't already exist
                var newFAQ = new FAQ();
                newFAQ.FAQ_ID = 1;
                newFAQ.FAQ_Question = "Question1";
                newFAQ.FAQ_Anwswere = "Answer1";
                _database.InsertAsync(newFAQ);

                var newFAQ2 = new FAQ();
                newFAQ2.FAQ_ID = 2;
                newFAQ2.FAQ_Question = "Question2";
                newFAQ2.FAQ_Anwswere = "Answer2";
                _database.InsertAsync(newFAQ2);

                var newFAQ3 = new FAQ();
                newFAQ3.FAQ_ID = 3;
                newFAQ3.FAQ_Question = "Question3";
                newFAQ3.FAQ_Anwswere = "Answer3";
                _database.InsertAsync(newFAQ3);
            }
        }

        public Task<List<FAQ>> GetFAQsAsync()
        {
            return _database.Table<FAQ>().ToListAsync();
        }

        public Task<FAQ> GetFAQAsync(int id)
        {
            return _database.Table<FAQ>()
                            .Where(i => i.FAQ_ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFAQAsync(FAQ faq)
        {
            if (faq.FAQ_ID != 0)
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
