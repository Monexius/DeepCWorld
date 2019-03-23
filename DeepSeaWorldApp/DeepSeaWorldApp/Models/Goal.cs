using System;
using SQLite;
using Xamarin.Forms;

namespace trackerApp.Models
{
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime Last_updated { get; set; }
    }
}
