using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class FAQ
    {
        private DeepSeaWorldContext context; 

        public int FAQ_ID { get; set; }
        public string FAQ_Questions { get; set; }
        public string FAQ_Anwswere { get; set; }
    }
}
