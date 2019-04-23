using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Views;
using static DeepSeaWorldApp.DBClasses.DBs;
using System.Collections.Generic;

namespace DeepSeaWorldApp.ViewModels
{
    public class ExhibitsViewModel : BaseViewModel2
    {
        public Exhibition Exhibition { get; }

        public ExhibitsViewModel()
        {
            Exhibition = new Exhibition
            {
                Exhibition_Name = "name",
            };
        }
        public ExhibitsViewModel(string qrcode)
        {
            Exhibition e = new Exhibition();
            SQLiteDB db = new SQLiteDB();
            List<Exhibition> list = new List<Exhibition>();
            list = db.GetItemAsyncExhibition().Result;
            foreach(var i in list)
            {
                if(i.QRCodes_Name.Equals(qrcode))
                {
                    e = i;
                }
            }
        }
    }

}