using System;
using SQLite;
using Xamarin.Forms;

namespace DeepSeaWorldApp.Models
{
    public class Timer
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Time { get; set; }
    }
}