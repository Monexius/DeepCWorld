using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class News
    {
        private DeepSeaWorldContext context;

        public int News_ID { get; set; }
        public string News_Title { get; set; }
        public string News_Brief_Info { get; set; }
        public string News_IMG { get; set; }
        public string News_Article { get; set; }
        public string Notifications { get; set; }
    }
}
