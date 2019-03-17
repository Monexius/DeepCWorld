using DeepSeaWorldApp.DBClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeaWorldApp
{
    public interface MySQlSyncInterface<T> where T : class
    {
        List<T> Data { get; set; }
    }
}
