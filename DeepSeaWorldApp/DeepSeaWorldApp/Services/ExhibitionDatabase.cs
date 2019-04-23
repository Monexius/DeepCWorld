using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.Services
{
    public class ExhibitionDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ExhibitionDatabase(string dbPath)
        {

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Events>().Wait();
            LoadData();
            //String question = _database.GetAsync<Events>(1).Result.Question;
            //Console.WriteLine("Question: " + question);
            //String question1 = _database.GetAsync<Events>(2).Result.Question;
            //Console.WriteLine("Question: " + question1);
            //String question2 = _database.GetAsync<Events>(3).Result.Question;
            //Console.WriteLine("Question: " + question2);
        }
        public void LoadData()
        {
            Console.WriteLine("DATABASE COUNTER: " + _database.Table<Exhibition>().CountAsync().Result);
            if (_database.Table<Exhibition>().CountAsync().Result == 0)
            {
                Console.WriteLine("DATABASE COUNTER: " + _database.Table<Exhibition>().CountAsync().Result);
                // only insert the data if it doesn't already exist
                List<Exhibition> exhibitions = new List<Exhibition>
                {
                    new Exhibition {Exhibition_ID=0, Exhibition_IMG="img", Exhibition_Name="exhibit1",Exhibition_Video="vid",
                                    Exhibition_IMG_Name="img", Exhibition_Video_Name="vid", Exhibition_Description="desc"}
                };
                foreach(var e in exhibitions)
                {
                    _database.InsertAsync(e);
                }
            }
        }

        public Task<List<Exhibition>> GetExhibitionssAsync()
        {
            return _database.Table<Exhibition>().ToListAsync();
        }

        public Task<Exhibition> GetExhibitionsAsync(int id)
        {
            return _database.Table<Exhibition>()
                            .Where(i => i.Exhibition_ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveExhibitionAsync(Exhibition exhibition)
        {
            if (exhibition.Exhibition_ID != 0)
            {
                return _database.UpdateAsync(exhibition);
            }
            else
            {
                return _database.InsertAsync(exhibition);
            }
        }

        public Task<int> DeleteExhibitionAsync(Exhibition exhibition)
        {
            return _database.DeleteAsync(exhibition);
        }
    }
}
