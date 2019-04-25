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
            _database.CreateTableAsync<Exhibition>().Wait();
            LoadData();
        }
        public void LoadData()
        {
            if (_database.Table<Exhibition>().CountAsync().Result == 0)
            {
                // only insert the data if it doesn't already exist
                List<Exhibition> exhibitions = new List<Exhibition>
                {
                    new Exhibition {Exhibition_ID=0, 
                                    Exhibition_IMG="seal3.jpeg", 
                                    Exhibition_Name="Seals",
                                    Exhibition_Video="sealv.mp4",
                                    Exhibition_IMG_Name="img", Exhibition_Video_Name="vid", 
                                    Exhibition_Description="Common seals are skilled predators, believe it or not! By storing oxygen in their muscles and blood, rather than in their lungs, they can dive for up to 30 minutes, searching for their favourite food. They eat plenty of different things, but they love small sea creatures like oily fish, squid, and molluscs the most!",
                                    QRCodes_Name="F767-348G56"},
                    new Exhibition {Exhibition_ID=1,
                                    Exhibition_IMG="shark2.jpeg",
                                    Exhibition_Name="Sand Sharks",
                                    Exhibition_Video="fish.mp4",
                                    Exhibition_IMG_Name="img", Exhibition_Video_Name="vid",
                                    Exhibition_Description="The Sand Tiger shark is the largest shark on display at Deep Sea World and can grow up to three and a half metres in length.\nSand Tiger sharks are also known as grey nurse or ragged tooth sharks and are normally found around Australia, Africa and America.",
                                    QRCodes_Name="F767-459E36"}
                };
                foreach(var e in exhibitions)
                {
                    _database.InsertAsync(e);
                }
            }
        }

        public Task<List<Exhibition>> GetExhibitionsAsync()
        {
            return _database.Table<Exhibition>().ToListAsync();
        }

        public Task<Exhibition> GetExhibitionsAsync(int id)
        {
            return _database.Table<Exhibition>()
                            .Where(i => i.Exhibition_ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Exhibition> GetExhibitionsAsync(string qrcode)
        {
            return _database.Table<Exhibition>()
                            .Where(i => i.QRCodes_Name == qrcode)
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
