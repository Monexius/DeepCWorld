using SQLite;
using System.Collections.Generic;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.DBClasses
{
    public class DBsList
    {
        public class DataTb
        {
            public List<FAQ> FAQ { get; set; }
            public List<Events> Events { get; set; }
            public List<Events> Exhibition { get; set; }
            public List<Map> Map { get; set; }
            public List<News> News { get; set; }
            public List<QRCodes> QRCodes { get; set; }
        }
    }
}
