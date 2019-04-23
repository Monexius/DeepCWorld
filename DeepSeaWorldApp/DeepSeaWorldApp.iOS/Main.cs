using System;
using DeepSeaWorldApp;
using DeepSeaWorldApp.iOS;
using UIKit;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            Console.WriteLine("Main.cs");
            UIApplication.Main(args, null, "AppDelegate");
            Secondary();
        }
        static async System.Threading.Tasks.Task Secondary()
        {
            DeepSeaWorldSQLiteConnectioniOS deepSeaWorld = new DeepSeaWorldSQLiteConnectioniOS();

            MySqlDBCon mySql = new MySqlDBCon();
            DataTb data = new DataTb();
            data = await mySql.MySQLConnection(); // connection and data catch from mySQL db on server
            deepSeaWorld.TableAsync(); // table async - creation of local db tables
            await deepSeaWorld.InsertUpdateTables(data); // insert data to local db

            //DeepSeaWorldSQLiteConnectioniOS deepSeaWorld = new DeepSeaWorldSQLiteConnectioniOS();

            //MySqlDBCon mySql = new MySqlDBCon();
            //DataTb data = new DataTb();
            //data = await mySql.MySQLConnection(); // connection and data catch from mySQL db on server
            //deepSeaWorld.TableAsync(); // table async - creation of local db tables
            //await deepSeaWorld.InsertUpdateTables(data); // insert data to local db

        }
    }
}
