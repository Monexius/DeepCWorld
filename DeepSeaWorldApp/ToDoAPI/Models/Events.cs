using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class Events
    {
        private DeepSeaWorldContext context;

        public int Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string Event_Description { get; set; }
        public string Event_IMG { get; set; }
        public string Event_Location { get; set; }
        public string Event_Day { get; set; }
        public string Event_Time { get; set; }
    }
}
