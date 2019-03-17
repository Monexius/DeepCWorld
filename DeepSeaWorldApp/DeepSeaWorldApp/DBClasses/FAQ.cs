using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Text;

namespace DeepSeaWorldApp.DBClasses
{
    // faq data
    public class FAQ
    {
        [JsonProperty("FAQ_ID")]
        public long FAQ_ID { get; set; }
        [JsonProperty("FAQ_Question")]
        public string FAQ_Question { get; set; }
        [JsonProperty("FAQ_Anwsere")]
        public string FAQ_Anwswere { get; set; }
    }

    // list of data from faq table
    public class RootObject
    {
        public List<FAQ> faq { get; set; }
    }

 

}
