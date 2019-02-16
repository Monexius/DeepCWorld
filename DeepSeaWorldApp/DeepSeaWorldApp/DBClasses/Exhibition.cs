using System;
using System.Collections.Generic;
using System.Text;

namespace DeepSeaWorldApp.DBClasses
{
    class Exhibition
    {
        int Exhibition_ID { get; set; }
        int Exhibition_QRCode_Pos { get; }
        string Exhibition_Description { get; set; }
        string Exhibition_IMG_Name { get; set; }
        string Exhibition_IMG { get; set; }
        string Exhibition_Video_Name { get; set; }
        string Exhibition_Video { get; set; }
        string Exhibition_Name { get; set; }
        string QRCode_Name { get; }
    }
}
