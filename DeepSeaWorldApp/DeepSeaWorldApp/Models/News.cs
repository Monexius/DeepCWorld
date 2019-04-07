using System;
using SQLite;
using Xamarin.Forms;

namespace DeepSeaWorldApp.Models
{
    public class News
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
    }
}