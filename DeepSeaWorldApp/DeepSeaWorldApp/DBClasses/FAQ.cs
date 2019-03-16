using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;

namespace DeepSeaWorldApp.DBClasses
{
    public class FAQ
    {
        public int FAQ_ID { get; set; }
        public string FAQ_Question { get; set; }
        public string FAQ_Anwswere { get; set; }

    }

    public class RootObject
    {
        public List<FAQ> faq { get; set; }
    }

    
}
