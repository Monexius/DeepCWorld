using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class Map
    {
        private DeepSeaWorldContext context;

        public int Map_ID { get; set; }
        public string Map_IMG { get; set; }
    }
}
