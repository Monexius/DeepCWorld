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
            LoadData();
            //String question = _database.GetAsync<FAQ>(1).Result.Question;
            //Console.WriteLine("Question: " + question);
            //String question1 = _database.GetAsync<FAQ>(2).Result.Question;
            //Console.WriteLine("Question: " + question1);
            //String question2 = _database.GetAsync<FAQ>(3).Result.Question;
            //Console.WriteLine("Question: " + question2);
        }
        public void LoadData()
        {
            Console.WriteLine("DATABASE COUNTER: " + _database.Table<FAQ>().CountAsync().Result);
            if (_database.Table<FAQ>().CountAsync().Result == 0)
            {
                Console.WriteLine("DATABASE COUNTER: " + _database.Table<FAQ>().CountAsync().Result);
                // only insert the data if it doesn't already exist
                var newFAQ = new FAQ();
                newFAQ.ID = 1;
                newFAQ.Question = "QuestionT";
                newFAQ.Answer = "AnswerT";
                _database.InsertAsync(newFAQ);

                var newFAQ2 = new FAQ();
                newFAQ2.ID = 2;
                newFAQ2.Question = "QuestionU";
                newFAQ2.Answer = "AnswerU";
                _database.InsertAsync(newFAQ2);

                var newFAQ3 = new FAQ();
                newFAQ3.ID = 3;
                newFAQ3.Question = "QuestionV";
                newFAQ3.Answer = "AnswerV";
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
