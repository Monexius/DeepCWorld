using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class Exhibition
    {
        private DeepSeaWorldContext context;

        public int Exhibition_ID { get; set; }
        public int Exhibition_QRCode_Pos { get; }
        public string Exhibition_Description { get; set; }
        public string Exhibition_IMG_Name { get; set; }
        public string Exhibition_IMG { get; set; }
        public string Exhibition_Video_Name { get; set; }
        public string Exhibition_Video { get; set; }
        public string Exhibition_Name { get; set; }
        public string QRCode_Name { get; }
    }
}
