using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;

namespace DeepSeaWorldApp
{
    class DeepSeaWorldMySQLDBConn
    {
        public async void DBConnAsync()
        {
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://121.0.0.1");
                var response = await client.GetAsync("http://121.0.0.1/my-app/dbConnector.php");

                //if(response.IsSuccessStatusCode == true)
                //{
                //    App.Current.MainPage.DisplayAlert("Connection MySQL", "true", " ok");
                //}
                

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Connection MySQL", "false", "not ok");
            }
        }

    }
}
