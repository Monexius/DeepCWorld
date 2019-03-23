using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using trackerApp.Models;

namespace trackerApp.Data
{
    public class GoalDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public GoalDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Goal>().Wait();
        }

        public Task<List<Goal>> GetGoalsAsync()
        {
            return _database.Table<Goal>().ToListAsync();
        }

        public Task<Goal> GetGoalAsync(int id)
        {
            return _database.Table<Goal>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveGoalAsync(Goal goal)
        {
            if (goal.ID != 0)
            {
                return _database.UpdateAsync(goal);
            }
            else
            {
                return _database.InsertAsync(goal);
            }
        }

        public Task<int> DeleteGoalAsync(Goal goal)
        {
            return _database.DeleteAsync(goal);
        }
    }
}
