using DeepSeaWorldApp.DBClasses;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Json;
using Xamarin.Forms;
using DeepSeaWorldApp;

namespace DeepSeaWorldApp
{
    class DeepSeaWorldMySQLDBConn<T> where T : class 
    {
        //public List<T> sync;
        //readonly Task<List<T>> TsAsync;

        public DeepSeaWorldMySQLDBConn()
        {
            //TsAsync = DependencyService.Get<IMySQlSyncInterface<T>>().MySQLConnection(sync);
            //sync = DependencyService.Get<IMySQlSyncInterface<T>>().Data;
        }

       //public List<T> tablesData
        //{
            //get => sync;
            //set => this.tablesData = TsAsync.Result;
        }

    }

//}
