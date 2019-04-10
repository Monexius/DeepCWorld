using System;
using SQLite;
using Xamarin.Forms;

namespace DeepSeaWorldApp.Models
{
    public class FAQ
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }


}