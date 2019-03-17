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
        public int FAQ_ID { get; set; }
        public string FAQ_Question { get; set; }
        public string FAQ_Anwswere { get; set; }

    }

    // list of data from faq table
    public class RootObject
    {
        public List<FAQ> faq { get; set; }

        //public void SaveFile(string s)
        //{
        //    string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        //    string fpath = Path.Combine(path, "faq.txt");
        //    using (var file = File.Open(fpath, FileMode.Create, FileAccess.Write))
        //    using (var strm = new StreamWriter(file))
        //    {
        //        strm.Write(s);
        //    }
        //}
    }

 

}
