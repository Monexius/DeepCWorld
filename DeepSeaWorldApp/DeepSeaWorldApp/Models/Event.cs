using System;
using SQLite;
using Xamarin.Forms;

namespace DeepSeaWorldApp.Models
{
    public class Event
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Id { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}