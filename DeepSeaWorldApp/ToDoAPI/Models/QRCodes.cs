using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class QRCodes
    {
        private DeepSeaWorldContext context;

        public int QRCodes_ID { get; set; }
        public string QRCodes_Name { get; set; }
        public string QRCodes_IMG { get; set; }
        public int QRCodes_Pos { get; set; }
    }
}
